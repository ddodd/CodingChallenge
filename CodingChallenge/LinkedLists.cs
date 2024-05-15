using System.Collections.Generic;

namespace CodingChallenge {
    class LinkedLists {
        public static void FindLengthOfThisLinkedList() {
            FindLengthOfLinkedList(new int[5] { 1, 4, -1, 3, 2 });
        }

        private static int FindLengthOfLinkedList(int[] a) {
            if (a.Length < 2) return a.Length;
            int val = a[0];
            int length = 1;
            while (val != -1) {
                val = a[val];
                length++;
            }
            return length;
        }

        static LinkedListNode<int> InsertNodeAtPosition(LinkedListNode<int> head, int data, int position) {
            var newNode = new LinkedListNode<int>(data);
            var node = head;
            var i = 0;
            while (node.Next != null) {
                if (i == position) {
                    newNode = node.List.AddAfter(node, data);
                }
                node = node.Next;
                i++;

            }
            return newNode;
        }
    }
}
