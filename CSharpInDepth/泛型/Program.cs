using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace 泛型
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string text = "Do you like green eggs and han? I do not like them,Sam-I-am";
            Dictionary<string, int> keyValues = CountWords(text);
            foreach (var item in keyValues)
            {
                string word = item.Key;
                int count = item.Value;
                Console.WriteLine($"{word}:word,{count}:count");
            }

            List<int> integers = new List<int>();
            integers.Add(1);
            integers.Add(2);
            integers.Add(3);
            integers.Add(4);

            Converter<int, double> converter = TakeSquareRoot;
            List<double> doubles;
            doubles = integers.ConvertAll<double>(converter);
            foreach (var item in doubles)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// 计数 泛型类型 Dictionary
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static Dictionary<string,int> CountWords(string text)
        {
            Dictionary<string, int> keyValues = new Dictionary<string, int>();
            // 正则表达式分解单词
            string[] words = Regex.Split(text, @"\W+");
            foreach (var item in words)
            {
                if (keyValues.ContainsKey(item))
                {
                    keyValues[item]++;
                }
                else
                {
                    keyValues[item] = 1;
                }
            }
            return keyValues;
        }

        static double TakeSquareRoot(int x)
        {
            return Math.Sqrt(x);
        }
    }
}
