namespace LeetCode
{
    /*
        2. Add Two Numbers - https://leetcode.com/problems/add-two-numbers/

        You are given two non-empty linked lists representing two non-negative integers.
        The digits are stored in reverse order, and each of their nodes contains a single digit.
        Add the two numbers and return the sum as a linked list.
        You may assume the two numbers do not contain any leading zero, except the number 0 itself.
     
        Example 1:
        Input: l1 = [2,4,3], l2 = [5,6,4]
        Output: [7,0,8]
        Explanation: 342 + 465 = 807.

        Example 2:
        Input: l1 = [0], l2 = [0]
        Output: [0]

        Example 3:
        Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
        Output: [8,9,9,9,0,0,0,1]
     */
    internal class _2_Add_Two_Numbers
    {
        static ListNode AddTwoNumbers(ListNode? l1, ListNode? l2)
        {
            int carryOver = 0;
            ListNode resultNode = new ListNode();
            ListNode tempNode = resultNode;

            while (l1 != null || l2 != null)
            {
                int first  = l1 != null ? l1.val : 0;
                int second = l2 != null ? l2.val : 0;
                int sum = first + second + carryOver;
                
                carryOver = sum / 10;
                sum = sum % 10;
                
                tempNode.next = new ListNode(sum);
                tempNode = tempNode.next;

                l1 = l1?.next;
                l2 = l2?.next;
            }

            if (carryOver != 0)
                tempNode.next = new ListNode(carryOver);

            return resultNode.next;
        }

        public static void Run()
        {
            // 2 - 4 - 3 (342)
            ListNode a3 = new ListNode() { val = 3 };
            ListNode a2 = new ListNode() { val = 4, next = a3 };
            ListNode a1 = new ListNode() { val = 2, next = a2 };

            // 5 - 6 - 4 (465)
            ListNode b3 = new ListNode() { val = 4 };
            ListNode b2 = new ListNode() { val = 6, next = b3 };
            ListNode b1 = new ListNode() { val = 5, next = b2 };

            // 7 - 0 - 8 (807)
            ListNode x = AddTwoNumbers(a1, b1);

            Console.Clear();
            Console.WriteLine("2 - Add Two Numbers\n");

            Console.WriteLine("Test -> Input= [2,4,3] & [5,6,4], expected result: [7,0,8]");

            Console.Write("Result: ");
            while (x != null)
            {
                Console.Write(x.val);
                x = x.next;
            }
        }
    }

    // Definition for singly-linked list.
    class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
