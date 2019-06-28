using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atomic.FFmpeg
{
    public class AudioInfo
    {
        private int streamIndex = -1;
        private string language = null;
        private string codec = null;

        public int StreamIndex { get => streamIndex; set => streamIndex = value; }
        public string Language { get => language; set => language = value; }
        public string Codec { get => codec; set => codec = value; }
    }
}
