using System;
using System.Threading;
using System.Threading.Tasks;

namespace 线程
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("主线程启动.....");
            //Task<int> t = Task.Run(() =>Sum(100));
            //t.ContinueWith(task => Console.WriteLine($"sum: {task.Result}"),TaskContinuationOptions.OnlyOnCanceled);
            //t.ContinueWith(task => Console.WriteLine($"sum: {task.Result}"));
            //Status();
            // Thread.Sleep(10000);// 模拟任务10秒
            MyAsync(5);
            Console.WriteLine("主线程继续工作.....");




            #region 线程池异步调用
            //Console.WriteLine("主线程.........");
            //ThreadPool.QueueUserWorkItem(ComputeBoundOp,5);
            //Console.WriteLine("主线程做其他任务.........");
            //Thread.Sleep(10000);// 模拟任务10秒
            //Console.WriteLine("主线程任务完成.........");
            #endregion

            #region 线程调用初级版

            //Console.WriteLine("线程的调用：");
            //Thread thread = new Thread(Add);
            //thread.Start(5);
            //Thread.Sleep(1000);
            //Console.WriteLine("主线程做其他的工作.......");
            //thread.Join();
            #endregion


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

        /// <summary>
        /// 异步调用的方法：必须匹配WaiCallback委托
        /// </summary>
        /// <param name="state"></param>
        private static void ComputeBoundOp(object state)
        {
            Console.WriteLine($"辅助线程{state}");
            Thread.Sleep(1000);
        }

        /// <summary>
        /// Task调用
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static int Sum(int n)
        {
            int sum = 0;
            for (;  n>0; n--)
            {
                sum += n;
            }
            return sum;
        }
        // 异步任务
        private static async Task<string> Status()
        {
          var ss= await Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("异步调用");
                return "abcd";

            });
            return ss;
        }

        private static async Task<Type1> Method1()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("444");
            }
            return await Task.Run(() =>
            {
                Console.WriteLine("111");
                return new Type1();
            }); 

        }

        private static async Task<Type2> Method2()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("5");
            }
            return await Task.Run(() =>
            {
                Console.WriteLine("222");
                return new Type2();
            });
        }

        private static async Task<string> MyAsync(int value)
        {
            //for (int i = 0; i < 3; i++)
            //{
            //    var type2 = await Method2();
            //}
            Method2();
           await Method1();
            Console.WriteLine("333");
            
            return "done";
        }
    }
    internal sealed class Type1 { }
    internal sealed class Type2 { }

}
