using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_N_op
{
    static class Sort
    {
        public static void InsertionSort(ref Stack<int> stack) //
        {
            Counter.Increment(2);
            InsertionSort(ref stack, stack.Length()); //4+58n+63n2+15n3
        }
        //сортировка вставками
        private static void InsertionSort(ref Stack<int> stack, int length) //2+58n+63n2+15n3
        {
            Counter.Increment(2);
            for (int i = 1; i < length; i++) //sigma(1,n)(2+3+2+3+94i+30ni)=10n+48n2+48n+15n3+15n2=58n+63n2+15n3
            {
                
                int j = i - 1; Counter.Increment(2); //2
                Counter.Increment(3);
                while ((j >= 0) && (stack.ElementAt(j) > stack.ElementAt(j + 1))) //3+sigma(0,i-1)(89+30n+2+3)=3+94i+30n*i
                {
                    stack.SwapElements(j, j + 1); Counter.Increment(2); //89+30n
                    j--; Counter.Increment(); //2
                    Counter.Increment(3); //3
                }
                Counter.Increment(2); //2
            }
        }
    }
}
