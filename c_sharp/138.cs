/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution
{
    public Node CopyRandomList(Node head)
    {
        if (head == null) return null;
        Node currentNode = head;

        // copy Node and assign new Node to the next of original Node and the original next of original Node as the next of new Node 
        while (currentNode != null)
        {
            Node newNode = new Node(currentNode.val);
            newNode.next = currentNode.next;
            currentNode.next = newNode;
            currentNode = newNode.next;
        }

        currentNode = head;
        while (currentNode != null)
        {
            currentNode.next.random = (currentNode.random == null) ? null : currentNode.random.next;
            currentNode = currentNode.next.next;
        }

        
        Node newNodeList = head.next;
        Node oldNodeList = head;
        Node newHead = head.next;
        while (oldNodeList != null)
        {
            oldNodeList.next = (oldNodeList.next == null) ? null : oldNodeList.next.next;
            newNodeList.next = (newNodeList.next == null) ? null : newNodeList.next.next;
            oldNodeList = oldNodeList.next;
            newNodeList = newNodeList.next;
        }

        return newHead;
    }
}

public class Solution2
{
    public Node CopyRandomList(Node head)
    {
        if (head == null) return null;
        Dictionary<Node, Node> dict = new ();
        Node currentNode = head;

        while (currentNode != null)
        {
            Node newNode = new Node(currentNode.val);
            dict[currentNode] = newNode;
            currentNode = currentNode.next;
        }

        foreach (var kv in dict)
        {
            Node n = kv.Value;
            n.next = kv.Key.next == null ? null : dict[kv.Key.next];
            n.random = kv.Key.random == null ? null : dict[kv.Key.random];
        }

        return dict[head];
    }
}