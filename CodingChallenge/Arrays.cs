using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge
{
    class Arrays
    {
        public static void HourglassSum()
        {
            var arr = new int[6][];
            var list = new string[] {
                "1 1 1 0 0 0",
                "0 1 0 0 0 0",
                "1 1 1 0 0 0",
                "0 0 2 4 4 0",
                "0 0 0 2 0 0",
                "0 0 1 2 4 0"
            };
            var y = 0;
            foreach (var s in list)
            {
                //int[] b = s.Split(' ').Select(x => int.Parse(x)).ToArray();
                arr[y] = s.ToArray<int>();
                y++;
            }
            Console.WriteLine($"max value is {HourglassSum(arr)}");
        }

        private static int HourglassSum(int[][] arr)
        {
            var X = arr.Length;
            var Y = X;
            var n = (X - 2) * (Y - 2);
            var sums = new int[n];
            var maxSum = int.MinValue;
            var index = 0;
            for (var y0 = 0; y0 < Y - 2; y0++)
            {
                for (var x0 = 0; x0 < X - 2; x0++)
                {
                    for (var y = y0; y < y0 + 3; y++)
                    {
                        for (var x = x0; x < x0 + 3; x++)
                        {
                            var val = arr[y][x];
                            sums[index] += arr[y][x];
                        }
                    }
                    sums[index] -= (arr[y0 + 1][x0] + arr[y0 + 1][x0 + 2]);
                    maxSum = Math.Max(maxSum, sums[index]);

                    index++;
                }
            }
            return maxSum;
        }


        private static readonly List<int[]> intList = new List<int[]> {
                new int[0],
                new[] { 3, 3, 3, 9, 9, 7, 7 },
                new[] { 3, 3, 9, 9, 7, 7 },
                new[] { 3, 3, 9, 9, 7, 7, 0, 0, 0, 0, 1, 1, 2, 2, 2, 3, 7 },
                new[] { 3, 3, 3, 9, 9, 7, 7, 0, 0, 0, 0, 1, 1, 2, 2, 2 }
            };

        public static void FindSingleOddOccurance()
        {
            intList.ForEach(l => { var a = l.ToArray(); Console.WriteLine($"Single odd occurrance in {a.ToStringX()} is {FindSingleOddOccurance(a)}"); });
        }

        /// <summary>
        /// Finds the single odd occurrence in an array.
        /// </summary>
        /// <param name="a">The input array.</param>
        /// <returns>The single odd occurrence in the array. Returns -1 if no odd occurrence is found.</returns>
        private static int FindSingleOddOccurance(int[] a)
        {
            if (a.Length % 2 != 0)
            {
                var hash = new HashSet<int>();
                foreach (var i in a)
                {
                    if (hash.Contains(i))
                    {
                        hash.Remove(i);
                    }
                    else
                    {
                        hash.Add(i);
                    }
                }
                if (hash.Count == 1)
                {
                    return hash.ElementAt(0);
                }
            }
            return -1;
        }

        public static void FindTotalOddOccurances()
        {
            intList.ForEach(l => { var a = l.ToArray(); Console.WriteLine($"Total Odd occurrances in {a.ToStringX()} is {FindTotalOddOccurances(a)}"); });
        }

        private static int FindTotalOddOccurances(int[] a)
        {
            var h = new HashSet<int>();
            for (int i = 0; i < a.Length; i++)
            {
                if (h.Contains(a[i]))
                    h.Remove(a[i]);
                else
                    h.Add(a[i]);
            }
            return h.Count;
        }

        public static void FindAllOddOccurances()
        {
            intList.ForEach(l => { var a = l.ToArray(); Console.WriteLine($"The Odd occurrances in {a.ToStringX()} are {FindAllOddOccurances(a).ToStringX()}"); });
        }

        private static int[] FindAllOddOccurances(int[] a)
        {
            var h = new HashSet<int>();
            for (int i = 0; i < a.Length; i++)
            {
                if (h.Contains(a[i]))
                    h.Remove(a[i]);
                else
                    h.Add(a[i]);
            }
            return h.ToArray();
        }


        public static void RotatetRight()
        {
            var list = new List<int[]> {
                new [] { 1, 2, 3, 4 },
                new [] { 3, 8, 9, 7, 6 },
                new int[0]
            };
            var shifts = new[] { 1, 2, 3, 4, 5 };
            //list.ForEach(a => shifts.ForEach(s => Console.WriteLine($"Array {a.ToStringX()} shifted by {s} is {RotateRight(a, s).ToStringX()}")));

            foreach (var a in list)
            {
                foreach (var s in shifts)
                {
                    Console.WriteLine($"Array {a.ToStringX()} RotateRight[{s}] is {RotateRight(a, s).ToStringX()}");
                }
            }
        }

        private static int[] RotateRight(int[] a, int k)
        {
            var n = a.Length;
            if (n == 0) return a;
            k %= n;
            if (k == 0) return a;
            /*
            var srcIndex = n - K;
            var a = new int[n];
            var dstIndex = 0;
            for (var i = srcIndex; i < n; i++) {
                a[dstIndex++] = A[i];
            }
            for (var i = 0; i < srcIndex; i++) {
                a[dstIndex++] = A[i];
            }
            return a;
            */
            return a.Skip(n - k).Concat(a.Take(n - k)).ToArray();
        }

        public static void RotateLeft()
        {
            var list = new List<int[]> {
                new [] { 1, 2, 3, 4 },
                new [] { 3, 8, 9, 7, 6 },
                new int[0]
            };
            var shifts = new[] { 1, 2, 3, 4, 5 };
            //list.ForEach(a => shifts.ForEach(s => Console.WriteLine($"Array {a.ToStringX()} shifted by {s} is {RotateLeft(a, s).ToStringX()}")));

            foreach (var a in list)
            {
                foreach (var s in shifts)
                {
                    Console.WriteLine($"Array {a.ToStringX()} RotateLeft[{s}] is {RotateLeft(a, s).ToStringX()}");
                }
            }
        }

        private static int[] RotateLeft(int[] a, int k)
        {
            var n = a.Length;
            if (n == 0) return a;
            k %= n;
            if (k == 0) return a;

            return a.Skip(k).Concat(a.Take(k)).ToArray();
        }

        public static void MinBribes()
        {
            var list = new string[] {
                "2 1 5 3 4",
                "2 5 1 3 4",
                "3 4 5 2 1",
                "1 2 5 3 7 8 6 4"
            };
            foreach (var s in list)
            {
                Console.WriteLine($"For {s}:");

                MinBribes(s.ToArray<int>());
            }
        }

        private static void MinBribes(int[] q)
        {
            var n = q.Length;
            var swaps = 0;
            // iterate backwards starting with largest value
            for (var i = n; i >= 1; i--)
            {
                var j = i - 1;
                // moving backwards through queue, find the index of the largest value
                while (q[j] != i)
                {
                    j--;
                }
                // determine how far out of place it is
                var dif = q[j] - (j + 1);
                if (dif > 2)
                {
                    Console.WriteLine("Too chaotic");
                    return;
                }
                // move each value between current and proper place toward "front"
                if (dif > 0)
                {
                    for (var d = j; d < j + dif; d++)
                    {
                        q[d] = q[d + 1];
                    }
                    // put value in proper place
                    q[j + dif] = i;
                    swaps += dif;
                }
            }
            Console.WriteLine(swaps);
        }

        public static void MinSwaps()
        {
            var list = new string[] {
                "1 3 4 2",
                "4 3 1 2",
                "3 2",
                "4 3 2",
                "2 3 4 1 5",
                "1 3 5 2 4 6 8"
            };
            list.ForEach(s => Console.WriteLine($"For {s}: {MinSwaps(s.ToArray<int>())}"));
            foreach (var s in list)
            {
                Console.WriteLine($"For {s}: {MinSwaps(s.ToArray<int>())}");
            }
        }

        private static int MinSwaps(int[] arr)
        {
            var n = arr.Length;

            var c = arr.ToList();
            c.Sort();

            var p = new Dictionary<int, int>();
            var i = 0;
            for (i = 0; i < n; i++)
            {
                p[c[i]] = i;
            }
            var b = new bool[n];
            var swaps = 0;
            i = 0;
            while (i < n)
            {
                var v = arr[i];
                if (v == c[i] || b[i])
                {
                    b[i] = true;
                    i++;
                    continue;
                }
                var target = p[v];
                arr[i] = arr[target];
                arr[target] = v;
                b[target] = true;
                swaps++;
            }
            return swaps;
        }

        private struct ArrayGroup
        {
            public int n;
            public int[][] q;
        }

        public static void ArrayManipulation()
        {
            var l = new List<ArrayGroup> {
                new ArrayGroup { n = 4, q = new int[][] { new[]{ 2,3,603 }, new[]{ 1,1,286 }, new[]{ 4,4,882 } } },
                new ArrayGroup { n = 5, q = new int[][] { new[]{ 1, 2, 100 }, new[]{ 2, 5, 100 }, new[]{ 3, 4, 100 } } },
                new ArrayGroup { n = 10, q = new int[][] { new[]{ 1, 5, 3 }, new[]{ 4,8,7 }, new[]{ 6,9,1 } } },
                new ArrayGroup { n = 10, q = new int[][] { new[]{ 2,6,8 }, new[]{ 3,5,7 }, new[]{ 1,8,1 } , new[]{ 5,9,15 } } }
            };
            foreach (var g in l)
            {
                Console.WriteLine(ArrayManipulation(g.n, g.q));
            }
        }

        private static ulong ArrayManipulation(int n, int[][] queries)
        {
            var d = new ulong[n + 1];
            // build delta array
            foreach (var q in queries)
            {
                var a = q[0];
                var bp = q[1] + 1;
                var k = (ulong)q[2];
                d[a] += k;
                if (bp <= n)
                {
                    d[bp] -= k;
                }
            }
            ulong m = 0, max = 0;
            // reconstruct array values by accumulating deltas
            for (var i = 1; i <= n; i++)
            {
                m += d[i];
                max = Math.Max(max, m);
            }
            return max;
        }

        public static void FindMaxSubsequenceSum()
        {
            var list = new List<int[]>() {
                new[] {6, -1, 15, -5, 11, -30, 25, -2, -1, 3},
                new[] {-2, -3, 4, -1, -2, 1, 5, -3},
                new[] {-2, -1},
                new[] {2, -2, -1, 1}
            };
            list.ForEach(a => Console.WriteLine($"Max sub sum in {a.ToStringX()} is {FindMaxSubsequenceSum(a)}"));
        }

        static int FindMaxSubsequenceSum(int[] a)
        {
            var sum = a[0];
            var max = sum;

            for (var i = 1; i < a.Length; i++)
            {
                // compare current value to (sum + current value) and make sum the larger of the two
                //sum += a[i];
                //if (a[i] > sum) sum = a[i];

                sum = Math.Max(a[i], sum + a[i]);

                max = Math.Max(max, sum);
            }

            return max;
        }

    }
}
