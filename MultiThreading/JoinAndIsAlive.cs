using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreading
{
    public class Dummy
    {
        public int DummyA { get; set; }
        public int DummyB { get; set; }
    }

    public class NumberHelper
    {
        Dummy obj;

        public NumberHelper(Dummy dummy)
        {
            obj = dummy;
        }

        public void Method1()
        {
            obj.DummyA = 1;
            obj.DummyB = 2;
        }

        public void Method2()
        {
            obj.DummyA = 3;
            obj.DummyB = 4;
        }
    }

    class JoinAndIsAlive
    {
        public void RunJoinAndIsAlive1()
        {
            Console.WriteLine("Main Thread Started");

            Thread thread1 = new Thread(Method1);   thread1.Name = "First Thread";
            Thread thread2 = new Thread(Method2);   thread2.Name = "Second Thread";
            Thread thread3 = new Thread(Method3);   thread3.Name = "Third Thread";
            thread1.Start();
            thread2.Start();
            thread3.Start();

            if (thread2.Join(TimeSpan.FromSeconds(3)))
            {
                Console.WriteLine("Thread 2 Execution Completed in 3 second");
            }
            else
            {
                Console.WriteLine("Thread 2 Execution Not Completed in 3 second");
            }

            if (thread3.Join(3000))
            {
                Console.WriteLine("Thread 3 Execution Completed in 3 second");
            }
            else
            {
                Console.WriteLine("Thread 3 Execution Not Completed in 3 second");
            }

            if (thread2.IsAlive)
            {
                Console.WriteLine("Thread 2 Method 2 is still Executing");
            }
            else
            {
                Console.WriteLine("Thread 2 Method 2 Completed its work");
            }

            if (thread3.IsAlive)
            {
                Console.WriteLine("Thread 3 Method 3 is still Executing");
            }
            else
            {
                Console.WriteLine("Thread 3 Method 3 Completed its work");
            }
            

            Console.WriteLine("Main Thread Ended");
            Console.Read();
        }

        public void RunJoinAndIsAlive2()
        {
            Dummy dummy = new Dummy();
            NumberHelper obj = new NumberHelper(dummy);
            Thread thread1 = new Thread(obj.Method1);
            Thread thread2 = new Thread(obj.Method2);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine(dummy.DummyA + " " + dummy.DummyB);
            Console.Read();
        }

        private void Method1()
        {
            Console.WriteLine("Method1 - Thread1 Started");
            Thread.Sleep(12000);
            Console.WriteLine(Thread.CurrentThread.Name + " Method1 - Thread 1 Ended");
        }

        private void Method2()
        {
            Console.WriteLine("Method2 - Thread2 Started");
            Thread.Sleep(2000);
            Console.WriteLine(Thread.CurrentThread.Name + " Method2 - Thread2 Ended");
        }

        private void Method3()
        {
            Console.WriteLine("Method3 - Thread3 Started");
            Thread.Sleep(10000);
            Console.WriteLine(Thread.CurrentThread.Name + " Method3 - Thread3 Ended");
        }
    }
}
