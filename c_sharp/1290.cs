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
    public int GetDecimalValue(ListNode head)
    {
        int ans = 0;
        ListNode current = head;
        while (current != null)
        {
            ans *= 2;
            ans += current.val;
            current = current.next;
        }
        return ans;
    }
}