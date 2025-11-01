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
    public ListNode ModifiedList(int[] nums, ListNode head)
    {
        HashSet<int> numSet = new(nums);
        ListNode dummy = new(0, head);
        var current = dummy;
        while (current.next != null)
        {
            if (numSet.Contains(current.next.val))
            {
                current.next = current.next.next;
            }
            else
            {
                current = current.next;
            }
        }
        return dummy.next;
    }
}