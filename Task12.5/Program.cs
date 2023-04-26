using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Task12._5
{
    public class Program
    {
        static Semaphore semaphore = new Semaphore(2, 5, "MySemafore");
        private static object locker = new object();
        static void MyFunction(object number)
        {
            string input = "Потік "+ number+" зайняв слот семафору";
            string output = "Потік " + number + " звільнив слот семафору";
            semaphore.WaitOne();
            lock (locker)
            {
                using (StreamWriter writer = new StreamWriter(@"LogFile.log", true))
                {
                    writer.WriteLine(input);
                    Console.WriteLine(input);
                    Thread.Sleep(1000);
                    writer.WriteLine(output);
                    Console.WriteLine(output);
                }
            }
            semaphore.Release();
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            for (int i = 0; i < 10; i++)
            {
                new Thread(MyFunction).Start(i);
                Thread.Sleep(1000);
            }

            Console.ReadLine();
        }
    }
}
