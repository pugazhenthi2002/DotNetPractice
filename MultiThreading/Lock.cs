using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreading
{
    class Lock
    {
        private static readonly object LockCount = new object();
        private int Count = 0;

        public void RunLock()
        {
            Thread t1 = new Thread(IncrementCount);
            Thread t2 = new Thread(IncrementCount);
            Thread t3 = new Thread(IncrementCount);
            t1.Start();
            t2.Start();
            t3.Start();
            //Wait for all three threads to complete their execution
            t1.Join();
            t2.Join();
            t3.Join();
            Console.WriteLine(Count);
            Console.Read();
        }

        private void IncrementCount()
        {
            for (int i = 1; i <= 1000000; i++)
            {
                //Only protecting the shared Count variable
                //lock (LockCount)
                {
                    Count++;
                }
            }
        }
    }
}
