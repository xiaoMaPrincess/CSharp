using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace 序列化与反序列化
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string> { "Jee", "Allen" };
            Stream stream = SerializeToMemory(list);
            Console.WriteLine(stream.ToString());
            stream.Position = 0;
            list = null;
            list = (List<string>)DeSerializeFromMemory(stream);
            // 测试是否反序列化成功
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        static MemoryStream SerializeToMemory(object obj)
        {
            // 构造流容纳序列化对象
            MemoryStream stream = new MemoryStream();
            // 构造序列化格式化器实例
            BinaryFormatter formatter = new BinaryFormatter();
            // 将对象序列化到流中
            formatter.Serialize(stream, obj);
            return stream;
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        static object DeSerializeFromMemory(Stream stream)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream);
        }
    }
}
