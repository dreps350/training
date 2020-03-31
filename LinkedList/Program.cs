/*
Рекомендации по тестированию.
Проверяйте случаи, когда список пустой, содержит много элементов и один элемент: как в таких ситуациях будет работать 
удаление одного и нескольких элементов, 
вставка, 
поиск. Особое внимание уделите корректности полей head и tail после всех этих операций. 
 */

using System;
using System.Collections.Generic;


namespace AlgorithmsDataStructures
{
    class LinkedListUtils
    {
        static LinkedList2 NodewiseSum(LinkedList2 list, LinkedList2 other_list)
        {
            if (list.Count() == other_list.Count())
            {
                LinkedList2 result = new LinkedList2();
                Node node = list.head;
                Node other_node = other_list.head;
                while (node != null && other_node != null)
                {
                    result.AddInTail(new Node(node.value + other_node.value));
                    node = node.next;
                    other_node = other_node.next;
                }
                return result;
            }
            return null;
        }
        public static void Main(string[] args)
        {
            LinkedList2 list = new LinkedList2(new List<Node> { new Node(1), new Node(2), new Node(3) });
            LinkedList2 other_list = new LinkedList2(new List<Node> { new Node(1), new Node(2), new Node(3) });
            Console.WriteLine(NodewiseSum(list, other_list));

            LinkedList2 list_2 = new LinkedList2(new List<Node> { new Node(1) });
            LinkedList2 other_list_2 = new LinkedList2(new List<Node> { new Node(1) });
            Console.WriteLine(NodewiseSum(list_2, other_list_2));

            LinkedList2 list_3 = new LinkedList2();
            LinkedList2 other_list_3 = new LinkedList2();
            Console.WriteLine(NodewiseSum(list_3, other_list_3));
        }
    }
}
