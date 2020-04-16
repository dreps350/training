using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Programm
    {
        public static void Main()
        {
            DynArray<int> arr = new DynArray<int>();
            foreach (int el in arr.array)
            {
                Console.WriteLine(el);
            }
            Console.WriteLine((int)(1 / 1.5));
        }
    }
}

