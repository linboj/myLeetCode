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
    public ListNode DeleteDuplicates(ListNode head)
    {
        if (head == null) return null;
        ListNode node0 = new ListNode(0, head);
        ListNode prev = node0;

        while (prev != null)
        {
            if (prev.next != null && prev.next.next != null && prev.next.val == prev.next.next.val)
            {
                var duplicateValue = prev.next.val;
                while (prev.next != null && prev.next.val == duplicateValue) prev.next = prev.next.next;
            }
            else
            {
                prev = prev.next;
            }
        }
        return node0.next;
    }
}