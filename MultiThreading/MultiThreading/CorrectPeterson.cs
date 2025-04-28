using System;
using System.Threading;

namespace MultiThreading
{
    internal class PetersonLock
    {
        private volatile bool[] flag = new bool[2];
        private volatile int victim;

        public void Enter(int threadId)
        {
            if (threadId < 0 || threadId > 1)
                throw new ArgumentException("Thread ID must be 0 or 1", nameof(threadId));

            int otherThreadId = 1 - threadId;

            flag[threadId] = true;

            victim = threadId;

            while (flag[otherThreadId] && victim == threadId)
            {
                Thread.Yield();
            }
        }

        public void Exit(int threadId)
        {
            if (threadId < 0 || threadId > 1)
                throw new ArgumentException("Thread ID must be 0 or 1", nameof(threadId));

            flag[threadId] = false;
        }
    }
}
