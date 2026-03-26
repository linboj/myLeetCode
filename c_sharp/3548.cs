public class Solution
{
    public bool CanPartitionGrid(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        long total = 0;

        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < m; c++)
            {
                total += grid[r][c];
            }
        }

        for (int k = 0; k < 4; k++)
        {
            HashSet<long> exist = new();
            exist.Add(0);
            long sum = 0;
            n = grid.Length;
            m = grid[0].Length;

            if (n < 2)
            {
                grid = Rotate(grid);
                continue;
            }

            if (m == 1)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    sum += grid[i][0];
                    long t = sum * 2 - total;

                    if (t == 0 || t == grid[0][0] || t == grid[i][0])
                        return true;
                }
                grid = Rotate(grid);
                continue;
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    exist.Add(grid[i][j]);
                    sum += grid[i][j];
                }
                long t = sum * 2 - total;

                if (i == 0)
                {
                    if (t == 0 || t == grid[0][0] || t == grid[0][m - 1])
                        return true;

                    continue;
                }

                if (exist.Contains(t))
                    return true;
            }
            grid = Rotate(grid);
        }
        return false;
    }

    private int[][] Rotate(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        int[][] result = new int[m][];
        for (int i = 0; i < m; i++)
        {
            result[i] = new int[n];
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                result[j][n - 1 - i] = grid[i][j];
            }
        }

        return result;
    }
}