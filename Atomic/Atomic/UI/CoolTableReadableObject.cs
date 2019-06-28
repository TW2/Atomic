using CSASS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atomic.UI
{
    public class CoolTableReadableObject
    {
        private long msSentence = 0L;
        private long msPerfect = 0L;
        private Csass ca = null;

        public CoolTableReadableObject()
        {

        }

        public long MsSentence { get => msSentence; set => msSentence = value; }
        public long MsPerfect { get => msPerfect; set => msPerfect = value; }
        public Csass Subtitles { set => ca = value; }

        public double DoCalculation(int line, int cps = 30)
        {
            if(ca != null)
            {
                CA_Event ev = ca.Events[line];
                string text = ev.Text;
                if (text.Length > 0)
                {
                    msSentence = ev.End - ev.Start;
                    msPerfect = text.Length * cps;
                    return Convert.ToDouble(msPerfect) / Convert.ToDouble(msSentence);
                }
            }
            
            return -1d;
        }
    }
}
