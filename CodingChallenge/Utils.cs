using CodingChallenge;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Utilities
{
    static class Utils
    {

        // Utilities

        public static Random GetRandom()
        {
            return new Random(Guid.NewGuid().GetHashCode());
        }

        public static string CollectionToString<T>(IEnumerable<T> A, string sep = " ")
        {
            return $"[{string.Join(sep, A)}]";
        }

        public static IEnumerable<T> StringToCollection<T>(string s, char sep = ' ')
        {
            return s.Split(sep).Select(x => (T)Convert.ChangeType(x, typeof(T))) as IEnumerable<T>;
        }

        public static int NumberOfDistinctValues(int[] a)
        {
            return new HashSet<int>(a).Count;
        }

        public static int NumberOfDupes(int[] a)
        {
            return a.Length - new HashSet<int>(a).Count;
        }
        public static string Tabs(int n)
        {
            return new string('\t', n);
        }
        public static string Indent(int n, int widthOfIndent = 3, Char c = ' ')
        {
            var indent = new string(c, widthOfIndent);
            return string.Concat(Enumerable.Repeat(indent, n));
        }
        public static string aStr(int[] a, int max = 16)
        {
            return a.Length > max ? $"[{a.Length} values]" : a.ToStringX();
        }

        public static void SayIndented(int level, string msg)
        {
            Console.WriteLine($"{Utils.Indent(level, 2)}{level}: {msg}");
        }

        public static int[] MakeArrayOfRandomInts(int length, int min = int.MinValue, int max = int.MaxValue)
        {
            var rnd = GetRandom();
            var a = new int[length];
            for (var i = 0; i < length; i++)
            {
                a[i] = rnd.Next(min, max + 1);
            }
            return a;
        }

        public static IEnumerable<int> GetSequentialIntArray(int take, int start = 0, int inc = 1)
        {
            int x = start;
            int i = 0;
            while (i++ < take)
            {
                yield return x;
                x += inc;
            }
        }

        public static int[] GetIntArray(int length, int max = 0, int min = 0)
        {
            if (max == 0) max = length;
            var a = Enumerable.Range(min, max);
            if (length < a.Count())
            {
                var rnd = GetRandom();
                var b = a.ToList();
                while (b.Count > length)
                {
                    b.RemoveAt(rnd.Next(0, b.Count));
                }
                return b.ToArray();
            }

            return a.ToArray();
        }

        public static int[] GetIntArray2(int length = 0, int start = 0, int end = 0, int inc = 1, bool randomize = false)
        {
            if (length <= 0 || start == end) return new int[0];
            if (end < start) inc = -Math.Abs(inc);
            var take = Math.Abs((end - start) / inc);
            if (length > take)
            {
                length = ++take;
            }
            var a = GetSequentialIntArray(take, start, inc).ToList();
            if (a.Count > length)
            {
                var rnd = GetRandom();
                while (a.Count > length)
                {
                    a.RemoveAt(rnd.Next(0, a.Count));
                }
            }
            if (randomize) a.Randomize();
            return a.ToArray();
        }

        public static uint SumOfPermOfLength_n(uint n)
        {
            return n * (n + 1) / 2;
        }

        public static uint SumOfElements(int[] A)
        {
            uint sum = 0;
            foreach (var i in A)
            {
                sum += (uint)i;
            }
            return sum;
        }

        /// <summary>
        /// Calculates the sum of a slice of an array using prefix sum technique.
        /// </summary>
        /// <param name="prefixSum">The prefix sum array.</param>
        /// <param name="x">The starting index of the slice.</param>
        /// <param name="y">The ending index of the slice.</param>
        /// <returns>The sum of the elements in the specified slice of the array.</returns>
        public static long GetArraySliceSum(long[] prefixSum, int x, int y)
        {
            return prefixSum[y + 1] - prefixSum[x];
        }


        /// <summary>
        /// Calculates the prefix sum array of an integer array.
        /// </summary>
        /// <param name="a">The input integer array.</param>
        /// <param name="constant">The constant value to be added to the prefix sum array.</param>
        /// <returns>The prefix sum array.</returns>
        public static long[] PrefixSumArray(int[] a, long constant = 0)
        {
            var ps = new long[a.Length + 1];
            ps[0] = constant;
            for (var i = 0; i < a.Length; i++)
            {
                ps[i + 1] = ps[i] + a[i];
            }
            return ps;
        }

        public static long[] DifferenceArray(int[] a)
        {
            var df = new long[a.Length - 1];
            for (var i = 0; i < a.Length - 1; i++)
            {
                df[i] = a[i + 1] - a[i];
            }
            return df;
        }

        public static void TimeMethods(params Action[] actions)
        {
            var watch = new System.Diagnostics.Stopwatch();
            foreach (var action in actions)
            {
                watch.Restart();
                action();
                Console.WriteLine($"[Execution Time:{watch.ElapsedMilliseconds} ms]");
            }
        }

        public static int GetVariedMidPoint(int num, int variance)
        {
            return num / 2 + GetRandom().Next(-variance, variance + 1);
        }

    }
}
