using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BinaryHeapLib;

namespace BinaryHeap
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const int n = 100000; 

            var unsortedWithRepeats = GenerateUnsortedWithRepeats(n);
            Action action = () => SelectionSort(unsortedWithRepeats); 
            Console.WriteLine("Время сортировки методом выбора несортированного множества с повторениями: " + RunStopwatch(action));

            unsortedWithRepeats = GenerateUnsortedWithRepeats(n);
            action = () => InsertionSort(unsortedWithRepeats);
            Console.WriteLine("Время сортировки методом вставок несортированного множества с повторениями: " + RunStopwatch(action));

            var binaryHeap = new BinaryHeap<int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
            unsortedWithRepeats = GenerateUnsortedWithRepeats(n);
            action = () => binaryHeap.BuildHeap(unsortedWithRepeats);
            Console.WriteLine("Время пирамидальной сортировки несортированного множества с повторениями: " + RunStopwatch(action));

            Console.WriteLine("\n******************************\n");

            var unsortedWithoutRepeats = GenerateUnsortedWithoutRepeats(n);
            action = () => SelectionSort(unsortedWithoutRepeats);
            Console.WriteLine("Время сортировки методом выбора несортированного множества без повторений: " + RunStopwatch(action));

            unsortedWithoutRepeats = GenerateUnsortedWithoutRepeats(n);
            action = () => InsertionSort(unsortedWithoutRepeats);
            Console.WriteLine("Время сортировки методом вставок несортированного множества без повторений: " + RunStopwatch(action));

            binaryHeap = new BinaryHeap<int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
            unsortedWithoutRepeats = GenerateUnsortedWithoutRepeats(n);
            action = () => binaryHeap.BuildHeap(unsortedWithoutRepeats);
            Console.WriteLine("Время пирамидальной сортировки несортированного множества без повторений: " + RunStopwatch(action));

            Console.WriteLine("\n******************************\n");

            var sorted = GenerateSorted(n);
            action = () => SelectionSort(sorted);
            Console.WriteLine("Время сортировки методом выбора сортированного множества: " + RunStopwatch(action));

            sorted = GenerateSorted(n);
            action = () => InsertionSort(sorted);
            Console.WriteLine("Время сортировки методом вставок сортированного множества: " + RunStopwatch(action));

            binaryHeap = new BinaryHeap<int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
            sorted = GenerateSorted(n);
            action = () => binaryHeap.BuildHeap(sorted);
            Console.WriteLine("Время пирамидальной сортировки сортированного множества: " + RunStopwatch(action));

            Console.WriteLine("\n******************************\n");

            var partiallySorted = GeneratePartiallySorted(n);
            action = () => SelectionSort(partiallySorted);
            Console.WriteLine("Время сортировки методом выбора частично отсортированного множества: " + RunStopwatch(action));

            partiallySorted = GeneratePartiallySorted(n);
            action = () => InsertionSort(partiallySorted);
            Console.WriteLine("Время сортировки методом вставок частично отсортированного множества: " + RunStopwatch(action));

            binaryHeap = new BinaryHeap<int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
            partiallySorted = GeneratePartiallySorted(n);
            action = () => binaryHeap.BuildHeap(partiallySorted);
            Console.WriteLine("Время пирамидальной сортировки частично отсортированного множества: " + RunStopwatch(action));

        }

        static int[] SelectionSort(int[] array)
        {
            for (var i = 0; i < array.Length - 1; i++)
            {
                var min = array[i];
                var index = i;
                for (var j = i + 1; j < array.Length; j++)
                {
                    if (array[j] >= min) 
                        continue;
                    min = array[j];
                    index = j;
                }
                array[index] = array[i];
                array[i] = min;
            }
            return array;
        }

        static int[] InsertionSort(int[] array)
        {
            for (var i = 1; i < array.Length; i++)
            {
                var j = i;
                var item = array[i];
                while (j >= 1 && item < array[j - 1])
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = item;
            }
            return array;
        }



        private static int[] GenerateUnsortedWithoutRepeats(int n)
        {
            var randomSet = new HashSet<int>();
            var rd = new Random();

            for (var i = 0; i < n; i++)
                while (!randomSet.Add(rd.Next(0, n)));

            return randomSet.ToArray();
        }

        private static int[] GenerateUnsortedWithRepeats(int n)
        {
            var randomSet = new List<int>();
            var rd = new Random();

            for (var i = 0; i < n; i++)
                randomSet.Add(rd.Next(-n, n));

            return randomSet.ToArray();
        }

        private static int[] GenerateSorted(int n)
        {
            var randomSet = new List<int>();
            var rd = new Random();

            for (var i = 0; i < n; i++)
                randomSet.Add(rd.Next(-n, n));

            var array = randomSet.ToArray();
            Array.Sort(array);

            return array;
        }

        private static int[] GeneratePartiallySorted(int n)
        {
            var array = new int[n];
            var rd = new Random();

            for (var i = 0; i < n/2 ; i++) 
                array[i] = i; 

            for (var i = n / 2; i < n; i++)
                array[i] = rd.Next(-n, n);
            

            return array;
        }

        private static long RunStopwatch(Action action)
        {
            var sw = new Stopwatch();

            sw.Start();
            action();
            sw.Stop();

            return sw.ElapsedMilliseconds;
        }

    }
}
