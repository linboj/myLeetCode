public class Solution
{

    private const int MOD = 1_000_000_007;
    public int AssignEdgeWeights(int[][] edges)
    {
        int n = edges.Length + 1;
        List<int>[] g = new List<int>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            g[i] = new();
        }

        foreach (var edge in edges)
        {
            int v = edge[0], u = edge[1];
            g[v].Add(u);
            g[u].Add(v);
        }

        int maxDep = Dfs(g, 1, 0);
        return QPow(2, maxDep - 1);
    }

    private int Dfs(List<int>[] g, int cur, int from)
    {
        int max = 0;
        foreach (var n in g[cur])
        {
            if (n == from)
                continue;

            max = Math.Max(max, Dfs(g, n, cur) + 1);
        }
        return max;
    }

    private int QPow(int x, int y)
    {
        long ans = 1;
        long baseVal = x;

        while (y > 0)
        {
            if ((y & 1) == 1)
                ans = ans * baseVal % MOD;

            baseVal = (baseVal * baseVal) % MOD;
            y >>= 1;
        }

        return (int)ans;
    }
}