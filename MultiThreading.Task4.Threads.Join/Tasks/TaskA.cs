using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MultiThreading.Task4.Threads.Join.Tasks
{
    public class TaskA : ICreatingThreads
    {
        public void CreateThreads(int count = 10)
        {
            if (count == 0)
                return;

            var thread = new Thread(ShowWorkingThread);

            thread.Name = string.Concat("Thread name with Join ->", count.ToString());
            thread.Start();
            thread.Join();

            CreateThreads(--count);
        }

        public void ShowWorkingThread()
        {
            Thread.Sleep(500);
            Console.WriteLine(Thread.CurrentThread.Name);
        }
    }
}
