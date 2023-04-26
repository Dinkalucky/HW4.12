using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task12._3
{
    public class Program
    {
        static Mutex mutex = new Mutex(false, "MyMutex");

        static void MyFunction()
        {
            mutex.WaitOne();
            Console.WriteLine("Потік {0} зайшов у захищену область",Thread.CurrentThread.Name);
            Thread.Sleep(1000);
            Console.WriteLine("Потік {0} покинув захищену область", Thread.CurrentThread.Name);
            mutex.ReleaseMutex();
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Thread[] threads = new Thread[5];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(MyFunction);
                threads[i].Name = i.ToString();
                Thread.Sleep(1000);
                threads[i].Start();
            }

            Console.ReadLine();
        }
    }
}
