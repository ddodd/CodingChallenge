using System;
using System.Collections.Generic;
using System.Linq;

namespace Utilities {
    public static class IEnumerableExtensions {

        public static Random GetRandomGenerator() {
            return new Random(Guid.NewGuid().GetHashCode());
        }

        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> ie) {
            if (ie.Count() <= 1) return ie;
            var a = ie.ToArray();
            var rnd = GetRandomGenerator();
            for (int i = 0; i < a.Length; i++) {
                var j = rnd.Next(i, a.Length);
                // Swap elements i and j
                //(a[j], a[i]) = (a[i], a[j]);
                (a[i], a[j]) = (a[j], a[i]);
            }
            return a;
        }

        public static IList<T> Randomize<T>(this IList<T> L) {
            if (L.Count() > 1) {
                var rnd = GetRandomGenerator();
                for (int i = 0; i < L.Count; i++) {
                    var j = rnd.Next(i, L.Count);
                    (L[j], L[i]) = (L[i], L[j]);
                }
            }
            return L;
        }

        public static T[] Randomize<T>(this T[] a) {
            if (a.Length <= 1) return a;
            var rnd = GetRandomGenerator();
            for (int i = 0; i < a.Length; i++) {
                var j = rnd.Next(i, a.Length);
                //(a[j], a[i]) = (a[i], a[j]);
                (a[i], a[j]) = (a[j], a[i]);
            }
            return a;
        }

        public static T Pluck<T>(this IEnumerable<T> ie, bool remove = true) {
            if (ie.Count() == 0) return default;
            var index = GetRandomGenerator().Next(0, ie.Count());
            if (ie is IList<T>) return (ie as IList<T>)[index];
            var a = ie.ToArray();
            var item = a[index];
            if (remove && ie is IList<T>)
                (ie as IList<T>).RemoveAt(index);
            return item;
        }

        public static T PluckAndReplaceWith<T>(this T[] array, T replacement = default) {
            var validIndicies = new List<int>();
            for (var i = 0; i < array.Length; i++) {
                if (array[i].Equals(replacement)) continue;
                validIndicies.Add(i);
            }
            var index = validIndicies.Pluck();
            var item = array[index];
            array[index] = replacement;

            return item;
        }


        public static T[] AddToArray<T>(this T[] array, T item) {
            return array.Concat(new T[1] { item }).ToArray();
        }

        /// <summary>
        /// Casts an array of a Type to an array of its subtypes
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <typeparam name="S">SubType</typeparam>
        /// <param name="array">Array T[] </param>
        /// <returns>Array as Array of SubTypes S[]</returns>
        public static S[] Cast<T, S>(this T[] array) where S : T {
            return array.Select(a => (S)a).ToArray();
        }

    }
}
