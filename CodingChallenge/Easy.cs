using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace CodingChallenge {
    class Easy
    {
        /*
            Smallest N digit number which is a multiple of 5
            Given an integer N ≥ 1, the task is to find the smallest N digit number which is a multiple of 5.
            examples: f(1) = 5, f(2) = 10, f(3) = 100
        */

        /// <summary>
        /// Finds the smallest N digit number which is a multiple of 5.
        /// </summary>
        /// <param name="n">The number of digits.</param>
        /// <returns>The smallest N digit number which is a multiple of 5.</returns>
        public static int SmallestMultipleOf5(int n)
        {
            if (n == 1) return 5;
            else return (int)Math.Pow(10, n - 1);
        }

        /*
            Remove elements to make array sorted
            Given an array of integers, the task is to remove elements from the array to make array sorted. 
            That is, remove the elements which do not follow an increasing order.
         */

        public static void RemoveElementsToMakeSorted()
        {
            var a = new int[] { 1, 2, 4, 3, 5, 7, 8, 6, 9, 10 };
            Console.WriteLine($"{a.ToStringX()} sorted is {RemoveElementsToMakeSorted(a).ToStringX()}");
        }

        private static int[] RemoveElementsToMakeSorted(int[] a)
        {
            var l = new List<int>() { a[0] };
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > a[i - 1])
                    l.Add(a[i]);
            }
            return l.ToArray();
        }

        /*
         Given 2 arrays which are sorted and unique, find common elements
        */
        static int[] a1, a2;
        static int tick;

        public static void GetArrays(int len, int min, int max, out int[] a1, out int[] a2)
        {
            a1 = Utils.GetIntArray2(len, min, max);
            a2 = Utils.GetIntArray2(len, min, max);
        }

        public static void Get2Arrays(int len, int min, int max)
        {
            GetArrays(len, min, max, out a1, out a2);
        }

        /// <summary>
        /// Find Common Elements From 2 sorted Arrays
        /// This is O(A log B) for each element in array A, it searches through remaining elements in array B
        /// </summary>
        public static void FindCommonElementsFrom2sortedArrays()
        {
            var result = FindCommonElementsFrom2sortedArrays(a1, a2);
            Console.WriteLine($"a1:{a1.ToStringX()}\na2:{a2.ToStringX()}");
            Console.WriteLine($"F1:elements in common:  {result.ToStringX()}, ticks:{tick}");
        }


        /// <summary>
        /// Find the common elements from two sorted arrays.
        /// </summary>
        /// <param name="a1">The first sorted array.</param>
        /// <param name="a2">The second sorted array.</param>
        /// <returns>A list of common elements.</returns>
        private static List<int> FindCommonElementsFrom2sortedArrays(int[] a1, int[] a2)
        {
            var result = new List<int>();
            var k = 0;
            tick = 0;
            for (int i = 0; i < a1.Length; i++)
            {
                var x = a1[i];
                for (int j = k; j < a2.Length; j++)
                {
                    if (a2[j] == x)
                    {
                        result.Add(x);
                        k = j;
                        break;
                    }
                    tick++;
                    if (k == a2.Length) break;
                }
            }
            return result;
        }

        /// <summary>
        /// Find Common Elements From 2 sorted Arrays
        /// This is O(A + log B)
        /// This is much more efficient as it walks the arrays in parallel
        /// </summary>
        public static void FindCommonElementsFrom2sortedArrays2()
        {
            var result = FindCommonElementsFrom2sortedArrays2(a1, a2);
            Console.WriteLine($"a1:{a1.ToStringX()}\na2:{a2.ToStringX()}");
            Console.WriteLine($"F1:elements in common:  {result.ToStringX()}, ticks:{tick}");
        }


        /// <summary>
        /// Find the common elements from two sorted arrays.
        /// </summary>
        /// <param name="a1">The first sorted array.</param>
        /// <param name="a2">The second sorted array.</param>
        /// <returns>A list of common elements.</returns>
        private static List<int> FindCommonElementsFrom2sortedArrays2(int[] a1, int[] a2)
        {
            var commonElements = new List<int>();
            int i1 = 0, i2 = 0;
            int e1, e2;
            while (i1 < a1.Length && i2 < a2.Length)
            {
                e1 = a1[i1];
                e2 = a2[i2];
                if (e1 < e2) i1++;
                else if (e1 > e2) i2++;
                else
                {
                    commonElements.Add(e1);
                    i1++;
                    i2++;
                }
            }
            return commonElements;
        }

    }
}
