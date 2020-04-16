using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class DynArray<T>
    {
        public T[] array;
        public int count;
        public int capacity;
        public int MinCapacity = 16;

        public DynArray()
        {
            count = 0;
            MakeArray(MinCapacity);
        }

        public void MakeArray(int new_capacity)
        {
            capacity = new_capacity;
            T[] new_array = new T[new_capacity];
            if (array != null)
            {
                Array.Copy(array, 0, new_array, 0, count);
            }
            array = new_array;
        }

        public override string ToString()
        {
            string repr = "";
            foreach (T el in array)
            {
                repr += el.ToString() + " ";
            }
            return repr;
        }

        public void Reallocate(int increase = 2, double decrease = 1.5)
        {
            if (count == capacity)
            {
                 MakeArray(capacity * increase);
            }
            else if (count < capacity / 2.0) {
                MakeArray(Math.Max((int)(capacity / decrease), MinCapacity));
            }
        }

        public T GetItem(int index)
        {
            if (index >= count )
            {
                throw new IndexOutOfRangeException();
            }
            // validate index
            return (T)array.GetValue(index);
        }

        public void Append(T itm)
        {
            Reallocate();
            array.SetValue(itm, count);
            count++;
        }

        public void Insert(T itm, int index)
        {
            if (index == count)
            {
                Append(itm);
            }
            else if (index > count)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                Reallocate();
                for (int i = count; i > index; i--)
                {
                    array[i] = array[i - 1];
                }
                count++;
                array[index] = itm;
            }
        }

        public void Remove(int index)
        {
            if (index >= count)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                for (int i = index; i < count; i++)
                {
                    array[i] = array[i + 1];
                }
                count--;
                MakeArray(capacity);
                Reallocate();
            }
        }

    }
}