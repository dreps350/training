using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsDataStructures
{
    [TestClass]
    public class UnitTest1
    {
        Stack<int> stack;
        LinkedList<int> patchList;
        [TestInitialize]
        public void TestInitialize()
        {
            stack = new Stack<int>();
            patchList = new LinkedList<int>();
        }
        [TestMethod]
        public void PushTest()
        {
            int[] values = { 1, 2, 3 };
            stack.innerList = new LinkedList<int>(values);

            stack.Push(4);

            CollectionAssert.AreEqual(new LinkedList<int>(values), new LinkedList<int>(values));
        }

        //[DataTestMethod]
        //public void SizeTest()
        //{
        //    Assert.AreEqual(stack.Size(), 0);

        //    stack.Push()
        //}
    }
}
