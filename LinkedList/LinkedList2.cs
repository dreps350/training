/*
1. Добавьте в класс LinkedList2 метод удаления одного узла по его значению. +
2. Добавьте в класс LinkedList2 метод удаления всех узлов по конкретному значению. +
3. Добавьте в класс LinkedList2 метод очистки всего содержимого (создание пустого списка). +
4. Добавьте в класс LinkedList2 метод поиска всех узлов по конкретному значению (возвращается список/массив найденных узлов). +
5. Добавьте в класс LinkedList2 метод вычисления длины списка. +
6. Добавьте в класс LinkedList2 метод вставки узла после заданного узла. +

* 7. Напишите проверочные тесты для каждого из предыдущих заданий.
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
        public Node next, prev;
        public Node(int _value)
        {
            value = _value;
            next = null;
            prev = null;
        }

        public override string ToString()
        {
            return "<Node: " + value.ToString() + ">";
        }
    }

    public class LinkedList2
    {
        public Node head;
        public Node tail;

        public LinkedList2()
        {
            head = null;
            tail = null;
        }

        public LinkedList2(List<int> list)
        {
            head = null;
            tail = null;
            foreach (int _value in list)
            {
                AddInTail(new Node(_value));
            }
        }

        public LinkedList2(List<Node> list)
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
            string repr = "";
            Node node = head;
            while (node != null)
            {
                repr += node.ToString();
                node = node.next;
            }
            return repr;
        }

        public void AddInTail(Node _item)
        {
            if (head == null) {
                head = _item;
                head.next = null;
                head.prev = null;
            } else {
                tail.next = _item;
                _item.prev = tail;
            }
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

        public List<Node> ToList()
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

        public List<Node> ToInversedList()
        {
            List<Node> nodes = new List<Node>();
            Node node = tail;
            while (node != null)
            {
                nodes.Add(node);
                node = node.prev;
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
            bool _value_found = false;
            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    if (node == head && node == tail)
                    {
                        head = null;
                        tail = null;
                    }
                    else
                    {
                        if (node == head)
                        {
                            head = node.next;
                            head.prev = null;
                        }
                        else if (node == tail)
                        {
                            tail = node.prev;
                            tail.next = null;
                        }
                        else
                        {
                            node.prev.next = node.next;
                            node.next.prev = node.prev;
                        }
                    }
                    _value_found = true;
                    if (!remove_all) { break; }
                }
                node = node.next;
            }
            return _value_found;
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
            return ToList().Count;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            // если _nodeAfter = null , 
            // добавьте новый элемент первым в списке 
            if (head == null) AddInTail(_nodeToInsert);
            else if (_nodeAfter == null)
            {
                _nodeToInsert.next = head;
                head.prev = _nodeToInsert;
                head = _nodeToInsert;
            }
            else
            {
                _nodeToInsert.next = _nodeAfter.next;
                _nodeAfter.next = _nodeToInsert;
                _nodeToInsert.prev = _nodeAfter;
                if (tail == _nodeAfter) tail = _nodeToInsert;
            }
        }
    }
}