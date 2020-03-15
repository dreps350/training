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
            return "<Node: " + value.ToString() + ">";
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

        public LinkedList(List<int> list)
        {
            head = null;
            tail = null;
            foreach (int _value in list)
            {
                AddInTail(new Node(_value));
            }
        }

        public LinkedList(List<Node> list)
        {
            head = null;
            tail = null;
            foreach (Node node in list)
            {
                AddInTail(node);
            }
        }

        public override string ToString()
        {
            List<Node> nodes = GetNodesList();
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

        public bool Remove(int _value, bool remove_all = false)
        {
            bool value_found = false;
            // shift head
            while (head != null && head.value == _value)
            {
                if (tail == head) tail = head.next;
                head = head.next;
                value_found = true;
                if (!remove_all) break;
            }
            // handle other nodes
            if (head != null && !(!remove_all && value_found))
            {
                Node curr = head;
                Node next = head.next;
                while (next != null)
                {
                    if (next.value == _value)
                    {
                        value_found = true;
                        // remove link
                        curr.next = next.next;
                        // shift next node
                        if (tail == next) tail = curr;
                        next = next.next;
                        if (!remove_all) break;
                    }
                    else
                    {
                        // shift both nodes
                        curr = next;
                        next = next.next;
                    }
                }
            }

            return value_found;
        }

        public void RemoveAll(int _value)
        {
            Remove(_value, true);
        }

        public void Clear()
        {
            head = null;
            tail = null;
        }

        public int Count()
        {
            return GetNodesList().Count;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            // если _nodeAfter = null , 
            // добавьте новый элемент первым в списке 
            if (head == null) AddInTail(_nodeAfter);
            else if (_nodeAfter == null)
            {
                _nodeToInsert.next = head;
                head = _nodeToInsert;
            }
            else
            {
                _nodeToInsert.next = _nodeAfter.next;
                _nodeAfter.next = _nodeToInsert;
                if (tail == _nodeAfter) tail = _nodeToInsert;
            }
        }
    }
}