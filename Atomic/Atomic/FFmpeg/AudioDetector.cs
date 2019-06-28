using FFmpeg.AutoGen;
using FFmpeg.Helper;
using System;
using System.Collections.Generic;

namespace Atomic.FFmpeg
{
    public sealed unsafe class AudioDetector : IDisposable
    {
        private readonly AVCodecContext* _pCodecContext;
        private readonly AVFormatContext* _pFormatContext;
        private readonly int _streamIndex;
        private readonly AVFrame* _pFrame;
        private readonly AVPacket* _pPacket;

        private List<AudioInfo> audioList = new List<AudioInfo>(); 

        public AudioDetector(string url)
        {
            FFmpegBinariesHelper.RegisterFFmpegBinaries();

            _pFormatContext = ffmpeg.avformat_alloc_context();

            var pFormatContext = _pFormatContext;
            ffmpeg.avformat_open_input(&pFormatContext, url, null, null).ThrowExceptionIfError();

            ffmpeg.avformat_find_stream_info(_pFormatContext, null).ThrowExceptionIfError();

            // find the first audio stream
            AVStream* pStream = null;
            for (var i = 0; i < _pFormatContext->nb_streams; i++)
                if (_pFormatContext->streams[i]->codec->codec_type == AVMediaType.AVMEDIA_TYPE_AUDIO)
                {
                    pStream = _pFormatContext->streams[i];

                    if (pStream != null)
                    {
                        _streamIndex = pStream->index;
                        _pCodecContext = pStream->codec;

                        var codecId = _pCodecContext->codec_id;
                        var pCodec = ffmpeg.avcodec_find_decoder(codecId);
                        if (pCodec == null) throw new InvalidOperationException("Unsupported codec.");

                        ffmpeg.avcodec_open2(_pCodecContext, pCodec, null).ThrowExceptionIfError();

                        AudioInfo a_info = new AudioInfo();
                        a_info.Codec = ffmpeg.avcodec_get_name(codecId);
                        a_info.StreamIndex = _streamIndex;

                        audioList.Add(a_info);
                    }
                }

            _pPacket = ffmpeg.av_packet_alloc();
            _pFrame = ffmpeg.av_frame_alloc();
        }

        public List<AudioInfo> AudioList { get => audioList; }

        public void Dispose()
        {
            ffmpeg.av_frame_unref(_pFrame);
            ffmpeg.av_free(_pFrame);

            ffmpeg.av_packet_unref(_pPacket);
            ffmpeg.av_free(_pPacket);

            ffmpeg.avcodec_close(_pCodecContext);
            var pFormatContext = _pFormatContext;
            ffmpeg.avformat_close_input(&pFormatContext);
        }
    }
}
