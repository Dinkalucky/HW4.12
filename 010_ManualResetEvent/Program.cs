using System;
using System.Text;
using System.Threading;

// ManualResetEvent - Повідомляє один чи більше очікуваних потоків про те, що сталася подія.

namespace ManualResetEventNs
{
    class Program
    {
        // Аргумент:
        // false - установка у несигнальний стан.
        static AutoResetEvent manual = new AutoResetEvent(false);

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            new Thread(Function1).Start();
            new Thread(Function2).Start();

            Thread.Sleep(500);  // Дамо час запуститися вторинним потокам.

            Console.WriteLine("Натисніть будь-яку клавішу для переведення ManualResetEvent у сигнальний стан.\n");
            Console.ReadKey();
            manual.Set();
            manual.Set();// Надсилає сигнал усім потокам.

            // Delay
            Console.ReadKey();
        }

        static void Function1()
        {
            Console.WriteLine("Потік 1 запущений та очікує сигналу.");
            manual.WaitOne(); // Зупинка виконання вторинного потоку 1.
            Console.WriteLine("Потік 1 завершується.");
        }

        static void Function2()
        {
            Console.WriteLine("Потік 2 запущений та очікує сигналу.");
            manual.WaitOne(); // Зупинення виконання вторинного потоку 2.
            Console.WriteLine("Потік 2 завершується.");
        }
    }
}
