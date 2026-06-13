public class Solution
{
    private const int MOD = 1_000_000_007;
    private const int N = 100010;
    private static int[] p = new int[N];

    static Solution()
    {
        p[0] = 1;

        for (int i = 1; i < N; i++)
        {
            p[i] = (int)((long)p[i - 1] * 2 % MOD);
        }
    }

    public int[] AssignEdgeWeights(int[][] edges, int[][] queries)
    {
        int m = queries.Length;
        int[] ans = new int[m];

        LCA lca = new LCA(edges, 1);

        for (int i = 0; i < m; i++)
        {
            int x = queries[i][0], y = queries[i][1];
            if (x != y)
            {
                ans[i] = p[lca.Dist(x, y) - 1];
            }

        }

        return ans;

    }
}

public class LCA
{
    private int n, m;
    private int[] d;
    private List<int>[] e;
    private int[][] f;

    public LCA(int[][] edges, int root = 1)
    {
        n = edges.Length + 1;
        m = (int)Math.Log2(n) + 1;
        e = new List<int>[n + 1];
        d = new int[n + 1];
        f = new int[n + 1][];

        for (int i = 0; i <= n; i++)
        {
            e[i] = new();
            f[i] = new int[m];
        }

        foreach (var edge in edges)
        {
            int u = edge[0], v = edge[1];
            e[u].Add(v);
            e[v].Add(u);
        }

        Dfs(root, 0);

        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                f[j][i] = f[f[j][i - 1]][i - 1];
            }
        }
    }

    private void Dfs(int x, int from)
    {
        f[x][0] = from;
        foreach (var y in e[x])
        {
            if (y == from) continue;

            d[y] = d[x] + 1;
            Dfs(y, x);
        }
    }

    public int Lca(int x, int y)
    {
        if (d[x] > d[y])
        {
            (x, y) = (y, x);
        }

        for (int i = m - 1; i >= 0; i--)
        {
            if (d[x] <= d[f[y][i]])
            {
                y = f[y][i];
            }
        }

        if (x == y) return x;

        for (int i = m - 1; i >= 0; i--)
        {
            if (f[y][i] != f[x][i])
            {
                x = f[x][i];
                y = f[y][i];
            }
        }

        return f[x][0];
    }

    public int Dist(int x, int y)
    {
        return d[x] + d[y] - d[Lca(x, y)] * 2;
    }
}