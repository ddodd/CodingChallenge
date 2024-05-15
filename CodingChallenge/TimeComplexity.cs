using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge {
    class TimeComplexity {

        public static void FindMissingElements() {
            var list = new List<int[]> {
                new int[0],
                new[] { 2, 3, 1, 5 },
                new[] { 2, 3, 1, 5, 4, 6, 8 }
            };
            /*
            List<int> bigList = new [];
            uint missingInt = 1;
            for (int i = 1; i <= 100000; i++) {
                if (i != missingInt) {
                    bigList.Add(i);
                }
            }
            list.Add(bigList);
            */
            foreach (int[] l in list) {
                int[] a = l.ToArray();
                Console.WriteLine($"Missing element in {string.Join(", ", a)} is {FindMissingElementN(a)}");
            }
        }

        private static int FindMissingElementN(int[] A) {
            long sum = 0;
            foreach (int i in A) {
                sum += i;
            }
            int n = A.Length + 1;
            long permSum = n * (n + 1) / 2;
            return (int)(permSum - sum);
        }

        private static int FindMissingElement2N(int[] A) {
            int element = 0;
            bool[] b = new bool[A.Length + 1];
            foreach (int i in A) {
                b[i - 1] = true;
            }
            for (int i = 0; i < b.Length; i++) {
                if (!b[i]) {
                    element = i + 1;
                    break;
                }
            }
            return element;
        }

        public static void FindJumpTime() {
            var dic = new Dictionary<int[], int> {
            { new [] { 1, 3, 1, 5, 4, 2, 5, 4 }, 6 },
            { new [] { 1, 1, 2, 1, 3, 1 }, 3 },
            { new [] { 1, 3, 1, 4, 2, 3, 5, 4 }, 5 },
            { new [] { 7, 3, 7, 6, 4, 2, 3, 1, 3, 4, 1, 3, 5, 4 }, 7 },
            { new [] { 7, 3, 7, 6, 4, 2, 3, 1, 3, 4, 1, 3, 4, 7, 3, 7, 6, 4, 2, 3, 1, 3, 4, 1, 3, 5, 4, 8 }, 8 }
        };
            foreach (var d in dic) {
                int[] a = d.Key.ToArray();
                int x = d.Value;
                Console.WriteLine($"For leaf {x} in array ({a.Length}) {a.ToStringX()}:, jump = {FrogPondJump(x, a)}");
            }
        }

        private static int FrogPondJump(int X, int[] A) {
            bool[] memo = new bool[X];
            int sumPerm = X * (X + 1) / 2;
            int sum = 0;
            for (int i = 0; i < A.Length; i++) {
                int leaf = A[i];
                if (!memo[leaf - 1]) {
                    memo[leaf - 1] = true;
                    sum += leaf;
                    if (sum == sumPerm) {
                        return i;
                    }
                }
            }
            return -1;
        }

        public static void FindMinDif() {
            var list = new List<int[]>();
            var bigList = new List<int>();
            for (int i = 1; i <= 9; i++) {
                bigList.Add(-1000);
            }
            list.Add(bigList.ToArray());
            foreach (int[] l in list) {
                int[] a = l.ToArray();
                Console.WriteLine($"Minimum difference in halves of {string.Join(", ", a)} is {FindMinDif(a)}");
            }
        }

        private static int FindMinDif(int[] A) {
            int min = int.MaxValue;
            int sumLeft = A[0];
            int sumRight = A[1];
            for (int i = 2; i < A.Length; i++) {
                sumRight += A[i];
            }
            min = Math.Min(min, Math.Abs(sumLeft - sumRight));
            Console.WriteLine($"sumLeft={sumLeft} sumRight={sumRight} and dif={Math.Abs(sumLeft - sumRight)}");
            for (int i = 1; i < A.Length - 1; i++) {
                sumLeft += A[i];
                sumRight -= A[i];
                min = Math.Min(min, Math.Abs(sumLeft - sumRight));
                Console.WriteLine($"sumLeft={sumLeft} sumRight={sumRight} and dif={Math.Abs(sumLeft - sumRight)}");
            }
            return min;
        }

    }
}
