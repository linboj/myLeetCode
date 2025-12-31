public class Solution
{
    // land cell
    public int LatestDayToCross(int row, int col, int[][] cells)
    {
        DSU dsu = new DSU(row * col + 2);
        int[][] grid = new int[row][];
        int[][] dirs = [[0, 1], [1, 0], [-1, 0], [0, -1]];

        for (int i = 0; i < row; i++)
        {
            grid[i] = new int[col];
        }

        for (int i = cells.Length - 1; i >= 0; i--)
        {
            int r = cells[i][0] - 1;
            int c = cells[i][1] - 1;

            grid[r][c] = 1;

            int cellId = r * col + c + 1;

            foreach (var dir in dirs)
            {
                int nr = r + dir[0];
                int nc = c + dir[1];

                if (nr >= 0 && nr < row && nc >= 0 && nc < col && grid[nr][nc] == 1)
                    dsu.Union(cellId, nr * col + nc + 1);

                if (r == 0)
                    dsu.Union(0, cellId);

                if (r == row - 1)
                    dsu.Union(row * col + 1, cellId);

                if (dsu.Find(0) == dsu.Find(row * col + 1))
                    return i;
            }
        }
        return -1;
    }

    class DSU
    {
        int[] parent;
        int[] rank;

        public DSU(int n)
        {
            parent = new int[n];
            rank = new int[n];

            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
                rank[i] = 1;
            }
        }

        public int Find(int x)
        {
            if (parent[x] != x)
                parent[x] = Find(parent[x]);
            return parent[x];
        }

        public void Union(int x, int y)
        {
            int rx = Find(x);
            int ry = Find(y);

            if (rx == ry)
                return;

            if (rank[ry] < rank[rx])
            {
                int tmp = rx;
                rx = ry;
                ry = tmp;
            }

            parent[rx] = ry;
            rank[ry] += rank[rx];
        }
    }
}

public class Solution2
{
    // water cell
    public int LatestDayToCross(int row, int col, int[][] cells)
    {
        DSU dsu = new DSU(row * col + 2);
        int[][] grid = new int[row][];
        int[][] dirs = [[0, 1], [1, 0], [-1, 0], [0, -1], [1, 1], [1, -1], [-1, 1], [-1, -1]];

        for (int i = 0; i < row; i++)
        {
            grid[i] = new int[col];
        }

        for (int i = 0; i < cells.Length - 1; i++)
        {
            int r = cells[i][0] - 1;
            int c = cells[i][1] - 1;

            grid[r][c] = 1;

            int cellId = r * col + c + 1;

            foreach (var dir in dirs)
            {
                int nr = r + dir[0];
                int nc = c + dir[1];

                if (nr >= 0 && nr < row && nc >= 0 && nc < col && grid[nr][nc] == 1)
                    dsu.Union(cellId, nr * col + nc + 1);

                if (c == 0)
                    dsu.Union(0, cellId);

                if (c == col - 1)
                    dsu.Union(row * col + 1, cellId);

                if (dsu.Find(0) == dsu.Find(row * col + 1))
                    return i;
            }
        }
        return -1;
    }

    class DSU
    {
        int[] parent;
        int[] rank;

        public DSU(int n)
        {
            parent = new int[n];
            rank = new int[n];

            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
                rank[i] = 1;
            }
        }

        public int Find(int x)
        {
            if (parent[x] != x)
                parent[x] = Find(parent[x]);
            return parent[x];
        }

        public void Union(int x, int y)
        {
            int rx = Find(x);
            int ry = Find(y);

            if (rx == ry)
                return;

            if (rank[ry] < rank[rx])
            {
                int tmp = rx;
                rx = ry;
                ry = tmp;
            }

            parent[rx] = ry;
            rank[ry] += rank[rx];
        }
    }
}