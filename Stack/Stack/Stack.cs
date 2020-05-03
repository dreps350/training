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
            T value = Peek();
            innerList.RemoveLast();
            return value;
        }

        public void Push(T val)
        {
            // ваш код
            innerList.AddLast(new LinkedListNode<T>(val));
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