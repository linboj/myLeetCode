public class Solution
{
    // Disjoint-Set
    public int[] MinimumCost(int n, int[][] edges, int[][] query)
    {
        int[] parent = new int[n];
        int[] depth = new int[n];
        int[] cost = new int[n];
        Array.Fill(parent, -1);
        Array.Fill(cost, int.MaxValue);

        foreach (var edge in edges)
        {
            Union(parent, depth, edge[0], edge[1]);
        }

        foreach (var edge in edges)
        {
            int root = Find(parent, edge[0]);
            cost[root] &= edge[2];
        }

        int[] ans = new int[query.Length];
        for (int i = 0; i < query.Length; i++)
        {
            if (Find(parent, query[i][0]) != Find(parent, query[i][1]))
                ans[i] = -1;
            else
            {
                int root = Find(parent, query[i][0]);
                ans[i] = cost[root];
            }
        }

        return ans;
    }

    private int Find(int[] parent, int node)
    {
        if (parent[node] == -1) return node;

        return parent[node] = Find(parent, parent[node]);
    }


    private void Union(int[] parent, int[] depth, int node1, int node2)
    {
        int root1 = Find(parent, node1);
        int root2 = Find(parent, node2);

        if (root1 == root2) return;

        if (depth[root1] < depth[root2])
        {
            int temp = root1;
            root1 = root2;
            root2 = temp;
        }
        parent[root2] = root1;
        if (depth[root2] == depth[root1])
            depth[root1]++;
    }
}