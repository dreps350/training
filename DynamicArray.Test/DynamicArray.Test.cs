using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsDataStructures
{
    public class BaseTest
    {
        public DynArray<int> arr;

        public int[] BaseArray32 = Enumerable.Range(1, 32).ToArray();
        public int[] ExpectedArr;

        public Random rand = new Random();

        [TestInitialize]
        public void TestInitialize()
        {
            arr = new DynArray<int>();
        }
        public void MockActualArr(int count, int capacity)
        {
            MockActualArr(count, capacity, -1);
        }
        public void MockActualArr(int count, int capacity, int SkipIndex)
        {
            arr.array = new int[capacity];
            FillArray(arr.array, count, SkipIndex);
            arr.count = count;
            arr.capacity = capacity;
        }
        public void MockExpectedArr(int count, int capacity)
        {
            MockExpectedArr(count, capacity, -1);
        }
        public void MockExpectedArr(int count, int capacity, int SkipIndex)
        {
            ExpectedArr = new int[capacity];
            FillArray(ExpectedArr, count, SkipIndex);
        }
        public void FillArray(int[] array, int length, int SkipIndex)
        {
            if (SkipIndex != -1)
            {
                int[] ArrayToCopy = BaseArray32.Where((val, idx) => idx != SkipIndex).ToArray();
                Array.Copy(ArrayToCopy, 0, array, 0, length);
            }
            else
            {
                Array.Copy(BaseArray32, 0, array, 0, length);
            }
        }

        public void MakeAssertions()
        {
            MakeAssertions(0, 16);
        }
        public void MakeAssertions(int Count, int Capacity)
        {
            Assert.AreEqual(arr.count, Count);
            Assert.AreEqual(arr.capacity, Capacity);
        }
        public void MakeAssertions(int[] ExpectedArray, int Count, int Capacity)
        {
            Console.WriteLine(String.Join(" ", ExpectedArray));
            Console.WriteLine(arr);
            CollectionAssert.AreEqual(ExpectedArr, arr.array);
            MakeAssertions(Count, Capacity);
        }
    }
    [TestClass]
    public class TestMakeArray: BaseTest
    {
        [DataTestMethod]
        [DataRow(0, 16, 32)]
        [DataRow(10, 16, 32)]
        [DataRow(20, 32, 21)]
        public void TestChangeCapacity(int count, int CapacityBefore, int CapacityAfter)
        {
            MakeAssertions();

            MockActualArr(count: count, capacity: CapacityBefore);
            MockExpectedArr(count, CapacityAfter);
            
            arr.MakeArray(CapacityAfter);

            MakeAssertions(ExpectedArr, count, CapacityAfter);
        }
    }

    [TestClass]
    public class TestReallocate : BaseTest
    {
        [DataTestMethod]
        [DataRow(0, 16, 16)]
        [DataRow(9, 16, 16)]
        [DataRow(10, 16, 16)]
        [DataRow(15, 16, 16)]
        [DataRow(16, 16, 32)]
        [DataRow(31, 32, 32)]
        [DataRow(16, 32, 32)]
        [DataRow(15, 32, 21)]
        [DataRow(11, 21, 21)]
        [DataRow(10, 21, 16)]
        public void TestReallocate_(int count, int CapacityBefore, int CapacityAfter)
        {
            MakeAssertions();

            MockActualArr(count: count, capacity: CapacityBefore);
            MockExpectedArr(count, CapacityAfter);

            arr.Reallocate();

            MakeAssertions(ExpectedArr, count, CapacityAfter);
        }

    }

    [TestClass]
    public class TestGetItem : BaseTest
    {
        [DataTestMethod]
        [DataRow(0, 16, 0, true)]
        [DataRow(10, 16, 0, false)]
        [DataRow(10, 16, 9, false)]
        [DataRow(10, 16, 10, true)]
        public void TestGetItem_(int count, int capacity, int index, bool IsOutOfRange)
        {
            MakeAssertions();

            MockActualArr(count, capacity);

            if (IsOutOfRange)
            {
                Assert.ThrowsException<IndexOutOfRangeException>(() => arr.GetItem(index));
            }
            else
            {
                int item = arr.GetItem(index);
                Assert.AreEqual(BaseArray32.GetValue(index), item);
            }
        }
    }

    [TestClass]
    public class TestAppend : BaseTest
    {
        [DataTestMethod]
        [DataRow(0, 16, 1, 16)]
        [DataRow(15, 16, 16, 16)]
        [DataRow(16, 16, 17, 32)]
        public void TestAppend_(int CountBefore, int CapacityBefore, int CountAfter, int CapacityAfter)
        {
            MockActualArr(CountBefore, CapacityBefore);
            MockExpectedArr(CountAfter, CapacityAfter);

            int AppendValue = (int)BaseArray32.GetValue(CountAfter - 1);
            arr.Append(AppendValue);

            MakeAssertions(ExpectedArr, CountAfter, CapacityAfter);
        }
    }

    [TestClass]
    public class TestInsert : BaseTest
    {
        [DataTestMethod]
        [DataRow(0, 16, 1, 16, 0, false)]
        [DataRow(15, 16, 16, 16, 0, false)]
        [DataRow(15, 16, 16, 16, 4, false)]
        [DataRow(15, 16, 16, 16, 16, true)]
        [DataRow(16, 16, 17, 32, 16, false)]
        public void TestInsert_(int CountBefore, int CapacityBefore, int CountAfter, int CapacityAfter, int index, bool IsOutOfRange)
        {
            MockActualArr(CountBefore, CapacityBefore, index);
            MockExpectedArr(CountAfter, CapacityAfter);

            Console.WriteLine(arr);

            int InsertValue = BaseArray32[index];
            
            if (IsOutOfRange)
            {
                Assert.ThrowsException<IndexOutOfRangeException>(() => arr.Insert(InsertValue, index));
            }
            else
            {
                arr.Insert(InsertValue, index);
                MakeAssertions(ExpectedArr, CountAfter, CapacityAfter);
            }
        }
    }

    [TestClass]
    public class TestRemove : BaseTest
    {
        [DataTestMethod]
        [DataRow(0, 16, 0, 16, 0, true)]
        [DataRow(1, 16, 0, 16, 0, false)]
        [DataRow(10, 16, 9, 16, 4, false)]
        [DataRow(9, 16, 8, 16, 4, false)]
        [DataRow(22, 32, 21, 32, 16, false)]
        [DataRow(16, 32, 15, 21, 16, true)]
        [DataRow(16, 32, 15, 21, 15, false)]
        public void TestRemove_(int CountBefore, int CapacityBefore, int CountAfter, int CapacityAfter, int index, bool IsOutOfRange)
        {
            MockActualArr(CountBefore, CapacityBefore);
            MockExpectedArr(CountAfter, CapacityAfter, index);

            Console.WriteLine(arr);

            if (IsOutOfRange)
            {
                Assert.ThrowsException<IndexOutOfRangeException>(() => arr.Remove(index));
            }
            else
            {
                arr.Remove(index);
                MakeAssertions(ExpectedArr, CountAfter, CapacityAfter);
            }
        }
    }
}
