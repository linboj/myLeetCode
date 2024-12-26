/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    public bool HasCycle(ListNode head) {
        // use set
        /*
        HashSet<ListNode> visitedNodes = new ();

        var currentNode = head;
        while (currentNode != null) {
            if (visitedNodes.Contains(currentNode)) return true;

            visitedNodes.Add(currentNode);
            currentNode = currentNode.next;
        }

        return false;
        */

        // use two pointer
        var slow = head;
        var fast = head;
        while (fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;

            if (slow == fast) return true;
        }
        return false;
    }
}