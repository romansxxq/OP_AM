using System;
using System.Collections.Generic;

namespace LinkedListAddition
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode dummyHead = new ListNode(0);
            ListNode current = dummyHead;
            int carry = 0;

            while (l1 != null || l2 != null || carry != 0)
            {
                int val1 = (l1 != null) ? l1.val : 0;
                int val2 = (l2 != null) ? l2.val : 0;

                int sum = val1 + val2 + carry;
                carry = sum / 10;

                current.next = new ListNode(sum % 10);
                current = current.next;

                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
            }

            return dummyHead.next;
        }
    }

    class Program
    {
        // Допоміжний метод: створити список з масиву
        static ListNode BuildList(int[] values)
        {
            ListNode dummy = new ListNode();
            ListNode current = dummy;

            foreach (int val in values)
            {
                current.next = new ListNode(val);
                current = current.next;
            }

            return dummy.next;
        }

        // Допоміжний метод: вивести список
        static void PrintList(ListNode node)
        {
            while (node != null)
            {
                Console.Write(node.val);
                if (node.next != null)
                node = node.next;
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введи перше число (у зворотному порядку, через пробіл):");
            int[] nums1 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            Console.WriteLine("Введи друге число (у зворотному порядку, через пробіл):");
            int[] nums2 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            ListNode l1 = BuildList(nums1);
            ListNode l2 = BuildList(nums2);

            Solution solution = new Solution();
            ListNode result = solution.AddTwoNumbers(l1, l2);

            Console.WriteLine("Результат:");
            PrintList(result);
        }
    }
}
