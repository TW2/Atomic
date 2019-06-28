using MediaInfoLib;
using System;
using System.IO;

namespace Atomic.GetMediaInfo
{
    public class MediaInfoWrapper
    {
        private MediaInfo media = new MediaInfo();

        private double fps = -1d;
        private int num_frames = -1;
        private double ms_between_frames = -1d;

        public MediaInfo Media { get => media; set => media = value; }

        public double FPS { get => fps; }
        public int NumFrames { get => num_frames; }
        public double MsBetweenFrames { get => ms_between_frames; }

        public MediaInfoWrapper(string videoPath = null)
        {
            if(videoPath != null)
            {
                media.Open(videoPath);
                int fps_num = Convert.ToInt32(media.Get(StreamKind.Video, 0, "FrameRate_Num"));
                int fps_den = Convert.ToInt32(media.Get(StreamKind.Video, 0, "FrameRate_Den"));
                num_frames = Convert.ToInt32(media.Get(StreamKind.Video, 0, "FrameCount"));
                fps = Convert.ToDouble(fps_num) / Convert.ToDouble(fps_den);
                ms_between_frames = fps * 100d / num_frames;
            }
        }

        public TimeSpan FrameToTimeSpan(long frame)
        {
            //frame / fps = seconds
            double seconds = frame / fps;
            return TimeSpan.FromSeconds(seconds);
        }

        public long TimeSpanToFrame(TimeSpan time)
        {
            //seconds * fps = frame
            return Convert.ToInt64(time.TotalSeconds * fps);
        }

        public long FrameToBytes(long frame)
        {
            long duration = Convert.ToInt64(media.Get(StreamKind.Video, 0, "StreamSize"));
            return duration * frame / num_frames;
        }

        public long BytesToFrame(long bytes)
        {
            long duration = Convert.ToInt64(media.Get(StreamKind.Video, 0, "StreamSize"));
            //bytes <> frame
            //dur   <> nbFrm
            return bytes * num_frames / duration;
        }

        public TimeSpan BytesToTimeSpan(long bytes)
        {
            long msDur = Convert.ToInt64(media.Get(StreamKind.Video, 0, "Duration"));
            long duration = Convert.ToInt64(media.Get(StreamKind.Video, 0, "StreamSize"));
            //bytes <> ms
            //dur   <> msDur
            long ms = bytes * msDur / duration;
            return TimeSpan.FromMilliseconds(ms);
        }

        public long TimeSpanToBytes(TimeSpan time)
        {
            long msDur = Convert.ToInt64(media.Get(StreamKind.Video, 0, "Duration"));
            long duration = Convert.ToInt64(media.Get(StreamKind.Video, 0, "StreamSize"));
            //bytes <> ms
            //dur   <> msDur
            long bytes = Convert.ToInt64(time.TotalMilliseconds * duration / msDur);
            return bytes;
        }
    }
}
