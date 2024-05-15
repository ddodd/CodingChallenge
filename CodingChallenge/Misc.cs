using System.Collections.Generic;
using System;
using System.Linq;

namespace CodingChallenge {
    class Misc {
        public static void FlipBits() {
            foreach (var n in new[] { 2147483647, 1, 0 }) {
                System.Console.WriteLine($"{n} flipped is {FlipBits(n)}");
            }
            foreach (var n in new[] { 4, 123456 }) {
                System.Console.WriteLine($"{n} flipped is {FlipBits(n)}");
            }
            foreach (var n in new[] { 0, 802743475, 35601423 }) {
                System.Console.WriteLine($"{n} flipped is {FlipBits(n)}");
            }
        }

        private static long FlipBits(long n) {
            return uint.MaxValue - n;
        }

        public static void IsPrime() {
            foreach (var n in new[] { 25, 17, 49, 8132 }) {
                System.Console.WriteLine($"IsPrime({n}) = {IsPrime(n)}");
            }
        }

        private static string IsPrime(int n) {
            string notPrime = "Not prime";
            if (n == 1) return notPrime;
            for (var i = 2; i * i <= n; i++) {
                if (n % i == 0) return notPrime;
            }
            return "Prime";
        }

        /*
         Merge K sorted arrays of different sizes | ( Divide and Conquer Approach )
            Given k sorted arrays of different length, merge them into a single array such that the merged array is also sorted.

            Examples:

            Input : {{3, 13}, 
                    {8, 10, 11}
                    {9, 15}}
            Output : {3, 8, 9, 10, 11, 13, 15}

            Input : {{1, 5}, 
                     {2, 3, 4}}
            Output : {1, 2, 3, 4, 5}* 
         */

        public static void MergeMultipleArrays() {
            var list = new List<string>() {
                "3 13",
                "5 6 8 10 11",
                "9 15",
                "1 2",
                "4 7 12 14",
                "13 15 17 19",
                "16 18 20"
            };
            var arr = new int[list.Count][];
            for (var i = 0; i < list.Count; i++) {
                arr[i] = list[i].ToArray<int>();
            }
            var result = MergeMultipleArrays(arr);
            var unique = new HashSet<int>(result).ToArray();
            Console.WriteLine($"Given : {list.ToStringX()}\nSorted: {result.ToStringX()}\nUnique: {unique.ToStringX()}");
        }

        private static int[] MergeMultipleArrays(int[][] arrays) {
            int total = 0;
            foreach (var a in arrays) {
                total += a.Length;
            }
            int[] sorted = new int[total];
            int[] indices = new int[arrays.Length]; // keep unique pointer for each array
            int l = 0;
            while (l < total) {
                int min = int.MaxValue;
                int minIndex = 0;
                // loop through the values pointed to by the indices, finding the minimum value and the index at which it occurred
                for (int i = 0; i < arrays.Length; i++) {
                    // if the pointer is within range and its value is less than the current min, make it the new min
                    if (indices[i] < arrays[i].Length && arrays[i][indices[i]] < min) {
                        min = arrays[i][indices[i]];
                        minIndex = i;
                    }
                }
                indices[minIndex]++;  //increase the pointer at minIndex
                sorted[l++] = min;   // store the min value
            }
            return sorted;
        }

        public static void TestMergeSort() {
            var a = new[] { 4, 1, 8, 5, 2, 9, 3, 6, 0, 7};
            var b = MergeSort(a);
            Console.WriteLine($"{a.ToStringX()} is {b.ToStringX()}");
        }

        private static int[] MergeSort(int[] a) {
            if (a.Length <= 1) return a;
            var n = a.Length / 2;
            var m = a.Length - n;
            var left = new int[n];
            var right = new int[m];
            Array.Copy(a, 0, left, 0, n);
            Array.Copy(a, n, right, 0, m);

            left = MergeSort(left);
            right = MergeSort(right);

            return MergeSortedArrays(left, right);
        }

        private static int[] MergeSortedArrays(int[] a, int[] b) {
            int ia = 0, ib = 0, i = 0;
            int[] result = new int[a.Length + b.Length];
            while (ia < a.Length && ib < b.Length) {
                if (a[ia] < b[ib])
                    result[i++] = a[ia++];
                else
                    result[i++] = b[ib++];
            }
            Array.Copy(a, ia, result, i, a.Length - ia);
            Array.Copy(b, ib, result, i, b.Length - ib);
            return result;
        }

        private void FindQuotient() {
            var n = FindQuotient(100, 10);
        }
        private int FindQuotient(int n, int d) {
            if (d == 0) throw new Exception("denominator cannot be zero");
            if (n == 0) return 0;
            int times = 0;
            int mult = 1;
            if (Math.Sign(n) != Math.Sign(d)) mult = -1;
            n = Math.Abs(n);
            d = Math.Abs(d);
            int a = d;
            while (a <= n) {
                times++;
                a += d;
            }
            int result = times * mult;
            return result;
        }

        private int PairsDifByK(int[] a, int k) {
            int pairs = 0;
            foreach (int i in a) {
                int target = k + i;
                if (a.Contains(target)) {
                    pairs++;
                }
            }
            return pairs;
        }

        private int PairsAddUpToK(int[] a, int k) {
            int pairs = 0;
            foreach (int i in a) {
                int target = k - i;
                if (a.Contains(target)) {
                    pairs++;
                }
            }
            return pairs;
        }

        public static void UniquePairsAddUpToK() {
            var a = new int[] { 1, 2, 4, 3, 5, 7, -1, -2, 1, 2, 0, 3, 5, -1, -1, -2, 2, -4, 3, 5, -7, -1, -2, 1, 2, 3, 4, 5, 2, 1, 0 };
            Console.WriteLine($"For {a.ToStringX()}");
            for (int i = 1; i < 8; i++) {
                var result = UniquePairsAddUpToK(a, i);
                Console.WriteLine($"unique pairs adding up to {i} is {result}");
            }

        }

        /// <summary>
        /// Find unique pairs that add up to K such that paired values are eliminated from consideration
        /// </summary>
        /// <param name="a"></param>
        /// <param name="k"></param>
        /// <returns>number of unique pairs</returns>
        private static int UniquePairsAddUpToK(int[] a, int k) {
            int pairs = 0;
            var paired = new bool[a.Length];                    // create bool array of same length to track values paired (to eliminate from search)
            for (int i = 0; i < a.Length; i++) {                // iterate over array, testing each value for corresponding value such that "this value" + "that value" = k
                if (paired[i]) continue;                        // skip this value if already paired
                int target = k - a[i];                          // determine target value (k - current value)
                int index = Array.IndexOf(a, target, i + 1);    // search ahead for target index in array a (no need to consider values already examined)
                if (index == -1) continue;                      // skip this value if no target is found (no pair can be made)
                while (index != -1 && paired[index])            // if value at index is already paired, look for next target in array a (only need 1 to pair with)
                    index = Array.IndexOf(a, target, index + 1);
                if (index != -1) {                              // if target has been found and it's not value being tested this iteration
                    paired[i] = true;                           // set paired bool for this iteration to true (eliminate this value from further searching)
                    paired[index] = true;                       // set paired for target index to true (eliminate this value from further searching)
                    pairs++;                                    // add 1 to total pairs found
                }
            }
            return pairs;
        }


    }
}
