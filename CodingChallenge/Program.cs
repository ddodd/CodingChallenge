using System;
namespace CodingChallenge {
    class Program {
        private static Program instance;
        System.Diagnostics.Stopwatch watch;
        static void Main(string[] args) {
            instance = new Program();
            instance.Main();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private void Main() {
            watch = new System.Diagnostics.Stopwatch();
            //Tests.TestPluckFromArray();
            //Tests.TestPluckFromList();
            //Tests.TestGetIntArray();
            // Easy
            //Easy.RemoveElementsToMakeSorted();
            //Easy.Get2Arrays(100, 0, 1000);
            //Easy.FindCommonElementsFrom2sortedArrays();
            //Easy.FindCommonElementsFrom2sortedArrays2();

            // Dynnamic Programming
            //DynamicProgramming.GetWays();

            // Arrays
            //Arrays.HourglassSum();
            //Arrays.FindSingleOddOccurance();
            //Arrays.FindTotalOddOccurances();
            //Arrays.FindAllOddOccurances();
            //Arrays.RotatetRight();
            //Arrays.RotateLeft();
            //Arrays.FindMaxSubsequenceSum();

            // Algorithms
            //Algorithms.CompareTriplets();
            //Algorithms.VeryBigSum();
            //Algorithms.DiagonalDifference();
            //Algorithms.PlusMinus();
            //Algorithms.Staircase();
            //Algorithms.MiniMaxSum();
            //Algorithms.MaxDupes();
            //Algorithms.Fibonacci();
            //Algorithms.RoundGrades();
            //Algorithms.CountApplesAndOranges();
            //Algorithms.Kangaroo();

            // Counting elements
            //CountingElements.FrogJumps();
            //CountingElements.FindPerms();
            //CountingElements.SmallestPositiveMissingInt();

            // Dictionaries and Hashmaps
            //DictionariesAndHashMaps.FindNumberOfPairs();
            //DictionariesAndHashMaps.Ransom();
            //DictionariesAndHashMaps.StringsShareSubstring();
            //DictionariesAndHashMaps.SentencesShareWord();
            //DictionariesAndHashMaps.WordsSentencesShare();

            // Iterations
            //Iterations.FindBinaryGaps();

            // Leader
            //Leader.FindLeader();

            // LinkedLists
            //LinkedLists.FindLengthOfThisLinkedList();

            // Sorting
            //Sorting.SortComparison();
            //Sorting.TestMergeSort();

            // PrefixSums and Difference Arrays
            //PrefixSumsAndDifferenceArrays.FindGenomicRange();
            //PrefixSumsAndDifferenceArrays.MinAvgTwoSlice();

            // Miscelaneous
            //Misc.FlipBits();
            //Misc.IsPrime();
            //Misc.MergeMultipleArrays();
            //Misc.UniquePairsAddUpToK();
            //Misc.TestMergeSort();

            // FindGaps(new List<int>() { 20, 32, 529, 1041, 328, 1162, 51712, 66561, 6291457, 805306373, 1610612737 });
            //RotateArrays();
            //Arrays.FindAllOddOccurances();
            //Arrays.ArrayManipulation();
            //FindMissingElements();
            //FrogJumps();
            //FindMins();
            //Counting();
            //FindPerms();
            //FindJumpTime();
            //EvaluateCounters();
            //FindMissingInt();
            //FindMushrooms();
            //FindPairs();
            //FindValleys();
            //FindCloudHops();
            //RepeatedString();
            //HourglassSum();
            //RotateLeft();
            //MinBribes();
            //MinSwaps();
            //Ransom();
            //StringsShareSubstring();
            //CountSwaps();
            Sorting.MaxToys();
            //ComparePlayers();
            //Anagrams();
            //PassingCarPairs();
            //Sorting();
            //Distinct();
            //ContainsTrianglar();

            // Stacks and Queues
            //StacksAndQueues.QueueUsingStacks();
            //StacksAndQueues.IsBalanced();
            //StacksAndQueues.Nested();
            //StacksAndQueues.ProcessCommands();
            //StacksAndQueues.Blocks();

            //PairsDifByK(new[] { 5, 5, 3, 3 }, 2);
            //PairsAddUpToK(new[] { 5, 5, 3, 3 }, 8);
            //UniquePairsAddUpToK(new[] { 5, 5, 5, 5, 3, 3, 3 }, 10);
            //FindLeader();
            //MinDeletions();
            //FindHops();
            //FindQuotient();
            //ArrayManipulation();
            //FindNumberOfSubSequencesThatSumToValue();
        }
    }
}