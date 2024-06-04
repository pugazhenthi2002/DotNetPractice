using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreading
{
    class MonitorPractice
    {
        const int numberLimit = 20;
        private readonly object lockPrintNumbers = new object();

        public void RunMonitor1()
        {
            Thread[] Threads = new Thread[3];
            for (int i = 0; i < 3; i++)
            {
                Threads[i] = new Thread(PrintNumbers)
                {
                    Name = "Child Thread " + i
                };
            }
            foreach (Thread t in Threads)
            {
                t.Start();
            }
            Console.ReadLine();
        }

        public void RunMonitor2()
        {
            Thread EvenThread = new Thread(PrintEvenNumbers);
            Thread OddThread = new Thread(PrintOddNumbers);

            EvenThread.Start();
            Thread.Sleep(100);
            OddThread.Start();
            OddThread.Join();
            EvenThread.Join();

            Console.WriteLine("\nMain method completed");
            Console.ReadKey();
        }

        private void PrintNumbers()
        {
            Console.WriteLine(Thread.CurrentThread.Name + " Trying to enter into the critical section");

            try
            {
                Monitor.Enter(lockPrintNumbers);
                Console.WriteLine(Thread.CurrentThread.Name + " Entered into the critical section");
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(1000);
                    Console.Write(i + ",");
                }
                Console.WriteLine();
            }
            finally
            {
                Monitor.Exit(lockPrintNumbers);
                Console.WriteLine(Thread.CurrentThread.Name + " Exit from critical section");
            }
        }

        private void PrintEvenNumbers()
        {
            try
            {
                Monitor.Enter(lockPrintNumbers);
                for (int i = 0; i <= numberLimit; i = i + 2)
                {
                    Console.Write($"{i} ");
                    Monitor.Pulse(lockPrintNumbers);

                    bool isLast = false;
                    if (i == numberLimit)
                    {
                        isLast = true;
                    }
                    if (!isLast)
                    {
                        Monitor.Wait(lockPrintNumbers);
                    }
                }
            }
            finally
            {
                Monitor.Exit(lockPrintNumbers);
            }
        }

        private void PrintOddNumbers()
        {
            try
            {
                Monitor.Enter(lockPrintNumbers);
                for (int i = 1; i <= numberLimit; i = i + 2)
                {
                    Console.Write($"{i} ");
                    Monitor.Pulse(lockPrintNumbers);

                    bool isLast = false;
                    if (i == numberLimit - 1)
                    {
                        isLast = true;
                    }
                    if (!isLast)
                    {
                        Monitor.Wait(lockPrintNumbers);
                    }
                }
            }
            finally
            {
                Monitor.Exit(lockPrintNumbers);
            }
        }
    }
}
