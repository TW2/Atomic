using FFmpeg.AutoGen;
using FFmpeg.Helper;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace Atomic.FFmpeg
{
    public unsafe class FFmpegAutoGenWrapper
    {        
        Core core = null;

        public FFmpegAutoGenWrapper(Core core)
        {
            FFmpegBinariesHelper.RegisterFFmpegBinaries();
            this.core = core;
        }

        public unsafe void GenerateImageFromFrame(string videoPath, long frame)
        {
            using (var vsd = new VideoStreamDecoder(videoPath))
            {
                var sourceSize = vsd.FrameSize;
                var sourcePixelFormat = vsd.PixelFormat;
                var destinationSize = sourceSize;
                var destinationPixelFormat = AVPixelFormat.AV_PIX_FMT_BGR24;

                using (var vfc = new VideoFrameConverter(sourceSize, sourcePixelFormat, destinationSize, destinationPixelFormat))
                {
                    long bytesCurrent = core.MediaInfo.FrameToBytes(frame);

                    vsd.TryDecodeNextFrame(out var avframe, bytesCurrent);

                    var convertedFrame = vfc.Convert(avframe);

                    Bitmap bmp = new Bitmap(
                        convertedFrame.width, 
                        convertedFrame.height, 
                        convertedFrame.linesize[0], 
                        PixelFormat.Format24bppRgb, 
                        (IntPtr)convertedFrame.data[0]);

                    bmp.Save("temp.png", ImageFormat.Png);
                }
            }
        }

        public unsafe void GenerateImageFromMs(string videoPath, long ms)
        {
            GenerateImageFromFrame(videoPath, core.MediaInfo.TimeSpanToFrame(TimeSpan.FromMilliseconds(ms)));
        }

        private int data_size = 0;
        private FileStream fs = null;

        public unsafe void GetWav(string videoPath)
        {
            FileInfo fi = new FileInfo("temp.wav");
            if (fi.Exists) fi.Delete();
            using (fs = new FileStream("temp.wav", FileMode.Create))
            {
                DoAudio(videoPath);
            }
        }

        public unsafe int DecodeAudioPacket(AVCodecContext* pCodecCtx, AVPacket* pPacket, AVFrame* pDecodedFrame)
        {
            int ret = -1;

            do
            {
                ret = ffmpeg.avcodec_send_packet(pCodecCtx, pPacket);
            }
            while (ret == ffmpeg.AVERROR(ffmpeg.EAGAIN));

            if (ret == ffmpeg.AVERROR_EOF || ret == ffmpeg.AVERROR(ffmpeg.EINVAL))
            {
                return -1;
            }

            ret = ffmpeg.avcodec_receive_frame(pCodecCtx, pDecodedFrame);

            data_size = ffmpeg.av_get_bytes_per_sample(pCodecCtx->sample_fmt);

            if (data_size < 0)
            {
                return -1;
            }

            for (int ch = 0; ch < pCodecCtx->channels; ch++)
            {
                byte[] arr = new byte[data_size];
                Marshal.Copy((IntPtr)pDecodedFrame->data.ToArray()[ch], arr, 0, data_size);
                //fwrite(frame->data[ch] + data_size*i, 1, data_size, outfile);
                fs.Write(arr, 0, data_size);
            }

            return 0;
        }

        private int DoAudio(string filepath)
        {
            AVFormatContext* pFormatCtx = ffmpeg.avformat_alloc_context();
            int audioStream = -1, ret = -1;

            AVPacket* pPacket = ffmpeg.av_packet_alloc(); if (pPacket == null) return -1;

            // Open video file
            if (ffmpeg.avformat_open_input(&pFormatCtx, filepath, null, null) != 0) {
                return -1;
            }

            // Retrieve stream information
            if (ffmpeg.avformat_find_stream_info(pFormatCtx, null) < 0) {
                return -1;
            }
            
            // Dump information about file onto standard error
            ffmpeg.av_dump_format(pFormatCtx, 0, filepath, 0);

            // Find the first audio stream
            for (int i = 0; i<pFormatCtx->nb_streams; i++) {
                if (pFormatCtx->streams[i]->codec->codec_type == AVMediaType.AVMEDIA_TYPE_AUDIO) {
                    audioStream = i;
                    break;
                }
            }
            if (audioStream == -1) {
                return -1;
            }

            // Get a pointer to the codec context for the video stream
            AVCodecContext* pCodecCtx = pFormatCtx->streams[audioStream]->codec;

            /* find audio decoder */
            AVCodec* pCodec = ffmpeg.avcodec_find_decoder(pCodecCtx->codec_id);

            if (pCodec == null) {
                return -1;
            }

            AVCodecParserContext* pParser = ffmpeg.av_parser_init(Convert.ToInt32(pCodec->id));
            if (pParser == null) {
                return -1;
            }

            pCodecCtx = ffmpeg.avcodec_alloc_context3(pCodec);
            if (pCodecCtx == null) {
                return -1;
            }

            /* open it */
            if (ffmpeg.avcodec_open2(pCodecCtx, pCodec, null) < 0) {
                return -1;
            }
        
            ffmpeg.av_init_packet(pPacket);

            AVFrame* pDecodedFrame = null;
            byte* data = null;

            while (ffmpeg.av_read_frame(pFormatCtx, pPacket) >= 0) {
                // Is this a pPacket from the audio stream?
                if (pPacket->stream_index == audioStream) {
                    if(pDecodedFrame == null){
                        pDecodedFrame = ffmpeg.av_frame_alloc();
                        if (pDecodedFrame == null){
                            return -1;
                        }
                    }
                
                    ret = ffmpeg.av_parser_parse2(pParser, pCodecCtx, &pPacket->data, &pPacket->size,
                                           data, data_size,
                                           ffmpeg.AV_NOPTS_VALUE, ffmpeg.AV_NOPTS_VALUE, 0);
                
                    if (ret< 0) {
                        return -1;
                    }

                    if (pPacket->size > 0){
                        DecodeAudioPacket(pCodecCtx, pPacket, pDecodedFrame);
                    }
                
                }
            }

            /* flush the decoder */
            DecodeAudioPacket(pCodecCtx, pPacket, pDecodedFrame);

            // Free memory
            ffmpeg.avcodec_free_context(&pCodecCtx);
            ffmpeg.av_parser_close(pParser);
            ffmpeg.av_frame_free(&pDecodedFrame);
            ffmpeg.av_packet_free(&pPacket);

            return 0;
        }
    }
}
