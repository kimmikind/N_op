using System;
using System.Diagnostics;

namespace Lab1_N_op
{
    public delegate long CountFn(int n);

    public delegate long CountOfn(int n);
    class Program
    {
        static void Main(string[] args)
        {
            CountFn countFn = i => (long)((4 + 58 * i + 63 * Math.Pow(i, 2)+ 15 * Math.Pow(i, 3)));
            CountOfn countOfn = i => (long)(Math.Pow(i, 3));
            for (int n = 3000; n <= 30000; n += 3000)
            {
                (long tn, long n_op) = TestInsertionSort(n);
                long fn = countFn(n);
                long ofn = countOfn(n);
                double c1 = Math.Round(Convert.ToDouble(fn) / tn, 3);
                double c2 = Math.Round(Convert.ToDouble(ofn) / tn, 3);
                double c3 = Math.Round(Convert.ToDouble(fn) / n_op, 3);
                double c4 = Math.Round(Convert.ToDouble(ofn) / n_op, 3);
                Console.WriteLine($"n = {n}\tF(n) = {fn}\tO(F(n)) = {ofn}\tT(n) = " +
                                  $"{Math.Round(Convert.ToDouble(tn) / 1000, 2)}\tN_op = {n_op}\t" +
                                  $"C1= {c1}\tC2 = {c2}\tC3 = {c3}\tC4 = {c4}");
            }

            Console.Write("Press any key to exit");
            Console.ReadKey();
        }

        private static (long,long) TestInsertionSort(int elementsNum)
        {
            Stack<int> stack = new Stack<int>();
            Random random = new Random();
            for (int i = 0; i < elementsNum; i++)
                stack.Push(random.Next(Int32.MaxValue));
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Sort.InsertionSort(ref stack);
            stopwatch.Stop();
            return (stopwatch.ElapsedMilliseconds, Counter.PopN_op());
        }
    }
}
