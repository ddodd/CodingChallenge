using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge {
    class CountingElements {

        public static void Counting() {
            var a = new int[8] { 0, 1, 2, 0, 3, 2, 1, 0 };
            var count = Counting(a, 4, out int sum);
            Console.WriteLine($"Count of {a.ToStringX()} is {count.ToStringX()} and sum is {sum}");
        }

        private static int[] Counting(int[] A, int m) {
            int[] count = new int[m + 1];
            foreach (var i in A) {
                count[i]++;
            }
            return count;
        }

        private static int[] Counting(int[] A, int m, out int sum) {
            int[] count = new int[m + 1];
            sum = 0;
            foreach (var i in A) {
                count[i]++;
                sum += i;
            }
            return count;
        }

        public static void FindPerms() {
            var list = new List<int[]> {
                new int[0],
                new[] { 1 },
                new[] { 1000 },
                new[] { 0, 4, 1, 3, 2 },
                new[] { 4, 1, 3, 2 },
                new[] { 4, 5, 3, 2 },
                new[] { 4, 1, 3 },
                new[] { 4, 1, 3, 2, 3 }
            };
            var bigList = new List<int>();
            for (int i = 1; i <= 1e5; i++) {
                bigList.Add(i);
            }
            list.Add(bigList.ToArray());

            foreach (var l in list) {
                int[] a = l.ToArray();
                bool st = IsPermMemo(a) == 1;
                string array = "(very large)";
                if (a.Length < 10) array = a.ToStringX();
                Console.WriteLine($"The array {array}:, perm = {st}");
            }
        }

        private static int IsPerm(int[] A) {
            if (A.Length == 0) return 0;
            uint sum = (uint)A.Sum();
            uint n = (uint)A.Length;
            uint sumPerm = n * (n + 1) / 2;

            if (sum == sumPerm) return 1;
            return 0;
        }

        private static int IsPermMemo(int[] A) {
            if (A.Length == 0) return 0;
            bool[] memo = new bool[A.Length];
            foreach (int i in A) {
                if (i < 1 || i > A.Length) return 0;
                if (memo[i - 1]) return 0;
                memo[i - 1] = true;
            }
            return 1;
        }

        private static int IsSeries(int[] A) {
            if (A.Length == 0) return 0;
            int min = int.MaxValue;
            uint sum = 0;
            uint n = (uint)A.Length;
            foreach (var i in A) {
                sum += (uint)i;
                min = Math.Min(min, i);
            }
            sum -= (uint)(min - 1) * n;
            uint sumPerm = n * (n + 1) / 2;

            if (sum == sumPerm) return 1;
            return 0;
        }

        private static int IsPerm2N(int[] A) {
            int min = int.MaxValue;
            var hash = new HashSet<int>();
            for (int i = 0; i < A.Length; i++) {
                hash.Add(A[i]);
                min = Math.Min(min, A[i]);
            }
            if (hash.Count != A.Length)
                return 0;
            for (int i = 0; i < A.Length; i++) {
                if (!hash.Contains(min + i)) return 0;
            }
            return 1;
        }

        public static void FrogJumps() {
            var list = new List<Tuple<int, int, int>>() {
                new Tuple<int, int, int>(1, 100, 25),
                new Tuple<int, int, int>(1, 100, 25),
                new Tuple<int, int, int>(10, 85, 30),
                new Tuple<int, int, int>(1, 1, 1),
                new Tuple<int, int, int>(1, (int)1e9, 1),
                new Tuple<int, int, int>(1, (int)1e9, (int)1e8),
                new Tuple<int, int, int>((int)1e8, (int)1e9, 1),
            };

            list.ForEach(set => Console.WriteLine($"Minimum steps to jump from {set.Item1}, to {set.Item2} by steps of {set.Item3} is {FrogJump(set.Item1, set.Item2, set.Item3)}"));
        }

        private static int FrogJump(int start, int end, int stride) {
            int dist = end - start;
            int steps = dist / stride;
            if (dist - steps * stride > 0) steps++;
            return steps;
        }

        public static void EvaluateCounters() {
            var dic = new Dictionary<int[], int> {
            { new [] { 3, 4, 4, 6, 6, 1, 4, 4 }, 5 },
            { new [] { 3, 1, 3, 2, 3, 1 }, 2 }
        };

            /*
            int n = 1000;

            Console.WriteLine($"Running {n} tests...");

            Random rnd = new Random();
            for (int x = 0; x < n; x++) {
                var l = new List<int>();
                int M = rnd.Next(1, 9);
                int N = rnd.Next(1, 5);
                for (int i = 0; i < M; i++) {
                    l.Add(rnd.Next(1, N + 2));
                }
                dic.Add(l, N);
            }
            */
            int s = 0;
            int f = 0;
            foreach (var d in dic) {
                int[] a = d.Key.ToArray();
                int x = d.Value;
                var MN0 = EvaluateCounter0(x, a);
                var MN = EvaluateCounterMN(x, a);
                var Mplus2N = EvaluateCounterMplusN(x, a);
                if (!MN0.SequenceEqual(Mplus2N)) {
                    f++;
                    EvaluateCounterMplusN(x, a);
                } else if (!MN.SequenceEqual(Mplus2N)) {
                    f++;
                    EvaluateCounterMplusN(x, a);

                } else
                    s++;

            }
            Console.WriteLine($"{s} tests successful, {f} failures");
        }

        private static int[] EvaluateCounterMplusN(int N, int[] A) {
            int[] counters = new int[N];
            int max = 0, curMax = 0;
            for (int i = 0; i < A.Length; i++) {
                int op = A[i];
                int c = op - 1;
                if (op <= N) {
                    if (counters[c] < max)
                        counters[c] = max;
                    counters[c]++;
                    if (curMax < counters[c])
                        curMax = counters[c];
                } else
                    max = curMax;

                Console.WriteLine($"op({op})->[{string.Join(" ", counters)}] [{max} {curMax}]");
            }
            for (int i = 0; i < counters.Length; i++)
                if (counters[i] < max)
                    counters[i] = max;

            Console.WriteLine($"FINAL->[{string.Join(" ", counters)}]");

            return counters;
        }

        private static int[] EvaluateCounterMN(int N, int[] A) {
            int[] counters = new int[N];
            int mc = 0;
            for (int i = 0; i < A.Length; i++) {
                int op = A[i];
                if (op <= N) {
                    counters[op - 1]++;
                    mc = Math.Max(mc, counters[op - 1]);
                } else
                    for (int c = 0; c < counters.Length; c++)
                        counters[c] = mc;
            }
            return counters;
        }

        private static int[] EvaluateCounterMplus2N(int N, int[] A) {
            int[] counters = new int[N];
            int[] countersEnd = new int[N];
            int mc = 0;
            int lastMaxOpIndex = 0;

            // iterate through A backwards and break on max op found
            for (int i = A.Length - 1; i >= 0; i--) {
                int op = A[i];
                if (op <= N) {
                    countersEnd[op - 1]++;
                } else {
                    lastMaxOpIndex = i;
                    break;
                }
                //Console.WriteLine($"End:{report(countersEnd, op)}");
            }
            // iterate through A up to lastMaxOpIndex
            for (int i = 0; i < lastMaxOpIndex; i++) {
                int op = A[i];
                if (op <= N) {
                    counters[op - 1]++;
                }
                //Console.WriteLine($"Beginning:{report(counters, op)}");
            }

            // find max of all counters
            for (int i = 0; i < counters.Length; i++) {
                mc = Math.Max(mc, counters[i]);
            }

            // set all counters to max + countersEnd values
            for (int i = 0; i < counters.Length; i++) {
                counters[i] = mc + countersEnd[i];
                //Console.WriteLine($"Allcounters = {string.Join(", ", counters)}");
            }

            return counters;
        }

        private static string Report(int[] counters, int op) {
            return $"for op[{op}] counters = {string.Join(", ", counters)}";
        }

        private static int[] EvaluateCounter0(int N, int[] A) {
            int[] counters = new int[N];
            int mc = 0;
            int lmc = 0;
            for (int i = 0; i < A.Length; i++) {
                int op = A[i];
                if (op <= N) {
                    counters[op - 1]++;
                    mc = Math.Max(mc, lmc + counters[op - 1]);
                } else {
                    lmc = mc;
                    counters = new int[N];
                }

                //Console.WriteLine($"for op[{op}] counters = {string.Join(", ", counters)}");
            }
            for (int c = 0; c < counters.Length; c++)
                counters[c] += lmc;

            return counters;
        }

        public static void SmallestPositiveMissingInt() {
            Console.WriteLine("Find Smallest missing integer");
            var list = new List<int[]> {
            new [] { -1, 1 },
            new [] { 10, 15 },
            new [] { -1, -3, 0 },
            new [] { 1, 3, 6, 4, 1, 2 },
            new [] { 1, 2, 3 }
        };
            var rnd = new Random();
            int N = 10;
            for (int t = 0; t < 2 * N; t++) {
                int[] a = new int[N];
                int m = rnd.Next(N);
                for (int i = 0; i < N; i++) {
                    a[i] = rnd.Next(-N, N);
                }
                a[m] = 0;
                list.Add(a);
            }
            list.ForEach(a => Console.WriteLine($"{a.ToStringX()} smallest missing int is {SmallestPositiveMissingInt(a)}"));
        }

        private static int SmallestPositiveMissingInt(int[] A) {
            int max = 0;
            int v;
            var hash = new HashSet<int>();
            for (int i = 0; i < A.Length; i++) {
                v = A[i];
                if (v > 0) {
                    hash.Add(v);
                    if (max < v) max = v;
                }
            }
            if (max == 0) return 1;

            for (int i = 1; i <= max; i++) {
                if (!hash.Contains(i))
                    return i;
            }
            return max + 1;

        }


    }
}
