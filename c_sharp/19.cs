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
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        if (head.next == null) return head.next;
        ListNode currentNode = head;
        ListNode prevNNode = head;
        int currentIdx = 1;

        while (currentNode != null)
        {
            currentNode = currentNode.next;
            if (currentIdx > n+1)
            {
                prevNNode = prevNNode.next;
            }
            currentIdx++;
        }
        if (currentIdx <= n+1) return head.next;
        prevNNode.next = prevNNode.next == null ? null : prevNNode.next.next;

        return head;
    }
}