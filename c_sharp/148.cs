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
    // recursive
    // time complexity O(NlogN)
    // memory complexity O(logN)
    public ListNode SortList(ListNode head)
    {
        if (head == null || head.next == null) return head;

        var left = head;
        var right = GetMiddle(head);

        var tmp = right.next;
        right.next = null;
        right = tmp;

        left = SortList(left);
        right = SortList(right);

        return MergeLists(left, right);
    }

    private ListNode GetMiddle(ListNode head)
    {
        var slow = head;
        var fast = head.next;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        return slow;
    }

    private ListNode MergeLists(ListNode first, ListNode second)
    {
        ListNode dummy = new ListNode();
        var tail = dummy;

        while (first != null && second != null)
        {
            if (first.val <= second.val)
            {
                tail.next = first;
                first = first.next;
            }
            else
            {
                tail.next = second;
                second = second.next;
            }
            tail = tail.next;
        }

        if (first != null)
        {
            tail.next = first;
        }

        if (second != null)
        {
            tail.next = second;
        }

        return dummy.next;
    }
}

public class Solution2
{
    // iteration
    // time complexity O(NlogN)
    // memory complexity O(1)
    public ListNode SortList(ListNode head)
    {
        if (head == null || head.next == null) return head;

        var iterator = head;
        int count = 0;

        while (iterator != null)
        {
            count++;
            iterator = iterator.next;
        }

        ListNode dummy = new();
        dummy.next = head;

        for (int i = 1; i < count; i *= 2)
        {
            var tail = dummy;
            var tmp = dummy.next;

            while (tmp != null)
            {
                var left = tmp;
                var right = ComputeSecondPart(left, i);
                tmp = ComputeSecondPart(right, i);

                tail.next = MergeLists(left, right);
                while (tail.next != null) tail = tail.next;
            }
        }
        return dummy.next;
    }

    private ListNode ComputeSecondPart(ListNode start, int nElement)
    {
        var iterator = start;
        for (int i = 1; i < nElement && iterator != null; i++)
        {
            iterator = iterator.next;
        }

        if (iterator == null) return null;

        var next = iterator.next;
        iterator.next = null;
        return next;
    }

    private ListNode MergeLists(ListNode first, ListNode second)
    {
        ListNode dummy = new ListNode();
        var tail = dummy;

        while (first != null && second != null)
        {
            if (first.val <= second.val)
            {
                tail.next = first;
                first = first.next;
            }
            else
            {
                tail.next = second;
                second = second.next;
            }
            tail = tail.next;
        }

        if (first != null)
        {
            tail.next = first;
        }

        if (second != null)
        {
            tail.next = second;
        }

        return dummy.next;
    }
}