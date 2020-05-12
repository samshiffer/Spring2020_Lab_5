using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryHeapLib
{
    public class BinaryHeap<T>
    {
        private List<T> _list;
        private readonly IComparer<T> _comparer;

        public BinaryHeap() : this(Comparer<T>.Default) { }

        public BinaryHeap(IComparer<T> comparer)
        {
            Count = 0;
            _list = new List<T>();
            _comparer = comparer ?? throw new ArgumentNullException();
        }

        public int Count;

        public void Add(T item)
        {
            _list.Add(item);
            Count++;
            HeapifyOnAdding(Count - 1);
        }

        private void HeapifyOnAdding(int index)
        {
            while (true)
            {
                if (index >= _list.Count)
                    return;

                var parent = (index - 1) / 2;
                if (_comparer.Compare(_list[index], _list[parent]) > 0)
                    Heapify(parent);
                else
                    return;
                index = parent;
            }
        }

        public T ReturnRoot()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException();

            var root = _list[0];
            _list[0] = _list[Count - 1];
            _list[Count - 1] = root;
            Count--;

            Heapify(0);

            return root;
        }

        public T FindRoot()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException();

            return _list[0];
        }

        public void Heapify(int index)
        {
            while (true)
            {
                var left = 2 * index + 1;
                var right = 2 * index + 2;
                var largest = index;
                if (left < Count && _comparer.Compare(_list[left], _list[index]) > 0)
                    largest = left;
                if (right < Count && _comparer.Compare(_list[right], _list[largest]) > 0)
                    largest = right;

                if (largest == index) return;

                var temp = _list[largest];
                _list[largest] = _list[index];
                _list[index] = temp;
                index = largest;
            }
        }

        public void BuildHeap(T[] sourceArray)
        {
            _list = sourceArray.ToList();
            Count = sourceArray.Length;
            Restore();
        }
        
        public T[] HeapSort (T[] array)
        {
            BuildHeap(array);

            while (Count > 0)
            {
                ReturnRoot();
            }

            return _list.ToArray();
        }

        private void Restore()
        {
            for (var i = (Count - 1) / 2; i >= 0; i--)
            {
                Heapify(i);
            }
        }
    }
}