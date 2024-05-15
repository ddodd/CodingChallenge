using System;
using System.Collections.Generic;

namespace CodingChallenge {
    class Leader {

        public static void FindLeader() {
            var list = new List<List<int>>();
            list.Add(new List<int>() { });
            list.Add(new List<int>() { 5, 3 });
            list.Add(new List<int>() { 5, 3, 3 });
            list.Add(new List<int>() { 10, 2, 5, 1, 8, 20, 5, 5, 5, 5, 5 });
            list.Add(new List<int>() { 4, 6, 6, 6, 6, 8, 8 });
            foreach (var l in list) {
                var a = l.ToArray();
                Console.WriteLine($"{a.ToStringX()} leader = {FindLeaderDrD(a)}");
            }
        }

        private static int FindLeader(int[] a) {
            int n = a.Length;
            int size = 0;
            int value = 0;
            foreach (var k in a) {
                if (size == 0) {
                    size++;
                    value = k;
                } else
                    if (value == k)
                    size++;
                else
                    size--;
            }
            int candidate = -1;
            if (size > 0) candidate = value;
            int leader = -1;
            int count = 0;
            foreach (var k in a) {
                if (k == candidate) count++;
            }
            if (count > n / 2) leader = candidate;

            return leader;
        }

        private static int FindLeaderDrD(int[] a) {
            int leader = -1;
            int n = a.Length / 2;
            var dic = new Dictionary<int, int>();
            foreach (var i in a) {
                if (dic.ContainsKey(i)) {
                    dic[i]++;
                    if (dic[i] > n) {
                        leader = i;
                        break;
                    }
                } else
                    dic.Add(i, 1);
            }
            return leader;
        }

    }
}
