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
public class Solution {
    // PriorityQueue
    public ListNode MergeKLists(ListNode[] lists) {
        PriorityQueue<ListNode, int> pq = new ();
        ListNode dummy = new ListNode (-1);
        ListNode prev = dummy;
        foreach (var node in lists)
        {
            if (node != null)
                pq.Enqueue(node, node.val);
        }
        while (pq.Count > 0) {
            var node = pq.Dequeue();
            if (node.next != null) {
                pq.Enqueue(node.next, node.next.val);
            }
            prev.next = node;
            prev = node;
        }
        return dummy.next;
    }
}

public class Solution2 {
    // Merge sort
    public ListNode MergeKLists(ListNode[] lists) {
        if (lists == null || lists.Length == 0) return null;

        return MergeSort(lists, 0, lists.Length - 1);
    }

    private ListNode MergeSort(ListNode[] lists, int left, int right){
        if (left == right) return lists[left];
        int mid = (left + right) / 2;
        ListNode n1 = MergeSort(lists, left, mid);
        ListNode n2 = MergeSort(lists, mid + 1, right);
        return Merge2Lists(n1, n2);
    }

    private ListNode Merge2Lists(ListNode n1, ListNode n2){
        if (n1 == null) return n2;
        if (n2 == null) return n1;

        if (n1.val < n2.val){
            n1.next = Merge2Lists(n1.next, n2);
            return n1;
        }else{
            n2.next = Merge2Lists(n1, n2.next);
            return n2;
        }
    }
}