using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            MutexPractice obj = new MutexPractice();
            obj.MutexRun();
        }
    }
}
