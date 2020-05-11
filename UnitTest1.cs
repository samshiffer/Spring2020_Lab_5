using BinaryHeapLib;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab5
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CountEqualsZeroAfterInitializing()
        {
            var heap = new BinaryHeap<int>();

            Assert.AreEqual(0, heap.Count);
        }

        [TestMethod]
        public void CountWorksProperly()
        {
            var heap = new BinaryHeap<int>();

            heap.Add(1);
            heap.Add(23);

            Assert.AreEqual(2, heap.Count);
        }

        [TestMethod]
        public void CountWorksProperlyAfterDeleting()
        {
            var heap = new BinaryHeap<int>();

            heap.Add(1);
            heap.Add(23);
            heap.ReturnRoot();

            Assert.AreEqual(1, heap.Count);
        }

        [TestMethod]
        public void CountAfterBuildingHeapWorksProperly()
        {
            var heap = new BinaryHeap<int>();

            var numbers = new[] { 4, 8, 15, 16, 23, 42, -20, 5928, 1337 };

            heap.BuildHeap(numbers);

            Assert.AreEqual(numbers.Length, heap.Count);
        }

        [TestMethod]
        public void FindRootWorksProperly()
        {
            var heap = new BinaryHeap<int>();

            var numbers = new[] { 4, 8, 15, 16, 23, 42, -20, 5928, 1337 };

            heap.BuildHeap(numbers);


            Assert.AreEqual(numbers.Max(), heap.FindRoot());
        }

        [TestMethod]
        public void MinimalHeapWorksProperly()
        {
            var heap = new BinaryHeap<int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

            var numbers = new[] { 4, 8, 15, 16, 23, 42, -20, 5928, 1337 };

            heap.BuildHeap(numbers);

            Assert.AreEqual(numbers.Min(), heap.FindRoot());
        }

        [TestMethod]
        public void BuildHeapWorksProperly()
        {
            var heap = new BinaryHeap<int>();

            var numbers = new[] { 4, 8, 15, 16, 23, 42, -20, 5928, 1337 };

            heap.BuildHeap(numbers);

            Array.Sort(numbers);
            Array.Reverse(numbers);

            foreach (var item in numbers)
                Assert.AreEqual(item, heap.ReturnRoot());
        }

        [TestMethod]
        public void BuildHeapWithMinimalHeapWorksProperly()
        {
            var heap = new BinaryHeap<int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

            var numbers = new[] { 4, 8, 15, 16, 23, 42, -20, 5928, 1337 };

            heap.BuildHeap(numbers);

            Array.Sort(numbers);

            foreach (var item in numbers)
                Assert.AreEqual(item, heap.ReturnRoot());
        }

        [TestMethod]
        public void FindRootAfterReturnRootWorksProperly()
        {
            var heap = new BinaryHeap<int>();

            var numbers = new[] { 4, 8, 15, 16, 23, 42, -20, 5928, 1337 };

            heap.BuildHeap(numbers);

            Assert.AreEqual(numbers.Max(), heap.ReturnRoot());
            Assert.AreEqual(1337, heap.FindRoot());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void InvalidOperationExceptionAfterFindingRootInEmptyHeap()
        {
            var heap = new BinaryHeap<int>();
            heap.FindRoot();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void InvalidOperationExceptionAfterReturningRootInEmptyHeap()
        {
            var heap = new BinaryHeap<int>();
            heap.ReturnRoot();
        }
    }
}
