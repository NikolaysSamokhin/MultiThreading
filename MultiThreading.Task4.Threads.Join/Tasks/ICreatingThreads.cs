using System;
using System.Collections.Generic;
using System.Text;

namespace MultiThreading.Task4.Threads.Join.Tasks
{
    public interface ICreatingThreads
    {
        void CreateThreads(int count = 10);

        void ShowWorkingThread();
    }
}
