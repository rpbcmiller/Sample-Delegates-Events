using System;

namespace DelegatesAndEvents
{
    public delegate int DoBusinessLogic(int x, int y);

    class Program
    {


        static void Main(string[] args)
        {

            var result = 7 / 2;
            Console.WriteLine(result);

            DoBusinessLogic rule1 = (x, y) => x + y;
            DoBusinessLogic rule2 = (x, y) => x * y;

            var ApplyRule = new ProcessRequest();
            ApplyRule.Process(2, 3, rule1);
            ApplyRule.Process(2, 3, rule2);

            Action<int, int> r1 = (x, y) => Console.WriteLine(x + y);
            Action<int, int> r2 = (x, y) => Console.WriteLine(x * y);
            ApplyRule.ProcessAction(2, 3, r1);
            ApplyRule.ProcessAction(2, 3, r2);

            Func<int, int, double> r3 = (x, y) => x + y;
            Func<int, int, double> r4 = (x, y) => x * y;
            ApplyRule.ProcessFunc(2, 3, r3);
            ApplyRule.ProcessFunc(2, 3, r4);

            //var del1 = new WorkerPerformanceHandler(WorkPerformance1);
            //var del2 = new WorkerPerformanceHandler(WorkPerformance2);
            //var del3 = new WorkerPerformanceHandler(WorkPerformance3);

            //del1 += del3 + del2;
            //Console.WriteLine(DoWork(del1));
            Worker worker = new Worker();
            worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(Work_InProgress);
            worker.WorkPerformed += delegate (object sender, WorkPerformedEventArgs e)
           {
               Console.WriteLine($"In Progress Anom {e.Hours} {e.WorkType}");
               Console.WriteLine("If you have multiple lines in lambda expressoin");
           };
            worker.WorkPerformed += (sender, e) =>
            {
                Console.WriteLine($"In Progress Anom {e.Hours} {e.WorkType}");
            };

            worker.WorkCompleted += new EventHandler(WorkFinished);
            worker.WorkCompleted += Finshed;
            worker.DoWork(10, WorkType.GenerateReports);
            Console.ReadKey();
        }
        private static int GetSquare(int x) => x * x;

        private static void Finshed(object sender, EventArgs e)
        {
            var args = e as WorkPerformedEventArgs;

            if (e == EventArgs.Empty || args == null)
            {
                Console.WriteLine($"Finished");
            }
            else
            {
                Console.WriteLine($"Finshed {args.Hours} doing {args.WorkType}");
            }
        }

        private static void WorkFinished(object sender, EventArgs e)
        {
            var args = e as WorkPerformedEventArgs;

            if (e == EventArgs.Empty || args == null)
            {
                Console.WriteLine($"Complete");
            }
            else
            {
                Console.WriteLine($"Complete {args.Hours} doing {args.WorkType}");
            }
        }

        private static void Work_InProgress(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine($"In Progress {e.Hours} {e.WorkType}");
        }



        //static int DoWork(WorkerPerformanceHandler del)
        //{
        //    return del(5, WorkType.Golf);
        //}

        //static int WorkPerformance1(int hours, WorkType workType)
        //{
        //    Console.WriteLine($"WorkPerformance1 Called hours={hours}-{workType}");
        //    return 1;
        //}


        //static int WorkPerformance2(int hours, WorkType workType)
        //{
        //    Console.WriteLine($"WorkPerformance2 Called hours={hours}-{workType}");
        //    return 2;
        //}

        //static int WorkPerformance3(int hours, WorkType workType)
        //{
        //    Console.WriteLine($"WorkPerformance3 Called hours={hours}-{workType}");
        //    return 3;
        //}

    }
    public enum WorkType
    {
        GoToMeeting,
        Golf,
        GenerateReports
    }
}
