using System;
using System.Collections.Generic;
using System.Linq;
using static Utilities.Utils;
using static Utilities.IEnumerableExtensions;

namespace CodingChallenge
{
    internal static class Sorting
    {
        /// <summary>
        /// Riffles a List<T> (i.e. deck of cards)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="deck">The List of T items</param>
        /// <param name="midPointVariance">deck will be split at the midpoint plus or minus random integer between 0 and midPointVariance</param>
        /// <returns>riffled List</returns>
        public static List<T> RiffleDeck<T>(List<T> deck, int midPointVariance = 0)
        {
            var riffled = new List<T>();
            var rnd = GetRandom();
            //var midCard = (deck.Count / 2) + rnd.Next(-midPointVariance, midPointVariance + 1);
            var midCard = GetVariedMidPoint(deck.Count, midPointVariance);

            midCard = Math.Max(0, Math.Min(deck.Count, midCard));
            while (deck.Count > 0)
            {
                var cards = rnd.Next(1, 3);
                if (cards > midCard)
                {
                    cards = midCard;
                }
                for (var k = 0; k < cards; k++)
                {
                    riffled.Add(deck[k]);
                    deck.RemoveAt(k);
                }
                midCard -= cards;

                cards = rnd.Next(1, 3);
                if (cards > deck.Count)
                {
                    cards = deck.Count;
                }
                for (var k = midCard; k < midCard + cards; k++)
                {
                    riffled.Add(deck[k]);
                    deck.RemoveAt(k);
                }
            }
            return riffled;
        }

        public static void MaxToys()
        {
            var dic = new Dictionary<int, int[]> {
                { 50, new [] { 1, 12, 5, 111, 200, 1000, 10 } },
                { 100, new [] { 1, 12, 5, 111, 200, 1000, 10 } },
                { 1000, new [] { 1, 12, 5, 111, 200, 1000, 10 } }
            };
            foreach (var t in dic)
            {
                Console.WriteLine($"With {t.Key} and prices are {t.Value.ToStringX()}, max is {MaxToys(t.Value, t.Key)}");
            }
        }

        private static int MaxToys(int[] prices, int k)
        {
            int max = 0;
            var l = prices.ToList();
            l.Sort();
            int total = 0;
            foreach (var p in l)
            {
                total += p;
                if (total < k)
                    max++;
                else break;
            }
            return max;
        }

        public delegate int[] sort(int[] a);

        public static Func<int[], int[]> sortFunc;
        public static void SortComparison()
        {
            var listOfLists = new List<List<int>>() {
                new List<int>() { 5, 2, 8, 1 },
                new List<int>() { 5, 2, 8, 14, 1, 6, 1, 37, 32, 25, 42, 41, 17, 27, 22, 12, 19, 45, 35 },
                new List<int>() { -2, 2, 1, 3, -1, 1 },
                GetIntArray(1000).Randomize().ToList(),
                GetIntArray(10000).Randomize().ToList(),
                GetIntArray(100000).Randomize().ToList(),
                GetIntArray((int)1E6).Randomize().ToList()
            };
            var sorts = new List<sort>() { BubbleSort, InsertionSort, SelectionSort, MergeSortMultipleDrD, MergeSort };

            var watch = new System.Diagnostics.Stopwatch();
            foreach (List<int> list in listOfLists)
            {
                foreach (sort sort in sorts)
                {
                    if (list.Count > 10000 && sort.Method.Name != "MergeSort")
                    {
                        continue;
                    }
                    int[] a = list.ToArray();
                    watch.Restart();
                    int[] sorted = sort(a);
                    watch.Stop();
                    Console.WriteLine($"{sort.Method.Name}: {aStr(a)} sorted={aStr(sorted)} time={watch.ElapsedMilliseconds}");
                }
            }
            Console.WriteLine();
        }

        private static int[] BubbleSort(int[] a)
        {
            int n = a.Length;
            for (int i = 0; i < n; i++)
            {
                bool swapHappened = false;
                for (int j = 0; j < n - 1; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        int temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                        swapHappened = true;
                    }
                }
                if (!swapHappened) break;
            }
            return a;
        }

        public static int[] InsertionSort(int[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (a[j] < a[j - 1])
                    {
                        var temp = a[j - 1];
                        a[j - 1] = a[j];
                        a[j] = temp;
                    }
                }
            }
            return a;
        }

        private static int[] SelectionSort(int[] a)
        {
            int n = a.Length;
            for (int i = 0; i < n; i++)
            {
                int indexOfMin = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (a[j] < a[indexOfMin])
                        indexOfMin = j;
                }
                if (indexOfMin != i)
                {
                    int newMin = a[indexOfMin];
                    a[indexOfMin] = a[i];
                    a[i] = newMin;
                }
            }
            return a;
        }


        public static void MergeSortMultipleDrD()
        {
            var str = "3 13 5 6 8 10 11 9 15 1 2 4 7 12 14 13 15 17 19 16 18 20 19 18 17 16";
            var a = str.ToArray<int>();
            var result = MergeSortMultipleDrD(a);
            Console.WriteLine($"Given : [{str}]\nSorted: {result.ToStringX()}");
        }

        public static int[] MergeSortMultipleDrD(int[] inputArray)  // this is a loser
        {
            var bigQ = new Queue<Queue<int>>();
            var i = 0;
            while (i < inputArray.Length)
            {
                var q = new Queue<int>();
                q.Enqueue(inputArray[i]);
                while (i < inputArray.Length - 1 && inputArray[i + 1] >= inputArray[i])
                {
                    q.Enqueue(inputArray[++i]);
                }
                bigQ.Enqueue(q);
                i++;
            }
            var qCount = bigQ.Count;
            var arrays = new int[qCount][];
            for (i = 0; i < qCount; i++)
            {
                arrays[i] = bigQ.Dequeue().ToArray<int>();
            }

            var sorted = new int[inputArray.Length];
            int[] indices = new int[arrays.Length]; // keep unique pointer for each array
            int index = 0;
            while (index < inputArray.Length)
            {
                int minValue = int.MaxValue;
                int minIndex = 0;
                // loop through the values pointed to by the indices, finding the minimum value and the index at which it occurred
                for (i = 0; i < arrays.Length; i++)
                {
                    // if the pointer is within range and its value is less than the current min, make it the new min
                    if (indices[i] < arrays[i].Length && arrays[i][indices[i]] < minValue)
                    {
                        minValue = arrays[i][indices[i]];
                        minIndex = i;
                    }
                }
                indices[minIndex]++;  //increase the pointer at minIndex
                sorted[index++] = minValue;   // store the min value
            }
            return sorted;
        }

        private static int[] MergeSort(int[] a)
        {
            if (a.Length <= 1) return a;
            var mid = a.Length / 2;
            var left = new int[mid];
            var right = new int[a.Length - mid];
            for (int i = 0; i < left.Length; i++)
            {
                left[i] = a[i];
            }
            for (int i = 0; i < right.Length; i++)
            {
                right[i] = a[mid + i];
            }
            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        public static void TestMergeSort()
        {
            int n = 32;
            var a = GetIntArray(n).Randomize();
            MergeSortTest(a);
            Console.WriteLine(Math.Log(n, 2));
        }

        private static int[] MergeSortTest(int[] a, int level = -1, string side = "original array")
        {
            level++;
            string msg;
            if (a.Length <= 1)
            {
                //SayIndented(level, $"Returning {side} {a.ToStringX()} (base case)");
                return a;
            }
            else
            {
                msg = $"Dividing {side} {aStr(a)} into";
            }
            var n = a.Length / 2;
            var left = new int[n];
            var right = new int[a.Length - n];
            for (int i = 0; i < left.Length; i++)
            {
                left[i] = a[i];
            }
            for (int i = 0; i < right.Length; i++)
            {
                right[i] = a[n + i];
            }

            SayIndented(level, $"{msg} {aStr(left)} {aStr(right)}");

            // at the base case, these do nothing
            left = MergeSortTest(left, level, "left");
            right = MergeSortTest(right, level, "right");

            var merged = Merge(left, right);
            SayIndented(level, $"merge {aStr(left)} {aStr(right)} -> {aStr(merged)}");

            return merged;
        }


        private static int[] Merge(int[] left, int[] right)
        {
            int iLeft = 0;
            int iRight = 0;
            int i = 0;
            var result = new int[left.Length + right.Length];
            while (iLeft < left.Length && iRight < right.Length)
            {
                if (left[iLeft] < right[iRight])
                    result[i++] = left[iLeft++];
                else
                    result[i++] = right[iRight++];
            }
            while (iLeft < left.Length)
            {
                result[i++] = left[iLeft++];
            }
            while (iRight < right.Length)
            {
                result[i++] = right[iRight++];
            }

            return result;
        }

        private static void CountingSort(int[] a, int k)
        {
            var n = a.Length;
            Console.WriteLine($"CountingSort\n{a.ToStringX()}");
            var b = new int[k + 1];
            for (int i = 0; i < n; i++)
            {
                b[a[i]]++;
            }
            int index = 0;
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] > 0)
                {
                    for (int j = 0; j < b[i]; j++)
                    {
                        a[index++] = i;
                    }
                    Console.WriteLine($"{i} {a.ToStringX()}");
                }
            }
        }

        public static void DistinctAndDupes()
        {
            var list = new List<List<int>>();
            list.Add(new List<int>() { 2, 2, 1, 3, 1, 1 });
            list.Add(new List<int>() { -2, 2, 1, 3, -1, 1 });
            foreach (var l in list)
            {
                var a = l.ToArray();
                Console.WriteLine($"{a.ToStringX()} distinct = {NumberOfDistinctValues(a)},  dupes = {NumberOfDupes(a)}");
            }
        }


        public static void ContainsTrianglar()
        {
            var list = new List<List<int>>();
            list.Add(new List<int>() { });
            list.Add(new List<int>() { 5, 3 });
            list.Add(new List<int>() { 5, 3, 3 });
            list.Add(new List<int>() { 10, 2, 5, 1, 8, 20 });
            list.Add(new List<int>() { 10, 50, 5, 1 });
            foreach (var l in list)
            {
                var a = l.ToArray();
                Console.WriteLine($"{a.ToStringX()} contains triangular = {ContainsTrianglar(a)}");
            }
        }

        private static int ContainsTrianglar(int[] A)
        {
            var n = A.Length;
            int t = 0;
            var l = A.ToList();
            l.Sort();
            long sum;
            if (l.Count < 3) return 0;
            for (int i = 0; i < l.Count - 2; i++)
            {
                sum = l[i] + l[i + 1];
                if (sum <= l[i + 2])
                    continue;
                sum = l[i + 1] + l[i + 2];
                if (sum <= l[i])
                    continue;
                sum = l[i + 2] + l[i];
                if (sum <= l[i + 1])
                    continue;
                t++;
            }
            return t > 0 ? 1 : 0;
        }

        public static void ComparePlayers()
        {
            var players = new List<Player>() {
            new Player(){ name="amy", score=100 },
            new Player(){ name="david", score=100 },
            new Player(){ name="heraldo", score=50 },
            new Player(){ name="aakansha", score=75 },
            new Player(){ name="aleksa", score=150 },
        };
            players.Sort(ComparePlayers);
            foreach (var p in players)
            {
                Console.WriteLine($"{p.name} {p.score}");
            }

        }

        private static int ComparePlayers(Player a, Player b)
        {
            if (a.score < b.score) return 1;
            else if (a.score > b.score) return -1;
            else
            {
                return a.name.CompareTo(b.name);
            }
        }

        private class Player
        {
            public string name;
            public int score;
        }

        public static void CountSwaps()
        {
            var list = new List<int[]> {
            new [] { 6, 4, 1 },
            new [] { 1, 2, 3 },
            new [] { 3, 2, 1 }
        };
            foreach (var a in list)
            {
                Console.WriteLine($"List {a.ToStringX()}");
                CountSwaps(a);
                Console.WriteLine($"Result: {a.ToStringX()}");
            }
        }

        private static void CountSwaps(int[] a)
        {
            int n = a.Length;
            int swaps = 0;
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < n - 1; j++)
                {
                    // Swap adjacent elements if they are in decreasing order
                    if (a[j] > a[j + 1])
                    {
                        int temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                        swaps++;
                    }
                }
            }
            Console.WriteLine($"Array is sorted in {swaps} swaps.");
            Console.WriteLine($"First Element: {a[0]}");
            Console.WriteLine($"Last Element: {a[n - 1]}");

        }
    }
}
