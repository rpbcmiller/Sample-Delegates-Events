using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndEvents
{
    public class ProcessRequest
    {
        public void Process(int x, int y, DoBusinessLogic bizRule)
        {
            var result = bizRule(x, y);
            Console.WriteLine($"Result of Biz Rule = {result}");
        }

        public void ProcessAction(int x, int y, Action<int, int> bizRule)
        {
            Console.Write("My Action<T> ");
            bizRule(x, y);
        }
        public void ProcessFunc(int x, int y, Func<int,int,double> bizRule)
        {
            var result = bizRule(x, y);
            Console.WriteLine($"Func of Biz Rule = {result}");
        }

    }
}
