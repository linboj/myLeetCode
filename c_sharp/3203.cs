// BFS
public class Solution
{
    public int MinimumDiameterAfterMerge(int[][] edges1, int[][] edges2)
    {
        int n = edges1.Length + 1;
        int m = edges2.Length + 1;

        List<List<int>> adjList1 = buildAdjList(n, edges1);
        List<List<int>> adjList2 = buildAdjList(m, edges2);

        // Calculate the diameters of both trees
        int diameter1 = findDiameter(n, adjList1);
        int diameter2 = findDiameter(m, adjList2);

        // Calculate the longest path that spans across both trees
        int combinedDiameter =
            (int)Math.Ceiling(diameter1 / 2.0) + (int)Math.Ceiling(diameter2 / 2.0) + 1;

        // Return the maximum of the three possibilities
        return Math.Max(Math.Max(diameter1, diameter2), combinedDiameter);
    }

    private List<List<int>> buildAdjList(int size, int[][] edges)
    {
        List<List<int>> adjList = new();
        for (int i = 0; i < size; i++)
        {
            adjList.Add(new List<int>());
        }
        foreach (var edge in edges)
        {
            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }
        return adjList;
    }

    private int findDiameter(int n, List<List<int>> adjList)
    {
        var (farthestNode, _) = findFarthestNode(n, adjList, 0);
        var (_, diameter) = findFarthestNode(n, adjList, farthestNode);

        return diameter;
    }

    (int, int) findFarthestNode(int n, List<List<int>> adjList, int sourceNode)
    {
        Queue<int> queue = new();
        bool[] visited = new bool[n];
        
        queue.Enqueue(sourceNode);
        visited[sourceNode] = true;

        int maximumDistance = 0, farthestNode = sourceNode;

        while (queue.Count() > 0)
        {
            int size = queue.Count();
            for (int i = 0; i < size; i++)
            {
                int currentNode = queue.Dequeue();
                // Update farthest node
                // The farthest node is the last one that was popped out of the queue.
                farthestNode = currentNode;

                // Explore neighbors
                foreach (int neighbor in adjList[currentNode])
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        queue.Enqueue(neighbor);
                    }
                }
            }
            if (queue.Count() > 0) maximumDistance++;
        }
        return (farthestNode, maximumDistance);
    }
}

// DFS
public class Solution2
{
    public int MinimumDiameterAfterMerge(int[][] edges1, int[][] edges2)
    {
        int n = edges1.Length + 1;
        int m = edges2.Length + 1;

        List<List<int>> adjList1 = buildAdjList(n, edges1);
        List<List<int>> adjList2 = buildAdjList(m, edges2);

        // Calculate the diameters of both trees
        var (diameter1, _) = findDiameter(adjList1, 0, 0);
        var (diameter2, _) = findDiameter(adjList2, 0, 0);

        // Calculate the longest path that spans across both trees
        int combinedDiameter =
            (int)Math.Ceiling(diameter1 / 2.0) + (int)Math.Ceiling(diameter2 / 2.0) + 1;

        // Return the maximum of the three possibilities
        return Math.Max(Math.Max(diameter1, diameter2), combinedDiameter);
    }

    private List<List<int>> buildAdjList(int size, int[][] edges)
    {
        List<List<int>> adjList = new();
        for (int i = 0; i < size; i++)
        {
            adjList.Add(new List<int>());
        }
        foreach (var edge in edges)
        {
            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }
        return adjList;
    }

    private (int, int) findDiameter(List<List<int>> adjList, int node, int parent)
    {
        int maxDepth1 = 0, maxDepth2 = 0;
        int diameter = 0;

        foreach (int neighbor in adjList[node]) {
            if (neighbor == parent) continue;

            // Recursively calculate the diameter and depth of the neighbor's subtree
            var result = findDiameter(adjList, neighbor, node);
            int childDiameter = result.Item1;
            int depth = result.Item2 + 1; // Increment depth to include edge to neighbor

            // Update the maximum diameter of the subtree
            diameter = Math.Max(diameter, childDiameter);

            // Update the two largest depths from the current node
            if (depth > maxDepth1) {
                maxDepth2 = maxDepth1;
                maxDepth1 = depth;
            } else if (depth > maxDepth2) {
                maxDepth2 = depth;
            }
        }

        // Update the diameter to include the path through the current node
        diameter = Math.Max(diameter, maxDepth1 + maxDepth2);

        // Return the diameter and the longest depth
        return (diameter, maxDepth1);
    }

}