public class Solution
{
    public int SwimInWater(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        List<int[]> edges = new();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (i > 0)
                    edges.Add([Math.Max(grid[i][j], grid[i - 1][j]), i * m + j, (i - 1) * m + j]);
                if (j > 0)
                    edges.Add([Math.Max(grid[i][j], grid[i][j - 1]), i * m + j, i * m + j - 1]);
            }
        }

        edges.Sort((a, b) => a[0].CompareTo(b[0]));

        int[] parent = new int[n * m];
        for (int i = 0; i < n * m; i++)
            parent[i] = i;

        foreach (var edge in edges)
        {
            Union(parent, edge[1], edge[2]);
            if (Find(parent, 0) == Find(parent, parent.Length - 1))
                return edge[0];
        }
        return grid[0][0];
    }

    private int Find(int[] parent, int n)
    {
        if (parent[n] != n)
            parent[n] = Find(parent, parent[n]);

        return parent[n];
    }

    private void Union(int[] parent, int x, int y)
    {
        parent[Find(parent, x)] = Find(parent, y);
    }
}