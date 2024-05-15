using System;
using System.Collections.Generic;
using System.Linq;
using Utilities;

namespace CodingChallenge {
    class PrefixSumsAndDifferenceArrays {

        public static void PassingCarPairs() {
            var list = new List<int[]>() {
                new[] {0,1,0,1,1},
                new[] { 0, 1, 0, 1, 1 , 0, 1, 0, 1, 1 }
            };
            foreach (var l in list) {
                Console.WriteLine($"for {l.ToStringX()}, pairs = {PassingCarPairs(l)}");
            }
        }

        private static int PassingCarPairs(int[] A) {
            //var p = Utils.PrefixSumArray(A);
            var p = new long[A.Length + 1];
            for (var i = 0; i < p.Length - 1; i++) {
                p[i + 1] = p[i] + A[i];
            }
            var pairs = 0;
            for (var i = 0; i < A.Length; i++) {
                var val = A[i];
                if (val == 0) {
                    pairs += (int)Utils.GetArraySliceSum(p, i, A.Length - 1);
                }

                if (pairs > (int)1e9) {
                    return -1;
                }
            }
            return pairs;
        }

        private void FindNumberOfSubSequencesThatSumToValue() {
            var dic = new Dictionary<int[], int>() {
                { new[] { 23, 24, 47, -47, 47, 23, 24 }, 47 },
                { new[] { 2, 7, 1, 8, 2, 8, 1, 8, 2, 8, 4, 5, 9 }, 47 },
                { new[] { 2, 47, 94, -47, 47, 47 }, 47 }
            };
            foreach (var d in dic) {
                Console.WriteLine($"subs summing to {d.Value} in {d.Key.ToStringX()} is {FindNumberOfSubSequencesThatSumToValueN(d.Key, d.Value)}");
            }
        }

        private int FindNumberOfSubSequencesThatSumToValueN(int[] a, int value) {
            var num = 0;
            var prefixSum = new long[a.Length + 1];
            var map = new Dictionary<long, int>();
            for (var i = 0; i < prefixSum.Length; i++) {
                // build prefix sum array as we go
                if (i < a.Length) {
                    prefixSum[i + 1] = prefixSum[i] + a[i];
                }

                var curSum = prefixSum[i];
                // add s to our map
                if (map.ContainsKey(curSum)) {
                    map[curSum]++;
                } else {
                    map.Add(curSum, 1);
                }
                // since curSum is the sum so far, we're looking for any previous (target) sum where 
                // value = slice = P(y+1)-P(x) = curSum - targetSum, or targetSum = curSum - value;
                var targetSum = curSum - value;
                // if our map has any such P(x) (tagetSum), add all occurances up to this point
                if (map.ContainsKey(targetSum)) {
                    num += map[targetSum];
                }
            }
            return num;
        }

        private int FindNumberOfSubSequencesThatSumToValueN0(int[] a, int value) {
            var num = 0;
            var p = new long[a.Length + 1];
            var map = new Dictionary<long, int>();
            for (var i = 0; i < a.Length; i++) {
                // build prefix sum array as we go
                p[i + 1] = p[i] + a[i];
                num += NumberOfSumsSoFar(p[i], value, map);
            }
            // do last value in prefix sum
            num += NumberOfSumsSoFar(p[a.Length], value, map);

            return num;
        }

        private int NumberOfSumsSoFar(long sum, int value, Dictionary<long, int> map) {
            // update s in map
            if (map.ContainsKey(sum)) {
                map[sum]++;
            } else {
                map.Add(sum, 1);
            }

            var v = sum - value;
            // if p[i]-p[x]=val, we're looking for all p[x]=p[i]-val
            // if our map has any such p[x], return occurances
            if (map.ContainsKey(v)) {
                return map[v];
            }
            return 0;
        }

        private int FindNumberOfSubSequencesThatSumToValue2N(int[] a, int value) {
            var num = 0;
            var p = Utils.PrefixSumArray(a);  // this makes it 2N
            var d = new Dictionary<long, int>();
            for (var i = 0; i < p.Length; i++) {
                var s = p[i];
                // add s to our map
                if (d.ContainsKey(s)) {
                    d[s]++;
                } else {
                    d.Add(s, 1);
                }

                var v = s - value;
                // if p[i]-p[x]=val, we're looking for all p[x]=p[i]-val
                // if our map has any such p[x], add all occurances up to this point
                if (d.ContainsKey(v)) {
                    num += d[v];
                }
            }
            return num;
        }

        public static void FindMushrooms() {
            Console.WriteLine("Find Maximum mushrooms picked");
            var list = new List<int[]> {
                new [] { 2, 3, 7, 5, 3, 1, 9 }
            };
            var k = 4;
            var m = 6;

            foreach (var l in list) {
                var a = l.ToArray();
                Console.WriteLine($"{a.ToStringX()} -> {Mushrooms(a, k, m)}");
            }
        }

        // starts at k and performs m moves
        private static long Mushrooms(int[] A, int k, int m) {
            var n = A.Length;
            long result = 0;
            int left, right;
            var P = Utils.PrefixSumArray(A);

            for (var i = 0; i < Math.Min(m, k) + 1; i++) {
                left = k - i;
                var posMoves = k + m - 2 * i;
                right = Math.Min(n - 1, Math.Max(k, posMoves));
                result = Math.Max(result, Utils.GetArraySliceSum(P, left, right));
            }

            for (var i = 0; i < Math.Min(m - 1, n - k) + 1; i++) {
                right = k + i;
                var posMoves = k + m - 2 * i;
                left = Math.Max(0, Math.Min(k, k - posMoves));
                result = Math.Max(result, Utils.GetArraySliceSum(P, left, right));
            }

            return result;
        }

        public static void FindGenomicRange() {
            var list = new List<Tuple<string, int[], int[]>>() {
                new Tuple<string, int[], int[]>("CAGCCTA", new[]{2,5,0}, new[]{4,5,6})
            };

            list.ForEach(t => Console.WriteLine($"For {t.Item1} and P:{t.Item2.ToStringX()}, and Q:{t.Item3.ToStringX()}, impact is {FindGenomicRange(t.Item1, t.Item2, t.Item3).ToStringX()}"));
        }
        /// <summary>
        /// FindGenomicRange 100% on Codility
        /// </summary>
        /// <param name="S">DNA string</param>
        /// <param name="P">starting index</param>
        /// <param name="Q">ending index</param>
        /// <returns></returns>
        private static int[] FindGenomicRange(string S, int[] P, int[] Q) {
            var result = new int[P.Length];
            var dic = BuildPrefixArrayDic(S);
            var a = dic['A'];
            var c = dic['C'];
            var g = dic['G'];
            var t = dic['T'];
            for (var i = 0; i < P.Length; i++) {
                if (a[Q[i] + 1] - a[P[i]] > 0) {
                    result[i] = 1;
                } else if (c[Q[i] + 1] - c[P[i]] > 0) {
                    result[i] = 2;
                } else if (g[Q[i] + 1] - g[P[i]] > 0) {
                    result[i] = 3;
                } else {
                    result[i] = 4;
                }
            }

            return result;
        }

        /// <summary>
        /// Build dictionary of 4 prefix sum arrays
        /// </summary>
        /// <param name="DNA">String of DNA</param>
        /// <returns>dictionary of 4 prefix sum arrays</returns>
        private static Dictionary<char, long[]> BuildPrefixArrayDic(string DNA) {
            var n = DNA.Length + 1;
            var dic = new Dictionary<char, long[]>() {
                { 'A', new long[n] }, { 'C', new long[n] }, { 'G', new long[n] }, { 'T', new long[n] }
            };
            // Build dictionary of 4 prefix sum arrays
            for (var i = 1; i < DNA.Length + 1; i++) {
                var key = DNA[i - 1];
                foreach (var d in dic) {
                    if (key != d.Key) {
                        dic[d.Key][i] = dic[d.Key][i - 1];
                    }
                }
                dic[key][i] = dic[key][i - 1] + 1;
            }
            return dic;
        }

        private static int[] FindGemomicRangeBruteForceLoser(string S, int[] P, int[] Q) {
            var result = new int[P.Length];
            var dic = new Dictionary<char, int>();
            var s = "ACGT";
            for (var i = 0; i < s.Length; i++) {
                dic.Add(s[i], i + 1);
            }
            int min;
            for (var i = 0; i < P.Length; i++) {
                min = 5;
                s = S.Substring(P[i], Q[i] - P[i] + 1);
                var h = new HashSet<char>(s);
                //Console.WriteLine($"For [{P[i]}-{Q[i]}]: {s}->{h.ToStringX()}");
                foreach (var c in h) {
                    min = Math.Min(min, dic[c]);
                }
                result[i] = min;
            }

            return result;
        }

        public static void MinAvgTwoSlice() {
            var list = new string[] {
                "2 1 5 2 -1 -3 -1",
                "3 1 2",
                "4 2 2 5 1 5 8 1 2",
                "4 2 2 1 5 1 5 8",
                "4 2 2 5 1 5 8",
            };
            foreach (var s in list) {
                var a = s.ToArray<int>();
                Console.WriteLine($"For [{s}], min avg starting position is");
                Console.WriteLine($"{MinAvgTwoSlice(a)}");
            }
        }
        static int MinAvgTwoSlice(int[] A) {
            var minIndex = 0;
            var p = new long[A.Length + 1];
            var min = float.MaxValue;

            /* Correct, but takes too much time
            p[1] = A[0];
             for (var i = 2; i < p.Length; i++) {
                 p[i] = p[i - 1] + A[i - 1];

                 for (var j = 1; j < i; j++) {
                     var avg = (float)(p[i] - p[j - 1]) / (i - j + 1);
                     Console.WriteLine($"avg from {j - 1} to {i - 1} is {avg}");
                     if (avg < min) {
                         min = avg;
                         minIndex = j - 1;
                     }
                 }
             }
             */
            for (var i = 1; i < p.Length; i++) {
                p[i] = p[i - 1] + A[i - 1];
            }
            for (var i = 0; i < p.Length - 1; i++) {
                for (var j = i + 1; j < p.Length - 1; j++) {
                    var avg = (float)(p[j + 1] - p[i]) / (j - i + 1);
                    Console.WriteLine($"avg from {i} to {j} is {avg}");
                    if (avg < min) {
                        min = avg;
                        minIndex = i;
                    }
                }
            }

            Console.WriteLine($"minIndex = {minIndex}");
            return minIndex;
        }
    }
}
