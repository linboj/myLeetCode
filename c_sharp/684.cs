public class Solution
{
    // Single Traversal (DFS)
    public int[] FindRedundantConnection(int[][] edges)
    {
        int n = edges.Length;
        bool[] visited = new bool[n];
        int[] parent = new int[n];
        List<int>[] adjList = new List<int>[n];

        for (int i = 0; i < n; i++)
        {
            adjList[i] = new List<int>();
        }

        foreach (var edge in edges)
        {
            adjList[edge[0] - 1].Add(edge[1] - 1);
            adjList[edge[1] - 1].Add(edge[0] - 1);
        }

        int cycleStart = -1;
        DFS(0, visited, adjList, parent, ref cycleStart);

        bool[] cycleNodes = new bool[n];
        int node = cycleStart;

        do
        {
            cycleNodes[node] = true;
            node = parent[node];
        } while (node != cycleStart);

        for (int i = n - 1; i >= 0; i--)
        {
            if (cycleNodes[edges[i][0] - 1] && cycleNodes[edges[i][1] - 1]) return edges[i];
        }

        return [];
    }

    private void DFS(int src, bool[] visited, List<int>[] adjList, int[] parent, ref int cycleStart)
    {
        visited[src] = true;

        foreach (var adj in adjList[src])
        {
            if (!visited[adj])
            {
                parent[adj] = src;
                DFS(adj, visited, adjList, parent, ref cycleStart);
            }
            else if (adj != parent[src] && cycleStart == -1)
            {
                cycleStart = adj;
                parent[adj] = src;
            }
        }
    }
}

public class Solution2
{
    // Union find
    public int[] FindRedundantConnection(int[][] edges)
    {
        int n = edges.Length;
        int[] root = new int[n];
        int[] rank = new int[n];
        for (int i = 0; i < n; i++){
            root[i] = i;
            rank[i] = 1;
        }
        foreach (var edge in edges){
            int root1 = Find(root, edge[0]-1);
            int root2 = Find(root, edge[1]-1);

            if (root1 == root2)
                return edge;
            else {
                if (rank[root1] > rank[root2]){
                    root[root2] = root1;
                }else if (rank[root1] < rank[root2]){
                    root[root1] = root2;
                }else{
                    root[root2] = root1;
                    rank[root1]++;
                }
            }
        }
        return [];
    }

    private int Find(int[] root, int target){
        if (root[target] == target) return target;
        root[target] = Find(root, root[target]);
        return root[target];
    }

}