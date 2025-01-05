/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution
{
    public Node CloneGraph(Node node)
    {
        if (node == null) return null;
        Dictionary<Node, Node> map = new();
        Queue<Node> queue = new();
        queue.Enqueue(node);
        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();
            if (!map.ContainsKey(current))
            {
                map.Add(current, new Node(current.val));
            }
            foreach (var neighbor in current.neighbors)
            {
                if (!map.ContainsKey(neighbor))
                {
                    map.Add(neighbor, new Node(neighbor.val));
                    queue.Enqueue(neighbor);
                }
            }
        }
        foreach (var oldNode in map.Keys)
        {
            foreach (var oldNeighbor in oldNode.neighbors)
            {
                map[oldNode].neighbors.Add(map[oldNeighbor]);
            }
        }
        return map[node];
    }
}

public class Solution2
{
    Dictionary<int, Node> map = new();
    public Node CloneGraph(Node node)
    {
        if (node == null) return null;
        if (map.ContainsKey(node.val)) return map[node.val];
        
        map[node.val] = new Node(node.val);

        foreach (var neighbor in node.neighbors)
        {
            map[node.val].neighbors.Add(CloneGraph(neighbor));
        }

        return map[node.val];
    }
}