/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    public ListNode RotateRight(ListNode head, int k)
    {
        if (head == null || k == 0) return head;

        ListNode tail = head;
        int length = 1;
        while (tail.next != null)
        {
            length++;
            tail = tail.next;
        }

        tail.next = head;

        k = length - k % length;

        for (int i = 0; i < k; i++)
        {
            head = head.next;
            tail = tail.next;
        }

        tail.next = null;

        return head;
    }
}