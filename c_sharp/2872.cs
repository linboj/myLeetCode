public class Solution
{
    public int MaxKDivisibleComponents(int n, int[][] edges, int[] values, int k)
    {
        // BFS
        if (n < 2) return 1;

        int componentCount = 0;
        Dictionary<int, HashSet<int>> graph = new();

        // Build the graph's adjacency list
        foreach (var edge in edges)
        {
            if (graph.ContainsKey(edge[0]))
            {
                graph[edge[0]].Add(edge[1]);
            }
            else
            {
                graph.Add(edge[0], new HashSet<int> { edge[1] });
            }
            if (graph.ContainsKey(edge[1]))
            {
                graph[edge[1]].Add(edge[0]);
            }
            else
            {
                graph.Add(edge[1], new HashSet<int> { edge[0] });
            }
        }
        // Initialize the BFS queue with leaf nodes
        Queue<int> queue = new Queue<int>();
        foreach (var entry in graph)
        {
            if (entry.Value.Count == 1) queue.Enqueue(entry.Key);
        }
        // Process nodes in BFS order
        while (queue.Count > 0)
        {
            int currentNode = queue.Dequeue();
            // Find the neighbor node
            int neighborNode = -1;
            if (graph[currentNode] != null && graph[currentNode].Count > 0)
            {
                neighborNode = graph[currentNode].First();
            }

            if (neighborNode >= 0)
            {
                // Remove the edge between current and neighbor
                graph[neighborNode].Remove(currentNode);
                graph[currentNode].Remove(neighborNode);
            }
            // Check divisibility of the current node's value
            if (values[currentNode] % k == 0)
                componentCount++;
            else if (neighborNode >= 0)
            {
                // Add current node's value to the neighbor
                int temp = values[currentNode] % k + values[neighborNode] % k; 
                values[neighborNode] = temp % k;
            }
            // If the neighbor becomes a leaf node, add it to the queue
            if (neighborNode >= 0 && graph[neighborNode] != null && graph[neighborNode].Count == 1)
            {
                queue.Enqueue(neighborNode);
            }
        }
        return componentCount;

    }
}

public class Solution2
{
    public int MaxKDivisibleComponents(int n, int[][] edges, int[] values, int k)
    {
        // DFS
        // Create adjacency list from edges
        List<int>[] adjList = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            adjList[i] = new List<int>();
        }
        foreach (var edge in edges)
        {
            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }

        int componentCount = 0;

        DFS(0, -1, adjList, values, k, ref componentCount);

        return componentCount;
    }

    private int DFS(int currentNode, int parentNode, List<int>[] adjList, int[] nodeValues, int k, ref int componentCount)
    {
        int sum = 0;
        // Traverse all neighbors
        foreach (var neighborNode in adjList[currentNode])
        {
            // Recursive call to process the subtree rooted at the neighbor
            if (neighborNode != parentNode)
            {
                sum += DFS(neighborNode, currentNode, adjList, nodeValues, k, ref componentCount);
                sum %= k;
            }

        }
        // Add the value of the current node to the sum
        sum += nodeValues[currentNode];
        sum %= k;

        if (sum % k == 0) componentCount++;

        return sum;
    }
}