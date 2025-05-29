public class Solution
{
    public int[] MaxTargetNodes(int[][] edges1, int[][] edges2)
    {
        int n = edges1.Length + 1, m = edges2.Length + 1;
        int[] color1 = new int[n];
        int[] color2 = new int[m];
        int[] count1 = Build(edges1, color1);
        int[] count2 = Build(edges2, color2);
        int[] result = new int[n];
        int maxCount2 = Math.Max(count2[0], count2[1]);
        for (int i = 0; i < n; i++)
        {
            result[i] = count1[color1[i]] + maxCount2;
        }
        return result;
    }

    private int[] Build(int[][] edges, int[] color)
    {
        int n = edges.Length + 1;
        List<List<int>> children = new();
        for (int i = 0; i < n; i++)
        {
            children.Add(new List<int>());
        }

        foreach (var edge in edges)
        {
            children[edge[0]].Add(edge[1]);
            children[edge[1]].Add(edge[0]);
        }

        int result = Dfs(0, -1, 0, children, color);
        return [result, n - result];
    }

    private int Dfs(int node, int parent, int depth, List<List<int>> children, int[] color)
    {
        int result = 1 - (depth % 2);
        color[node] = depth % 2;
        foreach (var child in children[node])
        {
            if (child == parent)
                continue;

            result += Dfs(child, node, depth + 1, children, color);
        }

        return result;
    }
}