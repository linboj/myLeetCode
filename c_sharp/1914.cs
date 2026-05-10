public class Solution
{
    public int[][] RotateGrid(int[][] grid, int k)
    {
        int n = grid.Length, m = grid[0].Length;
        int nLayer = Math.Min(n / 2, m / 2);

        for (int layer = 0; layer < nLayer; layer++)
        {
            List<int> rows = new();
            List<int> cols = new();
            List<int> vals = new();

            // left
            for (int i = layer; i < n - layer - 1; i++)
            {
                rows.Add(i);
                cols.Add(layer);
                vals.Add(grid[i][layer]);
            }

            // down
            for (int j = layer; j < m - layer - 1; j++)
            {
                rows.Add(n - layer - 1);
                cols.Add(j);
                vals.Add(grid[n - layer - 1][j]);
            }

            // rigth
            for (int i = n - layer - 1; i > layer; i--)
            {
                rows.Add(i);
                cols.Add(m - layer - 1);
                vals.Add(grid[i][m - layer - 1]);
            }

            // top
            for (int j = m - layer - 1; j > layer; j--)
            {
                rows.Add(layer);
                cols.Add(j);
                vals.Add(grid[layer][j]);
            }

            int total = rows.Count;
            int shift = k % total;

            for (int i = 0; i < total; i++)
            {
                int idx = (i + total - shift) % total;
                grid[rows[i]][cols[i]] = vals[idx];
            }
        }

        return grid;
    }
}