/*
1. Добавьте в класс LinkedList метод удаления одного узла по его значению.
2. Добавьте в класс LinkedList метод удаления всех узлов по конкретному значению.
3. Добавьте в класс LinkedList метод очистки всего содержимого (создание пустого списка).
4. Добавьте в класс LinkedList метод поиска всех узлов по конкретному значению (возвращается список/массив найденных узлов).
5. Добавьте в класс LinkedList метод вычисления длины списка.
6. Добавьте в класс LinkedList метод вставки узла после заданного узла.

 * * 7. Напишите проверочные тесты для каждого из предыдущих заданий.
* 8. Напишите функцию, которая получает на вход два связных списка, состоящие из целых значений, 
и если их длины равны, возвращает список, каждый элемент которого равен сумме соответствующих элементов входных списков.
 
 */

using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node
    {
        public int value;
        public Node next;
        public Node(int _value) { value = _value; }

        public override string ToString()
        {
            return "<Node: " + value.ToString();
        }
    }

    public class LinkedList
    {
        public Node head;
        public Node tail;

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public override string ToString()
        {
            List<Node> nodes = this.GetNodesList();
            return nodes.ToString();
        }

        public void AddInTail(Node _item)
        {
            if (head == null) head = _item;
            else tail.next = _item;
            tail = _item;
        }

        public Node Find(int _value)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) return node;
                node = node.next;
            }
            return null;
        }

        public List<Node> GetNodesList()
        {
            List<Node> nodes = new List<Node>();
            // здесь будет ваш код поиска всех узлов по заданному значению
            Node node = head;
            while (node != null)
            {
                nodes.Add(node);
                node = node.next;
            }
            return nodes;
        }

        public List<Node> FindAll(int _value)
        {
            List<Node> nodes = new List<Node>();
            // здесь будет ваш код поиска всех узлов по заданному значению
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) nodes.Add(node);
                node = node.next;
            }
            return nodes;
        }

        public bool Remove(int _value)
        {
            Node prev = new Node(0);
            Node curr = head;
            prev.next = curr;
            while (curr != null)
            {
                if (curr.value == _value)
                {
                    prev.next = curr.next;
                    if (curr == tail) tail = prev;
                    else if (curr == head) head = curr.next;
                    //curr = curr.next;
                    return true;
                }
                else
                {
                    prev = prev.next;
                    curr = curr.next;
                }
            }
            return false;
        }

        public void RemoveAll(int _value)
        {
            // здесь будет ваш код удаления всех узлов по заданному значению
            // 1, 1, 2
            // 1, 2, 2
            // 1, 2, 1
            // 2, 1, 1
            while (null != head.next && head.value == _value)
            {
                head = head.next;
            }
            Node node = head;
            while (node != null)
            {
                if (null != node.next && node.next.value == _value)
                {
                    node.next = node.next.next;
                }
                node = node.next;
            }
        }

        public void Clear()
        {
            // здесь будет ваш код очистки всего списка
        }

        public int Count()
        {
            return 0; // здесь будет ваш код подсчёта количества элементов в списке
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            // здесь будет ваш код вставки узла после заданного

            // если _nodeAfter = null , 
            // добавьте новый элемент первым в списке 
        }

    }
}