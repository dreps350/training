using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// add prev asserts
namespace AlgorithmsDataStructures
{
    public class BaseTest
    {
        public LinkedList2 custom_list;
        public LinkedList2 empty_list;
        public LinkedList2 single_node_list;
        public LinkedList2 all_same_nodes_list;
        public LinkedList2 simple_list;
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
            custom_list = new LinkedList2();
            empty_list = new LinkedList2();

            single_node_list = new LinkedList2();
            single_node_list.AddInTail(single_node);
            
            all_same_nodes_list = new LinkedList2(new List<Node> { all_same_node_1, all_same_node_2, all_same_node_3 });

            simple_list = new LinkedList2(new List<Node> { simple_node_1, simple_node_2, simple_node_3 });
        }

        public void MakeAssertions(
            LinkedList2 list, 
            List<Node> expected_nodes, 
            List<Node> expected_inversed_nodes, 
            Node expected_head, 
            Node expected_tail
            )
        {
            List<Node> actual_nodes = list.ToList();
            List<Node> actual_inversed_nodes = list.ToInversedList();

            CollectionAssert.AreEqual(expected_nodes, actual_nodes);
            CollectionAssert.AreEqual(expected_inversed_nodes, actual_inversed_nodes);
            Assert.AreEqual(expected_head, list.head);
            Assert.AreEqual(expected_tail, list.tail);
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

            Assert.AreEqual(false, result);
            MakeAssertions(empty_list, expected_nodes, expected_nodes, null, null);
        }
        [TestMethod]
        public void RemoveSingle()
        {
            List<Node> expected_nodes = new List<Node>();

            bool result = single_node_list.Remove(single_node.value);

            Assert.AreEqual(true, result);
            MakeAssertions(single_node_list, expected_nodes, expected_nodes, null, null);
        }
        [TestMethod]
        public void RemoveSameValues()
        {
            List<Node> expected_nodes = new List<Node> { all_same_node_2, all_same_node_3 };
            List<Node> expected_inversed_nodes = new List<Node> { all_same_node_3, all_same_node_2 };

            bool result = all_same_nodes_list.Remove(all_same_node_1.value);

            Assert.AreEqual(true, result);
            MakeAssertions(all_same_nodes_list, expected_nodes, expected_inversed_nodes, all_same_node_2, all_same_node_3);
        }
        [TestMethod]
        public void RemoveHead()
        {
            List<Node> expected_nodes = new List<Node> { n2, n3 };
            List<Node> expected_inversed_nodes = new List<Node> { n3, n2 };

            bool result = custom_list.Remove(n1.value);
            
            Assert.AreEqual(true, result);
            MakeAssertions(custom_list, expected_nodes, expected_inversed_nodes, n2, n3);
        }
        [TestMethod]
        public void RemoveTail()
        {
            List<Node> expected_nodes = new List<Node> { n1, n2 };
            List<Node> expected_inversed_nodes = new List<Node> { n2, n1 };

            bool result = custom_list.Remove(n3.value);

            Assert.AreEqual(true, result);
            MakeAssertions(custom_list, expected_nodes, expected_inversed_nodes, n1, n2);
        }
        [TestMethod]
        public void RemoveMiddle()
        {
            List<Node> expected_nodes = new List<Node> { n1, n3 };
            List<Node> expected_inversed_nodes = new List<Node> { n3, n1 };

            bool result = custom_list.Remove(n2.value);

            Assert.AreEqual(true, result);
            MakeAssertions(custom_list, expected_nodes, expected_inversed_nodes, n1, n3);
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
            custom_list = new LinkedList2(new List<Node> { n1, n2, n3, n4, n5, n6, n7 });
        }
        [TestMethod]
        public void RemoveAllEmpty()
        {
            List<Node> expected_nodes = new List<Node>();

            empty_list.RemoveAll(1);

            MakeAssertions(empty_list, expected_nodes, expected_nodes, null, null);
        }
        [TestMethod]
        public void RemoveSingle()
        {
            List<Node> expected_nodes = new List<Node>();

            single_node_list.RemoveAll(single_node.value);

            MakeAssertions(single_node_list, expected_nodes, expected_nodes, null, null);
        }
        [TestMethod]
        public void RemoveSameValues()
        {
            List<Node> expected_nodes = new List<Node>();

            all_same_nodes_list.RemoveAll(all_same_node_1.value);

            MakeAssertions(all_same_nodes_list, expected_nodes, expected_nodes, null, null);
        }
        [TestMethod]
        public void RemoveHead()
        {
            List<Node> expected_nodes = new List<Node> { n3, n4, n5, n6, n7 };
            List<Node> expected_inversed_nodes = new List<Node> { n7, n6, n5, n4, n3 };

            custom_list.RemoveAll(n1.value);

            MakeAssertions(custom_list, expected_nodes, expected_inversed_nodes, n3, n7);
        }
        [TestMethod]
        public void RemoveTail()
        {
            List<Node> expected_nodes = new List<Node> { n1, n2, n4, n5, n6 };
            List<Node> expected_inversed_nodes = new List<Node> { n6, n5, n4, n2, n1 };

            custom_list.RemoveAll(n7.value);

            MakeAssertions(custom_list, expected_nodes, expected_inversed_nodes, n1, n6);
        }
        [TestMethod]
        public void RemoveMiddle()
        {
            List<Node> expected_nodes = new List<Node> { n1, n2, n3, n5, n7 };
            List<Node> expected_inversed_nodes = new List<Node> { n7, n5, n3, n2, n1 };
            
            custom_list.RemoveAll(n4.value);

            MakeAssertions(custom_list, expected_nodes, expected_inversed_nodes, n1, n7);
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
            custom_list = new LinkedList2(new List<Node> { n1, n2, n3 });
        }
        [TestMethod]
        public void InsertAfterEmptyList()
        {
            List<Node> expected_nodes = new List<Node> { insert_node };

            empty_list.InsertAfter(null, insert_node);

            MakeAssertions(empty_list, expected_nodes, expected_nodes, insert_node, insert_node);
        }
        [TestMethod]
        public void InsertAfterSingleListLeft()
        {
            List<Node> expected_nodes = new List<Node> { insert_node, single_node };
            List<Node> expected_inversed_nodes = new List<Node> { single_node, insert_node };

            single_node_list.InsertAfter(null, insert_node);

            MakeAssertions(single_node_list, expected_nodes, expected_inversed_nodes, insert_node, single_node);
        }
        [TestMethod]
        public void InsertAfterSingleListRight()
        {
            List<Node> expected_nodes = new List<Node> { single_node, insert_node };
            List<Node> expected_inversed_nodes = new List<Node> { insert_node, single_node};

            single_node_list.InsertAfter(single_node, insert_node);

            MakeAssertions(single_node_list, expected_nodes, expected_inversed_nodes, single_node, insert_node);
        }
        [TestMethod]
        public void InsertAfterMultipleLeft()
        {
            List<Node> expected_nodes = new List<Node> { insert_node, insert_node_2, n1, n2, n3 };
            List<Node> expected_inversed_nodes = new List<Node> { n3, n2, n1, insert_node_2, insert_node};

            custom_list.InsertAfter(null, insert_node_2);
            custom_list.InsertAfter(null, insert_node);

            MakeAssertions(custom_list, expected_nodes, expected_inversed_nodes, insert_node, n3);
        }
        [TestMethod]
        public void InsertAfterMultipleRight()
        {
            List<Node> expected_nodes = new List<Node> { n1, n2, n3, insert_node, insert_node_2 };
            List<Node> expected_inversed_nodes = new List<Node> { insert_node_2, insert_node, n3, n2, n1 };

            custom_list.InsertAfter(n3, insert_node);
            custom_list.InsertAfter(insert_node, insert_node_2);

            MakeAssertions(custom_list, expected_nodes, expected_inversed_nodes, n1, insert_node_2);
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

            MakeAssertions(empty_list, expected_nodes, expected_nodes, null, null);
        }
        [TestMethod]
        public void ClearSimpleList()
        {
            List<Node> expected_nodes = new List<Node>();

            simple_list.Clear();

            MakeAssertions(simple_list, expected_nodes, expected_nodes, null, null);
        }
        [TestMethod]
        public void ClearSingleList()
        {
            List<Node> expected_nodes = new List<Node>();

            single_node_list.Clear();

            MakeAssertions(single_node_list, expected_nodes, expected_nodes, null, null);
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

            custom_list = new LinkedList2(new List<Node> { n1, n2, n3, n4, n5 });
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
