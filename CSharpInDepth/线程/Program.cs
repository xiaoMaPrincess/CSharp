using System;
using System.Threading;

namespace 线程
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("线程的调用：");
            Thread thread = new Thread(Add);
            thread.Start(5);
            Thread.Sleep(1000);
            Console.WriteLine("主线程做其他的工作.......");
            thread.Join();
            Console.ReadKey();
        }

        /// <summary>
        /// 线程要调用的方法
        /// </summary>
        /// <param name="state"></param>
        private static void Add(object state)
        {
            Console.WriteLine($"开始调用另一个线程:{state}");
            // 模拟做其他任务所用的时间  ，这个方法返回后，专用线程将停止调用
            Thread.Sleep(10000);
        }
    }
}
