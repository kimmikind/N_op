using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_N_op
{
    class Stack<T>
    {
        private LinkedList<T> stack;
        public Stack()
        {
            stack = new LinkedList<T>(); Counter.Increment(2); //2
        }
        // добавление элемента в вершину стека(голову)
        public void Push(T item) //1
        {
            stack.AddLast(item); Counter.Increment(); //1
        }
        // удаление последнего добавленного элемента из головы стека
        public T Pop() //6
        {
            Counter.Increment();
            if (stack.Count == 0) //1
            {
                Counter.Increment();
                throw new InvalidOperationException("The Stack is empty"); //1
            }
            T item = stack.Last.Value; Counter.Increment(2); //2
            stack.RemoveLast(); Counter.Increment(); //1
            return item; //1
        }
        // возвращает первый верхний элемент без его удаления
        public T Peek() //3
        {
            Counter.Increment();
            if (stack.Count == 0) //1
            {
                Counter.Increment();
                throw new InvalidOperationException("The Stack is empty"); //1
            }
            return stack.Last.Value; //1
        }
        // чтение элемента по индексу из стека
        public T ElementAt(int index) //9+sigma(0,n)(1+1+7+2)=9+sigma(0,n)(11)=20+11n
        {
            Counter.Increment();
            if (index < 0) //1
                throw new ArgumentOutOfRangeException(); //1
            if (IsEmpty()) //1
                return default; //1
            T item = default(T); Counter.Increment(3); //2
            Counter.Increment(2);
            for (int _ = 0; _ < Length(); _++) //2
            {
                if (_ == index) //1
                {
                    Counter.Increment();
                    item = Peek(); //1
                    Counter.Increment();
                }
                Push(Pop()); //7
                Counter.Increment();
                Counter.Increment(2); //2
            }

            return item; //1
        }
        // вставка элемента по индексу
        public void Replace(int index, T item) //7+sigma(0,x-n)(4)+1+2+sigma(0,n)(1+6+1)+2=12+sigma(0,x-n)(4)+sigma(0,n)(8)=12+4(x-n)+4+8n+8=24+4n
        {
            Counter.Increment();
            if (index < 0) //1
            {
                Counter.Increment();
                throw new ArgumentOutOfRangeException(); //1
            }
            Counter.Increment();
            if (index >= Length()) //1
            {
                int length = Length(); Counter.Increment(); //1
                Counter.Increment(3);
                for (int _ = 0; _ < index - length; _++) //3
                {
                    Push(default(T)); Counter.Increment(); //1
                    Counter.Increment(3); //3
                }

                Push(item); Counter.Increment(); //1
                return;
            }
            Counter.Increment(2);
            for (int _ = 0; _ < Length(); _++) //2
            {
                Counter.Increment();
                if (_ == index) //1
                {
                    Pop(); //6
                    Push(item); Counter.Increment(); //1
                }
                else
                    Push(Pop()); Counter.Increment(); //7
                Counter.Increment(2); //2
            }
        }

        // поменять местами два элемента стека
        public void SwapElements(int index1, int index2) //89+30n
        {
            T temp = ElementAt(index1); Counter.Increment(); //1+20+11n
            Replace(index1, ElementAt(index2)); Counter.Increment(2); //24+4n+20+11n
            Replace(index2, temp); Counter.Increment(2); //24+4n
        }
        // длина стека
        public int Length() //1
        {
            Counter.Increment();
            return stack.Count;
        }
        // проверить на наличие элементов в стеке
        public bool IsEmpty() //1
        {
            Counter.Increment();
            return Length() == 0;
        }
    }

}
