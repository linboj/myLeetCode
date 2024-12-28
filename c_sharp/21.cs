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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {

        ListNode ans = new ListNode(int.MinValue, null);
        ListNode current = ans;
        while (list1 != null && list2 != null)
        {

            if (list1.val > list2.val)
            {
                current.next = list2;
                list2 = list2.next;
            }
            else
            {
                current.next = list1;
                list1 = list1.next;
            }

            current = current.next;
        }
        if (list1 != null) current.next = list1;
        if (list2 != null) current.next = list2;
        return ans.next;

    }
}