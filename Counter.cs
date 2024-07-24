using System;

namespace Lab1_N_op
{
    public static class Counter
    {
        private static long N_op = 0;

        public static long PopN_op()
        {
            long n_op = N_op;
            N_op = 0;
            return n_op;
        }

        public static void Increment()
        {
            N_op++;
        }

        public static void Increment(int increment)
        {
            N_op += increment;
        }
    }
}
