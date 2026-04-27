public class Solution
{

    int[][] grid;
    int n, m;
    DisjointSet ds;

    public bool HasValidPath(int[][] grid)
    {
        n = grid.Length;
        m = grid[0].Length;
        this.grid = grid;
        ds = new DisjointSet(n * m);

        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < m; c++)
            {
                switch (grid[r][c])
                {
                    case 1:
                        DetectL(r, c);
                        DetectR(r, c);
                        break;
                    case 2:
                        DetectU(r, c);
                        DetectD(r, c);
                        break;
                    case 3:
                        DetectL(r, c);
                        DetectD(r, c);
                        break;
                    case 4:
                        DetectR(r, c);
                        DetectD(r, c);
                        break;
                    case 5:
                        DetectL(r, c);
                        DetectU(r, c);
                        break;
                    case 6:
                        DetectR(r, c);
                        DetectU(r, c);
                        break;
                }
            }
        }

        return ds.Find(0) == ds.Find((n - 1) * m + m - 1);
    }

    public void DetectL(int r, int c)
    {
        if (c > 0 && (grid[r][c - 1] == 1 || grid[r][c - 1] == 4 || grid[r][c - 1] == 6))
        {
            ds.Union(r * m + c, r * m + c - 1);
        }
    }

    public void DetectR(int r, int c)
    {
        if (c < m - 1 && (grid[r][c + 1] % 2 == 1))
        {
            ds.Union(r * m + c, r * m + c + 1);
        }
    }

    public void DetectU(int r, int c)
    {
        if (r > 0 && (grid[r - 1][c] == 2 || grid[r - 1][c] == 3 || grid[r - 1][c] == 4))
        {
            ds.Union(r * m + c, (r - 1) * m + c);
        }
    }

    public void DetectD(int r, int c)
    {
        if (r < n - 1 && (grid[r + 1][c] == 2 || grid[r + 1][c] == 5 || grid[r + 1][c] == 6))
        {
            ds.Union(r * m + c, (r + 1) * m + c);
        }
    }

    class DisjointSet
    {
        int[] parent;

        public DisjointSet(int n)
        {
            parent = new int[n];
            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
            }
        }

        public int Find(int x)
        {
            if (parent[x] == x)
                return x;

            return parent[x] = Find(parent[x]);
        }

        public void Union(int x, int y)
        {
            parent[Find(x)] = Find(y);
        }
    }
}