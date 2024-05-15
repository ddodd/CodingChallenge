using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge {

    class Iterations {

        public static void FindBinaryGaps() {
            var values = new List<int>() { 20, 32, 529, 1041, 328, 1162, 51712, 66561, 6291457, 805306373, 1610612737 };
            foreach (int v in values) {
                int gap = FindBinaryGapsInInteger(v, out string binary);
                Console.WriteLine($"For {v} ({binary}), gap is {gap}");
            }
        }

        private static int FindBinaryGapsInInteger(int N, out string binary) {
            binary = Convert.ToString(N, 2);
            bool[] bools = binary.Select(b => b == '1').ToArray();

            int index = 0;
            int max = 0;
            while (index < bools.Length - 1) {
                if (bools[index]) {
                    int cur = index + 1;
                    int count = 0;
                    if (cur < bools.Length) {
                        while (!bools[cur]) {
                            count++;
                            cur++;
                            if (cur > bools.Length - 1) {
                                count = 0;
                                break;
                            }
                        }
                        max = Math.Max(max, count);
                        index = cur;
                    }
                } else
                    index++;
            }
            return max;
        }
    }
}
