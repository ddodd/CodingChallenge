using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge
{
    class DictionariesAndHashMaps
    {

        public static void FindNumberOfPairs()
        {
            string[] list = new string[] {
                "1 2 1 2 1 3 2",
                "10 20 20 10 10 30 50 10 20",
                "1 2 1 2 1 3 2 3 2 1 1 1 2 3 3 3",
                "1 1 3 1 2 1 3 3 3 3"
            };
            /*
            foreach (string s in list) {
                int[] ar = s.ToArray<int>();
                Console.WriteLine($"{s} -> {FindNumberOfPairs(ar.Length, ar)}");
            }
            */
            list.ForEach(s => { int[] a = s.ToArray<int>(); Console.WriteLine($"[{s}] -> {FindNumberOfPairs(a)}"); });
        }

        private static int FindNumberOfPairs(int[] a)
        {
            int pairs = 0;
            var hash = new HashSet<int>();
            for (int i = 0; i < a.Length; i++)
            {
                int value = a[i];
                if (hash.Contains(value))
                {
                    pairs++;
                    hash.Remove(value);
                }
                else
                {
                    hash.Add(value);
                }
            }
            return pairs;
        }

        public static void StringsShareSubstring()
        {
            var list = new List<string[]> {
                new[] {"hello","world"},
                new[] {"hi","worldly bastard"},
                new[] {"Jesus","rockabilly"},
                new[] {"elba","able"}
            };
            Console.WriteLine("Strings Share Substring");
            list.ForEach(s => Console.WriteLine($"For s1='{s[0]}' and s2='{s[1]}' {StringsShareSubstring(s[0], s[1])}"));
        }

        /// <summary>
        /// Determines if two strings share a common substring.
        /// </summary>
        /// <param name="s1">The first string.</param>
        /// <param name="s2">The second string.</param>
        /// <returns>"YES" if the strings share a common substring, otherwise "NO"".</returns>
        private static string StringsShareSubstring(string s1, string s2)
        {
            return StringsShareSubstring2(s1, s2) ? "YES" : "NO";
        }

        /// <summary>
        /// Determines if two strings share a common substring.
        /// </summary>
        /// <param name="s1">The first string.</param>
        /// <param name="s2">The second string.</param>
        /// <returns>True if the strings share a common substring, otherwise false.</returns>
        public static bool StringsShareSubstring2(string s1, string s2)
        {
            var h1 = new HashSet<char>(s1);
            var h2 = new HashSet<char>(s2);
            h1.IntersectWith(h2);
            return h1.Count > 0;
        }

        public static void SentencesShareWord()
        {
            var list = new List<string[]>
            {
                new[] {"hello world","world"},
                new[] {"hello world","you worldly bastard"},
                new[] {"Jesus loves rockabilly","rockabilly sucks"},
                new[] {"Able was I ere I saw elba","able"}
            };
            Console.WriteLine("Sentences Share Word");
            list.ForEach(s => Console.WriteLine($"For s1='{s[0]}' and s2='{s[1]}' {SentencesShareWord(s[0], s[1])}"));
        }


        private static bool SentencesShareWord(string s1, string s2, bool ignoreCase = true)
        {
            var h1 = new HashSet<string>(s1.Split(' '));
            var h2 = new HashSet<string>(s2.Split(' '));
            if (ignoreCase)
            {
                h1 = new HashSet<string>(h1.Select(w => w.ToLower()));
                h2 = new HashSet<string>(h2.Select(w => w.ToLower()));
            }
            h1.IntersectWith(h2);
            return h1.Count > 0;
        }

        // write tests for WordsSentencesShare
        public static void WordsSentencesShare()
        {
            var list = new List<string[]>
            {
                new[] {"hello world","world"},
                new[] {"hello world","you worldly bastard"},
                new[] {"Jesus loves rockabilly","rockabilly sucks"},
                new[] {"Able was I ere I saw elba","I was able"}
            };
            Console.WriteLine("Words Sentences Share");
            list.ForEach(s => Console.WriteLine($"For s1='{s[0]}' and s2='{s[1]}' {WordsSentencesShare(s[0], s[1])}"));
        }

        private static string WordsSentencesShare(string s1, string s2, bool ignoreCase = true)
        {
            var h1 = new HashSet<string>(s1.Split(' '));
            var h2 = new HashSet<string>(s2.Split(' '));
            if (ignoreCase)
            {
                h1 = new HashSet<string>(h1.Select(w => w.ToLower()));
                h2 = new HashSet<string>(h2.Select(w => w.ToLower()));
            }
            h1.IntersectWith(h2);
            return h1.ToStringX();
        }



        /// <summary>
        /// We have a magazine with words and a note possibly constructed from the magazine
        /// The goal is to determine if this note was constructed using this magazine
        /// words can only be used (removed from magazine) once
        /// </summary>
        public static void Ransom()
        {
            var list = new List<string[]> {
                new string[2] {
                "Governor announced today that she'll give one grand prize to the winner",
                "give one grand today"
            },
                new string[2] {
                "two times three is not four",
                "two times two is four"
            },
                new string[2] {
                "I've got a lovely bunch of coconuts",
                "I've got some coconuts"
            }
            };
            list.ForEach(s => Console.WriteLine($"mag={s[0]}\nnote={s[1]}, \nCan make note: {NoteWordsInMagazine(s[0].ToArray<string>(), s[1].ToArray<string>())}"));
        }

        /// <summary>
        /// Make a Dictionary of words and number of occurrances of each
        /// Process the note, removing each occurrance of the word from the Dictionary
        /// </summary>
        /// <param name="magazine"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        private static string NoteWordsInMagazine(string[] magazine, string[] note)
        {
            var magWords = new Dictionary<string, int>();
            foreach (var word in magazine)
            {
                if (magWords.ContainsKey(word))
                {
                    magWords[word]++;
                }
                else
                {
                    magWords.Add(word, 1);
                }
            }
            foreach (string noteWord in note)
            {
                if (magWords.ContainsKey(noteWord) && magWords[noteWord] > 0)
                {
                    magWords[noteWord]--;
                }
                else
                {
                    return "No";
                }
            }
            return "Yes";
        }

        
        /// Make a Dictionary of words and number of occurrences of each.
        /// Process the note, removing each occurrence of the word from the Dictionary.
        /// </summary>
        /// <param name="magazine">The magazine string.</param>
        /// <param name="note">The note string.</param>
        /// <returns>"Yes" if the note can be constructed from the magazine, otherwise "No".</returns>
        private static string NoteWordsInMagazine2(string magazine, string note)
        {
            var wordCount = new Dictionary<string, int>();
            var magWords = magazine.Split(' ');
            var noteWords = note.Split(' ');
            foreach (var word in magWords)
            {
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                }
                else
                {
                    wordCount.Add(word, 1);
                }
            }
            foreach (string word in noteWords)
            {
                if (wordCount.ContainsKey(word) && wordCount[word] > 0)
                {
                    wordCount[word]--;
                }
                else
                {
                    return "No";
                }
            }
            return "Yes";
        }

    }
}
