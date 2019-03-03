using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndEvents
{
    public class WorkPerformedEventArgs : System.EventArgs
    {
        public WorkPerformedEventArgs(int hr, WorkType workType)
        {
            Hours = hr;
            WorkType = workType;
        }

        public int Hours { get; set; }
        public WorkType WorkType { get; set; }
    }
}
