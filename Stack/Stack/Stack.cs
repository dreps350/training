using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Stack<T>
    {
        public LinkedList<T> innerList;
        public Stack()
        {
            // инициализация внутреннего хранилища стека
            innerList = new LinkedList<T>();
        }

        public int Size()
        {
            // размер текущего стека		  
            return innerList.Count;
        }

        public T Pop()
        {
            if (innerList.Count == 0)
            {
                return default(T); // null, если стек пустой
            }
            var result = (T)innerList.Last.Value;
            innerList.RemoveLast();
            return result;
        }

        public void Push(T val)
        {
            // ваш код
            innerList.AddLast(val);
        }

        public T Peek()
        {
            // ваш код
            if (innerList.Count == 0)
            {
                return default(T); // null, если стек пустой
            }
            return (T)innerList.Last.Value;
        }
    }

}