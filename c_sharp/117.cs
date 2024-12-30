/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution
{
    public Node Connect(Node root)
    {

        if (root == null) return null;

        var nextLevelMostLeft = root;
        while (FindNextLevelMostLeft(ref nextLevelMostLeft, out var parent))
        {
            SetNextValuesOfLevel(nextLevelMostLeft, parent);
        }
        return root;
    }

    private bool FindNextLevelMostLeft(ref Node nextLevelMostLeft, out Node parent)
    {
        parent = nextLevelMostLeft;
        do
        {
            if (parent.left != null)
            {
                nextLevelMostLeft = parent.left;
                return true;
            }
            if (parent.right != null)
            {
                nextLevelMostLeft = parent.right;
                return true;
            }

            parent = parent.next;

        } while (parent != null);

        return false;
    }

    private void SetNextValuesOfLevel(Node nextLevelMostLeft, Node parent)
    {
        var child = nextLevelMostLeft;
        if (parent.left == child && parent.right != null)
        {
            child = child.next = parent.right;
        }

        while (parent.next != null)
        {
            parent = parent.next;
            if (parent.left != null)
            {
                child = child.next = parent.left;
            }
            if (parent.right != null)
            {
                child = child.next = parent.right;
            }
        }
    }
}

public class Solution
{
    public Node Connect(Node root)
    {

        if (root == null) return null;

        var node = root;
        Node prev = null;

        while (node != null)
        {
            var current = node;
            while (current != null)
            {
                if (current.left != null)
                {
                    if (prev != null)
                    {
                        prev.next = current.left;
                    }
                    prev = current.left;
                }
                if (current.right != null)
                {
                    if (prev != null)
                    {
                        prev.next = current.right;
                    }
                    prev = current.right;
                }
                current = current.next;
            }

            while (node != null && node.left == null && node.right == null)
            {
                node = node.next;
            }

            if (node != null)
            {
                if (node.left != null)
                    node = node.left;
                else
                    node = node.right;
            }

            prev = null;
        }
        return root;
    }
}