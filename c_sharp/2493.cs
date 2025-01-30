public class Solution
{
    // BFS + Union-Find
    public int MagnificentSets(int n, int[][] edges)
    {
        List<int>[] adjList = new List<int>[n];
        int[] parent = new int[n], depth = new int[n];
        for (int i = 0; i < n; i++)
        {
            adjList[i] = new List<int>();
            parent[i] = -1;
        }

        foreach (var edge in edges)
        {
            adjList[edge[0] - 1].Add(edge[1] - 1);
            adjList[edge[1] - 1].Add(edge[0] - 1);
            Union(edge[0] - 1, edge[1] - 1, parent, depth);
        }
        int[] numsOfGroupsForComponent = new int[n];
        for (int node = 0; node < n; node++)
        {
            int numberOfGroup = GetNumberOfGroups(adjList, node);
            if (numberOfGroup == -1) return -1;
            var root = Find(node, parent);
            numsOfGroupsForComponent[root] = Math.Max(numsOfGroupsForComponent[root], numberOfGroup);
        }
        int totalNumberOfGroups = 0;
        foreach (var numsOfGroup in numsOfGroupsForComponent)
        {
            totalNumberOfGroups += numsOfGroup;
        }
        return totalNumberOfGroups;
    }

    private int GetNumberOfGroups(List<int>[] adjList, int src)
    {
        Queue<int> queue = new();
        int[] layerSeen = new int[adjList.Length];
        Array.Fill(layerSeen, -1);

        queue.Enqueue(src);
        layerSeen[src] = 0;
        int deepestLayer = 0;

        while (queue.Count > 0)
        {
            int numOfNodesInLayers = queue.Count;
            for (int i = 0; i < numOfNodesInLayers; i++)
            {
                var current = queue.Dequeue();
                foreach (var neighbor in adjList[current])
                {
                    if (layerSeen[neighbor] == -1)
                    {
                        layerSeen[neighbor] = deepestLayer + 1;
                        queue.Enqueue(neighbor);
                    }
                    else if (layerSeen[neighbor] == deepestLayer)
                        return -1;
                }
            }
            deepestLayer++;
        }
        return deepestLayer;
    }

    private int Find(int node, int[] parent)
    {
        while (parent[node] != -1)
        {
            node = parent[node];
        }
        return node;
    }

    private void Union(int node1, int node2, int[] parent, int[] depth)
    {
        node1 = Find(node1, parent);
        node2 = Find(node2, parent);

        if (node1 == node2) return;
        if (depth[node1] < depth[node2])
        {
            int temp = node1;
            node1 = node2;
            node2 = temp;
        }
        parent[node2] = node1;
        if (depth[node1] == depth[node2])
        {
            depth[node1]++;
        }
    }
}