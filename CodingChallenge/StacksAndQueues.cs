using System;
using System.Collections.Generic;

namespace CodingChallenge {
    class StacksAndQueues {

        public static void IsBalanced() {
            var list = new List<string>() {
            "((0))",
            "{[()()]}",
            "([)()]",
            "[{{}([])[()]}]",
        };
            list.ForEach(s => Console.WriteLine($"{s} balanced = {IsBalanced(s)}"));
        }

        static string IsBalanced(string s) {
            var d = new Dictionary<char, char> {
                { '}', '{' },
                { ']', '[' },
                { ')', '(' }
            };
            var stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++) {
                var c = s[i];
                if (!d.ContainsKey(c)) stack.Push(c);
                else {
                    if (stack.Count == 0 || stack.Pop() != d[c])
                        return "NO";
                }
            }
            if (stack.Count == 0)
                return "YES";
            return "NO";
        }

        public static void Nested() {
            var list = new List<string>() {
                "(()(())())",
                "())",
            };
            list.ForEach(s => Console.WriteLine($"{s} nested = {Nested(s)}"));
        }

        static int Nested(string S) {
            var d = new Dictionary<char, char> {
                { ')', '(' }
            };
            var stack = new Stack<char>();
            for (int i = 0; i < S.Length; i++) {
                var c = S[i];
                if (!d.ContainsKey(c))
                    stack.Push(c);
                else {
                    if (stack.Count == 0 || stack.Pop() != d[c])
                        return 0;
                }
            }
            if (stack.Count == 0)
                return 1;
            return 0;
        }

        public static void QueueUsingStacks() {
            string[] args = new[] { "10", "1", "42", "2", "1", "14", "3", "1", "28", "3", "1", "60", "1", "78", "2", "2" };
            Main1(args);
        }

        static void Main1(string[] args) {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] nm = args;

            int n = Convert.ToInt32(nm[0]);

            int[] queries = new int[args.Length];

            Array.Copy(Array.ConvertAll(args, queriesTemp => Convert.ToInt32(queriesTemp)), queries, args.Length);
            Array.Copy(queries, 1, queries, 0, args.Length - 1);

            string result = QueueUsingStacks(n, queries);
            Console.WriteLine(result);

            //textWriter.WriteLine(result);

            //textWriter.Flush();
            //textWriter.Close();
        }

        static string QueueUsingStacks(int n, int[] q) {
            string output = "";
            Array.Reverse(q);
            Stack<int> s = new Stack<int>(q);
            Queue<int> queue = new Queue<int>();
            while (s.Count > 0) {
                int query = s.Pop();
                switch (query) {
                    case 1:
                        int val = s.Pop();
                        queue.Enqueue(val);
                        break;
                    case 2:
                        queue.Dequeue();
                        break;
                    case 3:
                        if (output.Length > 0) output += $"\n{queue.Peek()}";
                        else output += $"{queue.Peek()}";
                        break;

                }
            }
            return output;
        }

        public static void ProcessCommands() {
            Console.WriteLine(ProcessCommands("13 DUP 4 POP 5 DUP + DUP + -"));
        }

        static int ProcessCommands(string S) {
            int operand = 0;
            int result = 0;
            Stack<int> s = new Stack<int>();
            List<string> commands = new List<string>(S.Split());
            foreach (string c in commands) {
                switch (c) {
                    case "DUP":
                        s.Push(s.Peek());
                        break;

                    case "POP":
                        operand = s.Pop();
                        break;

                    case "+":
                        result += s.Pop();
                        break;

                    case "-":
                        result -= s.Pop();
                        break;

                    default:
                        if (int.TryParse(c, out int i))
                            s.Push(i);
                        break;
                }
            }
            return result;
        }

        public static void LargestRectangle() {
            LargestRectangle(new[] { 1, 2, 3, 4, 5 });
        }

        static long LargestRectangle(int[] h) {
            long area = 0;
            var stack = new Stack<int>(h);

            return area;
        }


        public static void Blocks() {
            Blocks(new[] { 8, 8, 5, 7, 9, 8, 7, 4, 8 });
        }

        static int Blocks(int[] a) {
            if (a.Length == 0) return 0;
            if (a.Length == 1) return 1;
            int blocks = 0;
            var stack = new Stack<int>();
            for (int i = 0; i < a.Length; i++) {
                int height = a[i];

                // remove all blocks that are too tall (higher than target height)
                while (stack.Count > 0 && stack.Peek() > height)
                    stack.Pop();

                if (stack.Count == 0 || stack.Peek() != height) {
                    blocks++;
                    stack.Push(height); // record height
                }
            }
            return blocks;
        }



    }
}
