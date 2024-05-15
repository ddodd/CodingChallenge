using System;
using System.Collections.Generic;

namespace CodingChallenge {

    class Algorithms {

        public static void CompareTriplets() {
            var test = new List<Tuple<List<int>, List<int>>>() {
                new Tuple<List<int>, List<int>>(new List<int>() { 17, 28, 30 }, new List<int>() { 99, 16, 8 }),
                new Tuple<List<int>, List<int>>(new List<int>() { 1, 2, 3 }, new List<int>() { 0, 4, 5 }),
            };

            test.ForEach(t => Console.WriteLine($"For a={t.Item1.ToStringX()}, and b={t.Item2.ToStringX()}: scores={CompareTriplets(t.Item1, t.Item2).ToStringX()}"));
        }

        static List<int> CompareTriplets(List<int> a, List<int> b) {
            int aScore = 0, bScore = 0; ;

            for (var i = 0; i < 3; i++) {
                if (a[i] > b[i]) {
                    aScore++;
                }

                if (b[i] > a[i]) {
                    bScore++;
                }
            }
            return new List<int>() { aScore, bScore };
        }

        public static void VeryBigSum() {
            var test = new List<long[]>() {
                new long[]{ 1000000001, 1000000002, 1000000003, 1000000004, 1000000005},
            };

            test.ForEach(a => Console.WriteLine($"For {a.ToStringX()}, sum = {VeryBigSum(a)}"));
        }

        static long VeryBigSum(long[] ar) {
            long sum = 0;
            ar.ForEach(i => sum += i);
            return sum;
        }

        public static void DiagonalDifference() {
            var list = new List<string>() {
                "11 2 4",
                "4 5 6",
                "10 8 -12"
            };
            var arr = new int[list.Count][];
            for (var i = 0; i < list.Count; i++) {
                arr[i] = list[i].ToArray<int>();
            }
            Console.WriteLine($"diagonalDifference is {DiagonalDifference(arr)}");
        }

        private static int DiagonalDifference(int[][] arr) {
            var dif1 = 0;
            var dif2 = 0;
            var n = arr.Length - 1;
            for (var i = 0; i < arr.Length; i++) {
                dif1 += arr[i][i];
                dif2 += arr[i][n - i];
            }
            return Math.Abs(dif1 - dif2);
        }

        public static void PlusMinus() {
            var l = new List<int[]>() {
                new[]{-4,3,-9,0,4,1 },
            };
            foreach (var a in l) {
                Console.WriteLine($"PlusMinus for {a.ToStringX()}, result is");
                PlusMinus(a);
            }
        }

        private static void PlusMinus(int[] arr) {
            decimal neg = 0, zero = 0, pos = 0;
            foreach (var i in arr) {
                if (i < 0) neg++;
                else if (i == 0) zero++;
                else pos++;
            }

            Console.WriteLine((pos / arr.Length).ToString("N6"));
            Console.WriteLine((neg / arr.Length).ToString("N6"));
            Console.WriteLine((zero / arr.Length).ToString("N6"));
        }

        public static void Staircase() {
            Staircase(6);
        }

        private static void Staircase(int n) {
            var step = "#";
            var stairs = step;
            for (var i = 0; i < n; i++) {
                Console.WriteLine(stairs.PadLeft(n));
                stairs += step;
            }
        }

        public static void MiniMaxSum() {
            MiniMaxSum(new[] { 1, 2, 3, 4, 5 });
        }

        // return the min and the max of n-1 of n values
        static void MiniMaxSum(int[] arr) {
            var min = long.MaxValue;
            var max = long.MinValue;
            long sum = 0;
            for (var i = 0; i < arr.Length; i++) {
                sum += arr[i];
            }
            long partialSum = 0;
            for (var i = 0; i < arr.Length; i++) {
                partialSum = sum - arr[i];
                min = Math.Min(min, partialSum);
                max = Math.Max(max, partialSum);
            }
            Console.WriteLine($"{min} {max}");
        }

        public static void MaxDupes() {
            var a = new[] { 3, 2, 1, 3 };
            Console.WriteLine($"Max dupes in {a.ToStringX()} is {MaxDupes(a)}");

        }
        static int MaxDupes(int[] ar) {
            var map = new Dictionary<int, int>();
            var max = int.MinValue;
            foreach (var c in ar) {
                if (!map.ContainsKey(c)) map.Add(c, 1);
                else map[c]++;
                if (map[c] > max) max = map[c];
            }

            return max;
        }

        public static void Fibonacci() {
            var l = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            l.ForEach(i => Console.WriteLine($"{Fib(i, new int[i - 1])}"));

            //            Console.WriteLine($"{Fib(8)}");
        }

        private static int Fib(int n, int[] memo) {
            if (n < 2) return n;
            int m = n - 2;
            if (memo[m] == 0)
                memo[m] = Fib(n - 1, memo) + Fib(n - 2, memo);

            return memo[m];
        }

        private static int Fib(int n) {
            if (n == 0) return 0;
            if (n == 1) return 1;

            return Fib(n - 1) + Fib(n - 2);
        }

        public static void RoundGrades() {
            var grades = new[] { 78, 73, 67, 38, 33, 66, 54 };
            Console.WriteLine($"For {grades.ToStringX()} becomes {RoundGrades(grades, 60, 10, 4).ToStringX()}");
        }

        private static int[] RoundGrades(int[] grades) {
            for (int i = 0; i < grades.Length; i++) {
                if (grades[i] > 37) {
                    var g = grades[i] % 5;
                    if (g > 2) {
                        grades[i] += 5 - g;
                    }
                }
            }

            return grades;
        }

        private static int[] RoundGrades(int[] grades, int min = 40, int snap = 5, int tolerance = 2) {
            var lowest = min - (snap - tolerance);
            for (int i = 0; i < grades.Length; i++) {
                if (grades[i] > lowest) {
                    var g = grades[i] % snap;
                    if (g > tolerance) {
                        grades[i] += snap - g;
                    }
                }
            }

            return grades;
        }

        public static void CountApplesAndOranges() {
            CountApplesAndOranges(7, 11, 5, 15, new[] { -2, 2, 1 }, new[] { 5, -6 });
        }

        /// <summary>
        /// Calculate number of apples and oranges that hit the house
        /// </summary>
        /// <param name="s">left side of house</param>
        /// <param name="t">right side of house</param>
        /// <param name="a">position of apple tree</param>
        /// <param name="b">position of orange tree</param>
        /// <param name="apples">distances of apples that fell</param>
        /// <param name="oranges">distances of oranges that fell</param>
        private static void CountApplesAndOranges(int s, int t, int a, int b, int[] apples, int[] oranges) {
            var numApples = 0;
            var numOranges = 0;
            var x = 0;
            foreach (var ax in apples) {
                x = ax + a;
                if (x >= s && x <= t) numApples++;
            }
            foreach (var ox in oranges) {
                x = ox + b;
                if (x >= s && x <= t) numOranges++;
            }
            Console.WriteLine(numApples);
            Console.WriteLine(numOranges);
        }

        public static void Kangaroo() {
            Console.WriteLine($"Kangaroos will match distnaces {Kangaroo(0, 2, 5, 3)}");
            Console.WriteLine($"Kangaroos will match distnaces {Kangaroo(21, 6, 47, 3)}");


        }

        private static string Kangaroo(int x1, int v1, int x2, int v2) {
            // find a time t that both kinematic equations satisfy
            float t = ((x2 - (float)x1) / (v1 - (float)v2));
            //            Console.WriteLine($"At t={t}, x1={x1 + v1 * t} and x2={x2 + v2 * t}");
            string answer = t > 0 && t % 1 == 0 ? "YES" : "NO";
            return answer;
        }

    }
}
