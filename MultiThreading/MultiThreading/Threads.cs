using System.Numerics;
using System.Diagnostics;

namespace MultiThreading
{
    class ArraySumCalculator<TNum>() 
        where TNum: INumber<TNum>

    {

        private static int threadsCount;
        private static int portThreadsCount;

        private static int elemsPerThread;
        private static int remainder;
        private static int ost = remainder != 0 ? 1 : 0;
        private readonly TNum[] arr = null!;
        private static readonly ReaderWriterLockSlim resultWriteLock = new ReaderWriterLockSlim();

        public ArraySumCalculator(TNum[] arr) : this()
        {
            elemsPerThread = arr.Length / threadsCount <= 1 ? 2 : arr.Length / threadsCount;
            remainder = arr.Length % threadsCount;
            this.arr = arr;
        }

        public TNum CalculateAsync()
        {
            Console.WriteLine(threadsCount);
            TNum result = TNum.Zero;
            var tasks = new List<Task>();

            for (int i = 0; i < threadsCount + ost; i += 1)
            {
                var localI = i;
                var skip = localI * elemsPerThread;
                var take =  (i + 1 == threadsCount + ost) ? arr.Length - skip : elemsPerThread;

                var task = Task.Run(() =>
                {
                    TNum particialResult = TNum.Zero;
                    for (int j = skip; j < skip + take; j++) particialResult += arr[j];

                    resultWriteLock.EnterWriteLock();
                    result += particialResult;
                    resultWriteLock.ExitWriteLock();

                });

                tasks.Add(task);
            }
            Task.WaitAll(tasks);

            return result;
        }
        
        public TNum Calculate(TNum[] array)
        {
            TNum result = TNum.Zero;

            foreach (var num in array)
            {
                result += num;
            }

            return result;
        }

        public TNum Calculate()
        {
            TNum result = TNum.Zero;

            foreach (var num in arr)
            {
                result += num;
            }

            return result;
        }

        static ArraySumCalculator()
        {
            ThreadPool.GetAvailableThreads(out threadsCount, out portThreadsCount);
        }
    }

    public class Threads
    {
        public static void Main()
        {

            var timerAsync = new Stopwatch();
            var timer = new Stopwatch();

            var arr = new int[(int)Math.Pow(10, 8)];
            for (int i = 0; i < arr.Length; i++) arr[i] = 2;

            var sumCalculater = new ArraySumCalculator<int>(arr);

            timerAsync.Start();
            Console.WriteLine(sumCalculater.CalculateAsync());
            timerAsync.Stop();

            timer.Start();
            Console.WriteLine(sumCalculater.Calculate());
            timer.Stop();

            Console.WriteLine(
                $"Async: {timerAsync.ElapsedMilliseconds} vs Normal: {timer.ElapsedMilliseconds}"
                );
        }
    }
}