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
    public ListNode Partition(ListNode head, int x)
    {
        ListNode smaller = new ListNode(0);
        var curSmaller = smaller;
        ListNode notSmaller = new ListNode(0);
        var curNotSmaller = notSmaller;

        ListNode cur = head;

        while (cur != null)
        {
            if (cur.val < x)
            {
                curSmaller.next = cur;
                curSmaller = curSmaller.next;
            }
            else
            {
                curNotSmaller.next = cur;
                curNotSmaller = curNotSmaller.next;
            }
            cur = cur.next;
        }

        curSmaller.next = notSmaller.next;
        curNotSmaller.next = null;

        return smaller.next;

    }
}