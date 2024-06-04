using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreading
{
    public class Synchronization
    {
        private object lockObject = new object ();
        public void RunSynchronization()
        {
            Thread thread1 = new Thread(SomeMethod)
            {
                Name = "Thread 1"
            };
            Thread thread2 = new Thread(SomeMethod)
            {
                Name = "Thread 2"
            };
            Thread thread3 = new Thread(SomeMethod)
            {
                Name = "Thread 3"
            };
            thread1.Start();
            thread2.Start();
            thread3.Start();
            Console.ReadKey();
        }

        private void SomeMethod()
        {
            Console.WriteLine(Thread.CurrentThread.Name + " Start");
            lock (lockObject)
            {
                Console.Write("[" + Thread.CurrentThread.Name + " Welcome To The ");
                Thread.Sleep(5000);
                Console.WriteLine("World of " + Thread.CurrentThread.Name + " Dotnet!]");
            }
            Console.WriteLine(Thread.CurrentThread.Name + " End");
        }
    }
}
