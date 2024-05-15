using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace CodingChallenge {
    class Tests {
        public static void TestPluckFromArray() {
            var a = new[] { 1, 3, 5, 6, 7 };
            Console.WriteLine($"Test IEnumerable<T> Pluck<T>\nOriginal Array: {a.ToStringX()}");
            a.Randomize();
            var b = a.Randomize();
            var c = a.Pluck(true);
            Console.WriteLine($"a:{a.ToStringX()}, b:{b.ToStringX()}, plucked out {c}");
        }
        public static void TestPluckFromList() {
            var list = new List<int> { 1, 3, 5, 6, 7 };
            Console.WriteLine($"Test Pluck<T> from List\nOriginal List: {list.ToStringX()}");
            list.Randomize();
            var c = list.Pluck(true);
            Console.WriteLine($"a:{list.ToStringX()}, plucked out {c}");
        }

        public static void TestGetIntArray2() {
            var a = Utils.GetSequentialIntArray(10);
            Console.WriteLine($"GetIntArray2(10):{a.ToStringX()}");
            a = Utils.GetIntArray2(10, 10, 5);
            Console.WriteLine($"GetIntArray2(10, 10, 5):{a.ToStringX()}");
            a = Utils.GetIntArray2(10, 5, 50);
            Console.WriteLine($"GetIntArray2(10, 5, 50):{a.ToStringX()}");
            a = Utils.GetIntArray2(10, -10, 10);
            Console.WriteLine($"GetIntArray2(10, -10, 10):{a.ToStringX()}");
            a = Utils.GetIntArray2(100, -10, 10, 2);
            Console.WriteLine($"GetIntArray2(100, -10, 10, 2):{a.ToStringX()}");
            a = Utils.GetIntArray2(100, -100, 100, 5);
            Console.WriteLine($"GetIntArray2(100, -100, 100, 5):{a.ToStringX()}");
        }
    }
}
