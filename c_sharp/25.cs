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
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        ListNode dummy = new ListNode(-1);
        dummy.next = head;
        ListNode prev = dummy;
        ListNode current = prev.next;
        int count = 0;

        while (current != null && current.next != null)
        {
            while (count < k - 1)
            {
                var next = current.next;
                if (next == null) break;
                current.next = next.next;
                next.next = prev.next;
                prev.next = next;
                count++;
            }
            if (count != k - 1) break;
            count = 0;
            prev = current;
            current = prev.next;
        }
        if (count != k - 1){
            current = prev.next;
            for (int i = count; i > 0; i--){
                var next = current.next;
                current.next = next.next;
                next.next = prev.next;
                prev.next = next;
            }
        }

        return dummy.next;
    }
}