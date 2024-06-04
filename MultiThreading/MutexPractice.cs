using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreading
{
    class MutexPractice
    {
        private Mutex _mutex;

        public void MutexRun()
        {
            if (!IsSingleInstance())
            {
                Console.WriteLine("More than one instance"); // Exit program.
            }
            else
            {
                Console.WriteLine("One instance"); // Continue with program.
            }
            Console.ReadLine();
        }

        private bool IsSingleInstance()
        {
            try
            {
                Mutex.OpenExisting("MyMutex");
            }
            catch
            {
                _mutex = new Mutex(true, "MyMutex");
                return true;
            }

            return false;
        }
    }
}
