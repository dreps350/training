/*
Рекомендации по тестированию.
Проверяйте случаи, когда список пустой, содержит много элементов и один элемент: как в таких ситуациях будет работать 
удаление одного и нескольких элементов, 
вставка, 
поиск. Особое внимание уделите корректности полей head и tail после всех этих операций. 
 */

using System;


namespace AlgorithmsDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            LinkedList s_list = new LinkedList();
            Node n1 = new Node(20);
            Node n2 = new Node(13);
            s_list.AddInTail(n1);
            s_list.AddInTail(n2);
            s_list.AddInTail(new Node(128));
            
        }
    }
}
