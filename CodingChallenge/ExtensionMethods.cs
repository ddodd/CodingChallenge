using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingChallenge {

    static class ExtensionMethods {
        /// <summary>
        /// creates a string from an IEnumberable<T> separated by sep
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="ie">this IEnumberable</param>
        /// <param name="sep">separater used between values in string</param>
        /// <returns>string</returns>
        public static string ToStringX<T>(this IEnumerable<T> ie, string sep = " ") {
            return $"[{string.Join(sep, ie)}]";
        }

        /// <summary>
        /// Creates array (T[]) from a string of values delimited by sep
        /// </summary>
        /// <typeparam name="T">type of array to produce</typeparam>
        /// <param name="s">this string</param>
        /// <param name="sep">separater used between values in string</param>
        /// <returns></returns>
        public static T[] ToArray<T>(this string s, char sep = ' ') where T : IConvertible {
            return s.ToIEnumerable<T>(sep).ToArray();
        }

        /// <summary>
        /// Creates IEnumerable<T> from a string of values delimited by sep
        /// </summary>
        /// <typeparam name="T">type of IEnumerable<T> to produce</typeparam>
        /// <param name="s">this string</param>
        /// <param name="sep">separater used between values in string</param>
        /// <returns></returns>
        public static IEnumerable<T> ToIEnumerable<T>(this string s, char sep = ' ') where T : IConvertible {
            return s.Split(sep).Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }

        /// <summary>
        /// Iterates over an IEnumerable<T> and performes an action on each element
        /// </summary>
        /// <typeparam name="T">type of element</typeparam>
        /// <param name="collection">this IEnumerable<T></param>
        /// <param name="action">action to be performed on each element</param>
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action) {
            foreach (T item in collection)
            {
                action(item);
            }
        }

    }
}
