using System;
using System.Collections.Generic;

namespace CodingChallenge {
    class DynamicProgramming {

        public static void GetWays() {
            var coins = new long[] { 1, 2, 3 };
            long n = 4;
            var memo = new Dictionary<long, long>();
            Console.WriteLine($"For {coins.ToStringX()}, ways to make change for {n} is {GetWays(n, coins, memo)}");
        }

        private static long GetWays(long n, long[] coins, Dictionary<long, long> memo) {
            if (memo.ContainsKey(n)) return memo[n];
            long ways = 0;
            return ways;
        }

    }
}
