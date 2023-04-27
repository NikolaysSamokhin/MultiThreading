using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading.Task4.Threads.Join.Tasks
{
    public class TaskB : ICreatingThreads
    {
    
        Semaphore semaphore = new Semaphore(3, 3);
        public void CreateThreads(int count = 10)
        {
            if (count == 0)
                return;
            Task.Factory.StartNew(ShowWorkingThread);
       
            CreateThreads(--count);
        }

        public void ShowWorkingThread()
        {
            semaphore.WaitOne();
            Thread.Sleep(500);
            Console.WriteLine("semaphor");
            semaphore.Release();
        }
    }
}
