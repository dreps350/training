using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Queue<T>
    {
        LinkedList<T> storage;
        public Queue() => storage = new LinkedList<T>();

        public void Enqueue(T item) => storage.AddLast(item);

        public T Dequeue()
        {
            if (storage.Count == 0)
            {
                return default(T);
            }
            var item = storage.First.Value;
            storage.RemoveFirst();
            return item;
        }

        public int Size() => storage.Count;
    }
}