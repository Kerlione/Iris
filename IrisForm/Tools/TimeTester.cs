﻿using System;
using System.IO;

namespace Helpers
{
    public class TimeTester
    {
        private DateTime timerStart;
        private DateTime timerEnd;
        private TimeSpan timeSpan;
        private string name;
        
        public string FileName;
        public bool AddNewToFile;

        public TimeTester(string name, string fileName = null, bool addNewToFile = true)
        {
            this.name = name;
            this.AddNewToFile = addNewToFile;
            this.FileName = fileName;
        }

        public void SetTimer()
        {
            timerStart = DateTime.Now;
        }

        public void StopTimer()
        {
            timerEnd = DateTime.Now;
        }

        public TimeSpan GetTime()
        {
            try
            {
                if (timerStart != null)
                {
                    if (timerEnd == null)
                        StopTimer();

                    timeSpan = timerEnd - timerStart;
                    return timeSpan;
                }
                return TimeSpan.Zero;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string GetStringTime()
        {
            return (name + " : " + GetTime());
        }

        public void WriteToFile()
        {
            StreamWriter Writer;
            if (FileName != null && FileName != String.Empty)
                Writer = new StreamWriter(FileName, AddNewToFile);
            else
                Writer = new StreamWriter(name + ".txt", AddNewToFile);

            Writer.WriteLine(GetStringTime());
            Writer.Close();
        }
    }
}
