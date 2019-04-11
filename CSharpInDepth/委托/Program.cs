using System;

namespace 委托
{
    class Program
    {
        // 定义委托，并引用一个方法，这个方法需要获取一个int型参数返回void
        internal delegate void Feedback(int value);
        static void Main(string[] args)
        {
            Program p = new Program();
            StaticDelegateDemo();
            InstanceDelegateDemo();
            ChainDelegateDemo(p);
            ChainDelegateDemo2(p);
            Console.WriteLine("Hello World!");
            string[] names = { "Jeff", "Jee", "aa", "bb" };
            //char find = 'e';
            //names= Array.FindAll(names, name => name.IndexOf(find) >= 0);
            //Array.ForEach(names, Console.WriteLine);
            Console.ReadKey();
        }
        
        /// <summary>
        /// 静态调用
        /// </summary>
        private static void StaticDelegateDemo()
        {
            Console.WriteLine("---------委托调用静态方法------------");
            Counter(1, 10, null);
            //Counter(1, 10, new Feedback(FeedbackToConsole));
            //Counter(1, 10, FeedbackToConsole);
            Counter(1, 10, value => Console.WriteLine(value));

        }

        /// <summary>
        /// 实例调用
        /// </summary>
        private static void InstanceDelegateDemo()
        {
            Console.WriteLine("---------委托调用实例方法------------");
            Program p = new Program();
            Counter(1, 10, null);
            Counter(1, 5, new Feedback(p.InstanceFeedbackToConsole));
        }

        /// <summary>
        /// 委托链调用 1
        /// </summary>
        /// <param name="p"></param>
        private static void ChainDelegateDemo(Program p)
        {
            Console.WriteLine("---------委托链调用1------------");
            Feedback fb1 = new Feedback(FeedbackToConsole);
            Feedback fb2 = new Feedback(p.InstanceFeedbackToConsole);
            Feedback fbChain = null;
            fbChain = (Feedback)Delegate.Combine(fbChain, fb1);
            fbChain = (Feedback)Delegate.Combine(fbChain, fb2);
            Counter(1, 3, fbChain);
            Console.WriteLine();
            fbChain = (Feedback)Delegate.Remove(fbChain, new Feedback(FeedbackToConsole));
            Counter(1, 3, fbChain);
        }

        /// <summary>
        /// 委托链调用 2
        /// </summary>
        /// <param name="p"></param>
        private  static void ChainDelegateDemo2(Program p)
        {
            Console.WriteLine("---------委托链调用2------------");
            Feedback fb1 = new Feedback(FeedbackToConsole);
            Feedback fb2 = new Feedback(p.InstanceFeedbackToConsole);
            Feedback fbChain = null;
            fbChain += fb1;
            fbChain += fb2;
            Counter(1, 3, fbChain);
            Console.WriteLine();
            fbChain -= new Feedback(FeedbackToConsole);
            Counter(1, 2, fbChain);
        }
        /// <summary>
        /// 使用此方法触发委托回调
        /// </summary>
        /// <param name="from">开始</param>
        /// <param name="to">结束</param>
        /// <param name="fb">委托引用</param>
        private static void Counter(int from,int to, Feedback fb)
        {
            for (int val = from; val <= to; val++)
            {
                // fb不为空，则调用回调方法
                if (fb != null)
                {
                    fb(val);
                }
                //fb?.Invoke(val); 简化版本调用
            }
        }

        /// <summary>
        /// 静态回调方法
        /// </summary>
        /// <param name="value"></param>
        private static void FeedbackToConsole(int value)
        {
            // 依次打印数字
            Console.WriteLine("Item=" + value);
        }
        /// <summary>
        /// 实例回调方法
        /// </summary>
        /// <param name="value"></param>
        private void InstanceFeedbackToConsole(int value)
        {
            Console.WriteLine("Item=" + value);
        }
    }
}
