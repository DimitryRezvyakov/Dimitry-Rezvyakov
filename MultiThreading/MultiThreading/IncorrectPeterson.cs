using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace HomeworkThread
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;

        namespace HomeworkThread
        {
            internal class UncorrectPeterson
            {
                private bool[] flag = new bool[2];
                private int victim;

                public void Enter(int threadId)
                {
                    int otherThread = 1 - threadId;
                    flag[threadId] = true;
                    victim = threadId;
                    while (flag[otherThread] && victim == threadId)
                    {

                    }
                }

                public void Exit(int threadId)
                {

                    flag[threadId] = false;
                }
            }
        }
    }
}
