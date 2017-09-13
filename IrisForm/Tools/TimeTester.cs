using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class TimeTester
    {
        private DateTime timerStart;
        private DateTime timerEnd;
        private TimeSpan timeSpan;

        public void SetTimer()
        {
            timerStart = new DateTime();
        }

        public void StopTimer()
        {
            timerEnd = new DateTime();
        }

        //public TimeSpan GetTime()
        //{
        //    try
        //    {

        //    }
        //    catch ()

        //}
    }
}
