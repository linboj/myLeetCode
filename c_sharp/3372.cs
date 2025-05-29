public class Solution
{
    public int[] MaxTargetNodes(int[][] edges1, int[][] edges2, int k)
    {
        int n = edges1.Length + 1;
        int[] counts1 = Build(edges1, k);
        int[] counts2 = Build(edges2, k - 1);

        int maxCount2 = 0;
        foreach (var count in counts2)
        {
            maxCount2 = Math.Max(maxCount2, count);
        }

        for (int i = 0; i < n; i++)
        {
            counts1[i] += maxCount2;
        }
        return counts1;
    }

    private int[] Build(int[][] edges, int k)
    {
        int n = edges.Length + 1;
        List<List<int>> children = new List<List<int>>();
        for (int i = 0; i < n; i++)
        {
            children.Add(new List<int>());
        }

        foreach (var edge in edges)
        {
            children[edge[0]].Add(edge[1]);
            children[edge[1]].Add(edge[0]);
        }

        int[] result = new int[n];
        for (int i = 0; i < n; i++)
        {
            result[i] = Dfs(i, -1, children, k);
        }
        return result;
    }

    private int Dfs(int node, int parent, List<List<int>> children, int k)
    {
        if (k < 0)
            return 0;

        int result = 1;
        foreach (var child in children[node])
        {
            if (child == parent)
                continue;

            result += Dfs(child, node, children, k - 1);
        }

        return result;
    }
}