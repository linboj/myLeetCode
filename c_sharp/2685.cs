public class Solution
{

    // Union Find
    public int CountCompleteComponents(int n, int[][] edges)
    {
        UnionFind dsu = new UnionFind(n);
        Dictionary<int, int> edgeCount = new();

        foreach (var edge in edges)
        {
            dsu.Union(edge[0], edge[1]);
        }

        foreach (var edge in edges)
        {
            int root = dsu.Find(edge[0]);
            if (!edgeCount.ContainsKey(root)) edgeCount[root] = 0;
            edgeCount[root]++;
        }

        int componentCount = 0;
        for (int v = 0; v < n; v++)
        {
            if (dsu.Find(v) == v)
            {
                int nVertex = dsu.size[v];
                if (nVertex == 1)
                {
                    componentCount++;
                    continue;
                }
                int expectedEdge = nVertex * (nVertex - 1) / 2;

                if (edgeCount[v] == expectedEdge)
                    componentCount++;
            }
        }
        return componentCount;
    }

    class UnionFind
    {
        int[] parent;
        public int[] size;

        public UnionFind(int n)
        {
            parent = new int[n];
            size = new int[n];
            Array.Fill(parent, -1);
            Array.Fill(size, 1);
        }

        public int Find(int node)
        {
            if (parent[node] == -1) return node;

            return parent[node] = Find(parent[node]);
        }

        public void Union(int node1, int node2)
        {
            int root1 = Find(node1);
            int root2 = Find(node2);

            if (root1 == root2) return;

            if (size[root1] < size[root2])
            {
                var temp = root1;
                root1 = root2;
                root2 = temp;
            }

            parent[root2] = root1;
            size[root1] += size[root2];
        }
    }
}

public class Solution2
{
    // DFS
    public int CountCompleteComponents(int n, int[][] edges)
    {
        List<int>[] graph = new List<int>[n];
        for (int i = 0; i < n; i++)
            graph[i] = new List<int>();
        foreach (var edge in edges)
        {
            graph[edge[0]].Add(edge[1]);
            graph[edge[1]].Add(edge[0]);
        }
        int componentCount = 0;
        bool[] visited = new bool[n];

        for (int v = 0; v < n; v++)
        {
            if (visited[v]) continue;
            int nVertex = 0, nEdge = 0;
            Dfs(v, graph, visited, ref nVertex, ref nEdge);
            if ((nVertex * (nVertex - 1)) == nEdge)
                componentCount++;
        }
        return componentCount;
    }

    private void Dfs(int v, List<int>[] graph, bool[] visited, ref int nVertex, ref int nEdge)
    {
        visited[v] = true;
        nVertex++;
        nEdge += graph[v].Count;
        foreach (var node in graph[v])
        {
            if (!visited[node])
                Dfs(node, graph, visited, ref nVertex, ref nEdge);
        }
    }
}