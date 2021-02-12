using System;
using System.Threading;

namespace Excersize_7
{
    class Program
    {
        private static bool _calculating = true;
        public static volatile int _numToCalc = 0;
        public static volatile int _numOfThreads = 0;
        public static volatile int _res = 0;
        static void Main(string[] args)
        {
            do
            {
                Console.Write($"Hello. Please write a number to get its factorial: ");
            }
            while (!int.TryParse(Console.ReadLine(), out _numToCalc));

            do
            {
                Console.Write($"Hello. Please write a number of threads: ");
            }
            while (!int.TryParse(Console.ReadLine(), out _numOfThreads));

            for (int i = 0; i < _numOfThreads; i++)
            {
                Thread thread = new Thread(MultiplyNumMultiThread);
                thread.Name = i.ToString();
                thread.Start();
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        private static void MultiplyNumMultiThread()
        {
            while (_calculating)
            {
                int oldRes = _res;
                if (_res == 0) _res = _numToCalc--;
                else _res *= _numToCalc--;
                Console.WriteLine($"Thread Id {Thread.CurrentThread.Name} has increased result from {oldRes} to {_res}. " +
                    $"Current multiplier = {_numToCalc + 1}");
                Thread.Sleep(100);
                if (_numToCalc == 1) _calculating = false;
            }
        }
    }
}
