using System;
using System.Collections.Generic;

namespace CodingChallenge {
    class Strings {

        public static void Anagrams() {
            var list = new List<Tuple<string, string>>() {
                new Tuple<string, string> ("cdeeed","abc"),
                new Tuple<string, string> ("fcrxzwscanmligyxyvym","jxwtrhvujlmrpdoqbisbwhmgpmeoke"),
                new Tuple<string, string> ("cde","abc"),
                new Tuple<string, string> ("cde","dcf"),
            };
            list.ForEach(t => Console.WriteLine($"{t.Item1} and {t.Item2}, deletions = {Anagrams(t.Item1, t.Item2)}"));
        }

        private static int Anagrams(string a, string b) {
            int deletions = 0;
            var countA = new Dictionary<char, int>();

            foreach (char c in a) {
                if (countA.ContainsKey(c)) {
                    countA[c]++;
                } else {
                    countA.Add(c, 1);
                }
            }

            var countB = new Dictionary<char, int>();
            foreach (char c in b) {
                if (countB.ContainsKey(c)) {
                    countB[c]++;
                } else {
                    countB.Add(c, 1);
                }
            }

            foreach (var kv in countA) {
                char c = kv.Key;
                int d = countA[c];
                if (!countB.ContainsKey(c)) {
                    deletions += d;
                } else {
                    deletions += Math.Abs(countA[c] - countB[c]);
                }
            }

            foreach (var kv in countB) {
                char c = kv.Key;
                int d = countB[c];
                if (!countA.ContainsKey(c)) {
                    deletions += d;
                }
            }

            return deletions;
        }

        public static void AlternatingCharacters() {
            var list = new List<string>() { "AAAA", "BBBBB", "ABABABAB", "BABABA", "AAABBB" };
            foreach (string s in list) {
                Console.WriteLine($"{s} min deletions = {MinDeletions(s)}");
            }
        }

        private static int MinDeletions(string s) {
            int min = 0;
            char target = s[0];
            for (int i = 1; i < s.Length; i++) {
                if (s[i] == target) {
                    min++;
                } else {
                    target = s[i];
                }
            }

            return min;
        }

        private static int MinDeletions0(string a) {
            int min = 0;
            var stack = new Stack<int>();
            stack.Push(a[0]);
            for (int i = 1; i < a.Length; i++) {
                char c = a[i];
                if (c == stack.Peek()) {
                    min++;
                } else {
                    stack.Push(a[i]);
                }
            }

            return min;
        }

        public static void RepeatedString() {
            var dic = new Dictionary<string, long> {
            { "aba", 10 },
            { "a", 1000000000000 }
        };
            foreach (var d in dic) {
                string s = d.Key;
                long n = d.Value;
                Console.WriteLine($"For {s},{n}: {RepeatedString(s, n)}");
            }
        }

        private static long RepeatedString(string s, long n) {
            long r = 0;
            int aTotal = 0;
            foreach (char c in s) {
                if (c == 'a') {
                    aTotal++;
                }
            }
            long mult = n / s.Length;
            r = aTotal * mult;
            long remaining = n % s.Length;
            aTotal = 0;
            for (int i = 0; i < remaining; i++) {
                if (s[i] == 'a') {
                    aTotal++;
                }
            }
            r += aTotal;
            return r;
        }

        public static void FindCloudHops() {
            string[] list = new string[] {
                "0 0 1 0 0 1 0",
                "0 0 0 0 0 1 0",
                "0 0 1 0 0 1 0 1 0 1 0 1 0",
                "0 0 0 0 1 0 0 0 0 0 1 0 0 0 0"
            };
            list.ForEach(s => Console.WriteLine($"{s} -> {FindCloudHops(s.ToArray<int>())}"));
        }

        private static int FindCloudHops(int[] c) {
            int hops = 0;
            int dist = 0;
            for (int i = 0; i < c.Length - 1; i++) {
                if (c[i] == 0) {
                    dist++;
                } else {
                    dist--;
                    hops += (dist / 2 + dist % 2) + 1;
                    dist = 0;
                }
            }
            hops += (dist / 2 + dist % 2);
            return hops;
        }

        private static int FindCloudHops0(int n, string s) {
            int hops = 0;
            string str = s.Replace(" ", string.Empty);
            str = str.Substring(1, str.Length - 2);
            string[] stra = str.Split(' ');
            for (int i = 0; i < stra.Length; i++) {
                int dist = stra[i].Length;
                hops += dist / 2 + dist % 2;
            }
            hops += stra.Length;
            return hops;
        }

        public static void FindValleys() {
            string[] list = new string[] {
            "UDDDUDUU",
            "UDDDUDUUUDDDUDUU"
        };
            foreach (string s in list) {
                Console.WriteLine($"{s} -> {FindValleys(s.Length, s)}");
            }
        }

        private static int FindValleys(int n, string s) {
            int v = 0;
            int level = 0;
            for (int i = 0; i < n; i++) {
                char step = s[i];
                if (step == 'U') {
                    level++;
                }

                if (step == 'D') {
                    if (level == 0) {
                        v++;
                    }

                    level--;
                }
            }
            return v;
        }



    }
}
