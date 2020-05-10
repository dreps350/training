using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsDataStructures
{
    [TestClass]
    public class UnitTest1
    {
        Stack<object> stack;
        LinkedList<int> patchList;
        [TestInitialize]
        public void TestInitialize()
        {
            stack = new Stack<object>();
            patchList = new LinkedList<int>();
        }
        [TestMethod]
        public void PushNonEmpty()
        {
            object[] values = { 1, 2, 3 };
            stack.innerList = new LinkedList<object>(values);

            stack.Push(4);

            int[] expectedValues = { 1, 2, 3, 4 };
            CollectionAssert.AreEqual(new LinkedList<int>(expectedValues), stack.innerList);
        }
        [TestMethod]
        public void PushDifferentType()
        {
            object[] values = { 1, 2, 3 };
            stack.innerList = new LinkedList<object>(values);

            stack.Push('a');

            var expectedList = new LinkedList<object>(values);
            expectedList.AddLast('a');
            CollectionAssert.AreEqual(expectedList, stack.innerList);

        }
        [TestMethod]
        public void PushEmpty()
        {
            stack.Push('a');

            char[] expectedValues = { 'a' };
            var expectedList = new LinkedList<char>(expectedValues);
            
            CollectionAssert.AreEqual(expectedList, stack.innerList);
        }

        [TestMethod]
        public void PopEmpty()
        {
            object result = stack.Pop();

            Assert.AreEqual(null, result);
        }
        [TestMethod]
        public void PopSingleValue()
        {
            object[] values = { 1 };
            stack.innerList = new LinkedList<object>(values);

            object result = stack.Pop();

            Assert.AreEqual(values[0], result);

            result = stack.Pop();
            Assert.AreEqual(null, result);
        }
        [TestMethod]
        public void PushAndPopString()
        {
            object[] values = { 1, 2 };
            stack.innerList = new LinkedList<object>(values);
            var pushValue = "hello";

            stack.Push(pushValue);
            var popValue = stack.Pop();

            Assert.AreEqual(pushValue, popValue);
        }

        [TestMethod]
        public void PushAndPopNull()
        {
            object[] values = { null, null };
            stack.innerList = new LinkedList<object>(values);
            object pushValue = null;

            stack.Push(pushValue);
            var popValue = stack.Pop();

            Assert.AreEqual(pushValue, popValue);
        }


        //[DataTestMethod]
        //public void SizeTest()
        //{
        //    Assert.AreEqual(stack.Size(), 0);

        //    stack.Push()
        //}
    }
}
