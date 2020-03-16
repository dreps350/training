using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsDataStructures
{
    public class BaseTest
    {
        public LinkedList custom_list;
        public LinkedList empty_list;
        public LinkedList single_node_list;
        public LinkedList all_same_nodes_list;
        public LinkedList simple_list;
        public Node n1;
        public Node n2;
        public Node n3;
        public Node n4;
        public Node n5;
        public Node n6;
        public Node n7;
        public Node single_node = new Node(17);
        public Node all_same_node_1 = new Node(5);
        public Node all_same_node_2 = new Node(5);
        public Node all_same_node_3 = new Node(5);
        public Node simple_node_1 = new Node(1);
        public Node simple_node_2 = new Node(2);
        public Node simple_node_3 = new Node(3);

        public virtual void InitList()
        {
            custom_list = new LinkedList();
            empty_list = new LinkedList();

            single_node_list = new LinkedList();
            single_node_list.AddInTail(single_node);
            
            all_same_nodes_list = new LinkedList(new List<Node> { all_same_node_1, all_same_node_2, all_same_node_3 });

            simple_list = new LinkedList(new List<Node> { simple_node_1, simple_node_2, simple_node_3 });
        }
    }
    [TestClass]
    public class RemoveTest: BaseTest
    {
        [TestInitialize]
        public override void InitList()
        {
            base.InitList();
            n1 = new Node(1);
            n2 = new Node(2);
            n3 = new Node(3);
            custom_list.AddInTail(n1);
            custom_list.AddInTail(n2);
            custom_list.AddInTail(n3);
        }
        [TestMethod]
        public void RemoveEmpty()
        {
            List<Node> expected_nodes = new List<Node>();

            bool result = empty_list.Remove(1);
            List<Node> actual_nodes = empty_list.ToList();

            CollectionAssert.AreEqual(expected_nodes, actual_nodes);
            Assert.AreEqual(false, result);
            Assert.AreEqual(null, empty_list.head);
            Assert.AreEqual(null, empty_list.tail);
        }
        [TestMethod]
        public void RemoveSingle()
        {
            List<Node> expected_nodes = new List<Node>();

            bool result = single_node_list.Remove(single_node.value);
            List<Node> actual_nodes = single_node_list.ToList();

            CollectionAssert.AreEqual(expected_nodes, actual_nodes);
            Assert.AreEqual(true, result);
            Assert.AreEqual(null, single_node_list.head);
            Assert.AreEqual(null, single_node_list.tail);
        }
        [TestMethod]
        public void RemoveSameValues()
        {
            List<Node> expected_nodes = new List<Node>();
            expected_nodes.Add(all_same_node_2);
            expected_nodes.Add(all_same_node_3);

            bool result = all_same_nodes_list.Remove(all_same_node_1.value);
            List<Node> actual_nodes = all_same_nodes_list.ToList();

            CollectionAssert.AreEqual(expected_nodes, actual_nodes);
            Assert.AreEqual(true, result);
            Assert.AreEqual(all_same_node_2, all_same_nodes_list.head);
            Assert.AreEqual(all_same_node_3, all_same_nodes_list.tail);
        }
        [TestMethod]
        public void RemoveHead()
        {
            List<Node> expected_nodes = new List<Node>();
            expected_nodes.Add(n2);
            expected_nodes.Add(n3);

            bool result = custom_list.Remove(n1.value);
            List<Node> actual_nodes = custom_list.ToList();
            
            CollectionAssert.AreEqual(expected_nodes, actual_nodes);
            Assert.AreEqual(true, result);
            Assert.AreEqual(n2, custom_list.head);
            Assert.AreEqual(n3, custom_list.tail);
        }
        [TestMethod]
        public void RemoveTail()
        {
            List<Node> expected_nodes = new List<Node>();
            expected_nodes.Add(n1);
            expected_nodes.Add(n2);

            bool result = custom_list.Remove(n3.value);
            List<Node> actual_nodes = custom_list.ToList();

            CollectionAssert.AreEqual(expected_nodes, actual_nodes);
            Assert.AreEqual(true, result);
            Assert.AreEqual(n1, custom_list.head);
            Assert.AreEqual(n2, custom_list.tail);
        }
        [TestMethod]
        public void RemoveMiddle()
        {
            List<Node> expected_nodes = new List<Node>();
            expected_nodes.Add(n1);
            expected_nodes.Add(n3);

            bool result = custom_list.Remove(n2.value);
            List<Node> actual_nodes = custom_list.ToList();

            CollectionAssert.AreEqual(expected_nodes, actual_nodes);
            Assert.AreEqual(true, result);
            Assert.AreEqual(n1, custom_list.head);
            Assert.AreEqual(n3, custom_list.tail);
        }
    }
    [TestClass]
    public class RemoveAllTest : BaseTest
    {
        [TestInitialize]
        public override void InitList()
        {
            base.InitList();
            n1 = new Node(1);
            n2 = new Node(1);
            n3 = new Node(2);
            n4 = new Node(3);
            n5 = new Node(4);
            n6 = new Node(3);
            n7 = new Node(2);
            custom_list = new LinkedList(new List<Node> { n1, n2, n3, n4, n5, n6, n7 });
        }
        [TestMethod]
        public void RemoveAllEmpty()
        {
            List<Node> expected_nodes = new List<Node>();

            empty_list.RemoveAll(1);
            List<Node> actual_nodes = empty_list.ToList();

            CollectionAssert.AreEqual(expected_nodes, actual_nodes);
            Assert.AreEqual(null, empty_list.head);
            Assert.AreEqual(null, empty_list.tail);
        }
        [TestMethod]
        public void RemoveSingle()
        {
            List<Node> expected_nodes = new List<Node>();

            single_node_list.RemoveAll(single_node.value);
            List<Node> actual_nodes = single_node_list.ToList();

            CollectionAssert.AreEqual(expected_nodes, actual_nodes);
            Assert.AreEqual(null, single_node_list.head);
            Assert.AreEqual(null, single_node_list.tail);
        }
        [TestMethod]
        public void RemoveSameValues()
        {
            List<Node> expected_nodes = new List<Node>();

            all_same_nodes_list.RemoveAll(all_same_node_1.value);
            List<Node> actual_nodes = all_same_nodes_list.ToList();

            CollectionAssert.AreEqual(expected_nodes, actual_nodes);
            Assert.AreEqual(null, all_same_nodes_list.head);
            Assert.AreEqual(null, all_same_nodes_list.tail);
        }
        [TestMethod]
        public void RemoveHead()
        {
            List<Node> expected_nodes = new List<Node> { n3, n4, n5, n6, n7 };
            
            custom_list.RemoveAll(n1.value);
            List<Node> actual_nodes = custom_list.ToList();

            CollectionAssert.AreEqual(expected_nodes, actual_nodes);
            Assert.AreEqual(n3, custom_list.head);
            Assert.AreEqual(n7, custom_list.tail);
        }
        [TestMethod]
        public void RemoveTail()
        {
            List<Node> expected_nodes = new List<Node> { n1, n2, n4, n5, n6 };

            custom_list.RemoveAll(n7.value);
            List<Node> actual_nodes = custom_list.ToList();

            CollectionAssert.AreEqual(expected_nodes, actual_nodes);
            Assert.AreEqual(n1, custom_list.head);
            Assert.AreEqual(n6, custom_list.tail);
        }
        [TestMethod]
        public void RemoveMiddle()
        {
            List<Node> expected_nodes = new List<Node> { n1, n2, n3, n5, n7 };

            custom_list.RemoveAll(n4.value);
            List<Node> actual_nodes = custom_list.ToList();

            CollectionAssert.AreEqual(expected_nodes, actual_nodes);
            Assert.AreEqual(n1, custom_list.head);
            Assert.AreEqual(n7, custom_list.tail);
        }
    }

    [TestClass]
    public class InsertAfter: BaseTest
    {
        public Node insert_node;
        public Node insert_node_2;

        [TestInitialize]
        public override void InitList()
        {
            base.InitList();
            insert_node = new Node(171);
            insert_node_2 = new Node(112);
            n1 = new Node(1);
            n2 = new Node(2);
            n3 = new Node(3);
            custom_list = new LinkedList(new List<Node> { n1, n2, n3 });
        }
        [TestMethod]
        public void InsertAfterEmptyList()
        {
            List<Node> expected_nodes = new List<Node> { insert_node };

            empty_list.InsertAfter(null, insert_node);
            List<Node> actual_nodes = empty_list.ToList();

            CollectionAssert.AreEqual(expected_nodes, actual_nodes);
            Assert.AreEqual(insert_node, empty_list.head);
            Assert.AreEqual(insert_node, empty_list.tail);
        }
        [TestMethod]
        public void InsertAfterSingleListLeft()
        {
            List<Node> expected_nodes = new List<Node> { insert_node, single_node };

            single_node_list.InsertAfter(null, insert_node);
            List<Node> actual_nodes = single_node_list.ToList();

            CollectionAssert.AreEqual(expected_nodes, actual_nodes);
            Assert.AreEqual(insert_node, single_node_list.head);
            Assert.AreEqual(single_node, single_node_list.tail);
        }
        [TestMethod]
        public void InsertAfterSingleListRight()
        {
            List<Node> expected_nodes = new List<Node> { single_node, insert_node };

            single_node_list.InsertAfter(single_node, insert_node);
            List<Node> actual_nodes = single_node_list.ToList();

            CollectionAssert.AreEqual(expected_nodes, actual_nodes);
            Assert.AreEqual(single_node, single_node_list.head);
            Assert.AreEqual(insert_node, single_node_list.tail);
        }
        [TestMethod]
        public void InsertAfterMultipleLeft()
        {
            List<Node> expected_nodes = new List<Node> { insert_node, insert_node_2, n1, n2, n3 };

            custom_list.InsertAfter(null, insert_node_2);
            custom_list.InsertAfter(null, insert_node);
            List<Node> actual_nodes = custom_list.ToList();

            CollectionAssert.AreEqual(expected_nodes, actual_nodes);
            Assert.AreEqual(insert_node, custom_list.head);
            Assert.AreEqual(n3, custom_list.tail);
        }
        [TestMethod]
        public void InsertAfterMultipleRight()
        {
            List<Node> expected_nodes = new List<Node> { n1, n2, n3, insert_node, insert_node_2 };

            custom_list.InsertAfter(custom_list.Find(n3.value), insert_node);
            custom_list.InsertAfter(custom_list.Find(insert_node.value), insert_node_2);
            List<Node> actual_nodes = custom_list.ToList();

            CollectionAssert.AreEqual(expected_nodes, actual_nodes);
            Assert.AreEqual(n1, custom_list.head);
            Assert.AreEqual(insert_node_2, custom_list.tail);
        }
    }
    
    [TestClass]
    public class Clear: BaseTest
    {
        [TestInitialize]
        public override void InitList()
        {
            base.InitList();
        }
        [TestMethod]
        public void ClearEmptyList()
        {
            List<Node> expected_nodes = new List<Node>();

            empty_list.Clear();
            List<Node> actual_nodes = empty_list.ToList();

            CollectionAssert.AreEqual(expected_nodes, actual_nodes);
            Assert.AreEqual(null, empty_list.head);
            Assert.AreEqual(null, empty_list.tail);
        }
        [TestMethod]
        public void ClearSimpleList()
        {
            List<Node> expected_nodes = new List<Node>();

            simple_list.Clear();
            List<Node> actual_nodes = simple_list.ToList();

            CollectionAssert.AreEqual(expected_nodes, actual_nodes);
            Assert.AreEqual(null, simple_list.head);
            Assert.AreEqual(null, simple_list.tail);
        }
        [TestMethod]
        public void ClearSingleList()
        {
            List<Node> expected_nodes = new List<Node>();

            single_node_list.Clear();
            List<Node> actual_nodes = single_node_list.ToList();

            CollectionAssert.AreEqual(expected_nodes, actual_nodes);
            Assert.AreEqual(null, single_node_list.head);
            Assert.AreEqual(null, single_node_list.tail);
        }
    }
    
    [TestClass]
    public class FindAll: BaseTest
    {
        [TestInitialize]
        public override void InitList()
        {
            base.InitList();
        }
        [TestMethod]
        public void FindAllEmptyList()
        {
            List<Node> expected_nodes = new List<Node>();

            int search_value = new System.Random().Next();
            List<Node> actual_nodes = empty_list.FindAll(search_value);

            CollectionAssert.AreEqual(expected_nodes, actual_nodes);
            Assert.AreEqual(null, empty_list.head);
            Assert.AreEqual(null, empty_list.tail);
        }
        [TestMethod]
        public void FindAllSingleList()
        {
            List<Node> expected_nodes = new List<Node> { single_node };

            int search_value = single_node.value;
            List<Node> actual_nodes = single_node_list.FindAll(search_value);

            CollectionAssert.AreEqual(expected_nodes, actual_nodes);
            Assert.AreEqual(single_node, single_node_list.head);
            Assert.AreEqual(single_node, single_node_list.tail);
        }
        [TestMethod]
        public void FindAllCustomList()
        {
            n1 = new Node(1);
            n2 = new Node(2);
            n3 = new Node(2);
            n4 = new Node(53);
            n5 = new Node(2);

            custom_list = new LinkedList(new List<Node> { n1, n2, n3, n4, n5 });
            List<Node> expected_nodes = new List<Node> { n2, n3, n5 };

            int search_value = n2.value;
            List<Node> actual_nodes = custom_list.FindAll(search_value);

            CollectionAssert.AreEqual(expected_nodes, actual_nodes);
            Assert.AreEqual(n1, custom_list.head);
            Assert.AreEqual(n5, custom_list.tail);
        }
    }

    [TestClass]
    public class Count : BaseTest
    {
        [TestInitialize]
        public override void InitList()
        {
            base.InitList();
        }
        [TestMethod]
        public void CountEmptyList()
        {
            int expected_value = 0;

            int actual_value = empty_list.Count();

            Assert.AreEqual(expected_value, actual_value);
        }
        [TestMethod]
        public void CountSingleList()
        {
            int expected_value = 1;

            int actual_value = single_node_list.Count();

            Assert.AreEqual(expected_value, actual_value);
        }
        [TestMethod]
        public void CountSimpleList()
        {
            int expected_value = 3;

            int actual_value = simple_list.Count();

            Assert.AreEqual(expected_value, actual_value);
        }
    }
}
