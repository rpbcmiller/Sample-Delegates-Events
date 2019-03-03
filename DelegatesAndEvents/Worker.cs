using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndEvents
{
    //public delegate int WorkerPerformanceHandler(int hours, WorkType workType);

    public class Worker
    {
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted;

        public void DoWork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; i++)
            {
                System.Threading.Thread.Sleep(1000);
                OnWorkPerformed(i + 1, workType);
            }
                WorkCompleted(this, new WorkPerformedEventArgs(hours, workType));
        }

        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            //if (WorkPerformed != null)
            //{
            //    WorkPerformed(hours, workType);
            //}
            // or use syntax below that is more explict check on delegate

            var del1 = WorkPerformed as EventHandler<WorkPerformedEventArgs>;
            if (del1 != null)
            {
                WorkPerformed(this, new WorkPerformedEventArgs(hours, workType));
            }
        }

        protected virtual void OnWorkCompleted()
        {

            //if (WorkCompleted != null)
            //{
            //    WorkCompleted(this, EventArgs.Empty);
            //}
            // or and more explict way to check that event handler
            var delCmplt = WorkCompleted as EventHandler;
            if (delCmplt != null)
            {
                WorkCompleted(this, EventArgs.Empty);
            }
        }
    }
}
