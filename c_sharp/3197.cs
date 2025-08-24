public class Solution
{
    public int MinimumSum(int[][] grid)
    {
        var rotated = Rotate90(grid);
        return Math.Min(Solve(grid), Solve(rotated));
    }

    private int MinimumSumSingle(int[][] grid, int top, int bottom, int left, int right)
    {
        int n = grid.Length, m = grid[0].Length;
        int minRow = n, maxRow = 0;
        int minCol = m, maxCol = 0;

        for (int r = top; r <= bottom; r++)
        {
            for (int c = left; c <= right; c++)
            {
                if (grid[r][c] == 1)
                {
                    minRow = Math.Min(minRow, r);
                    maxRow = Math.Max(maxRow, r);
                    minCol = Math.Min(minCol, c);
                    maxCol = Math.Max(maxCol, c);
                }
            }
        }
        return minRow <= maxRow ? (maxRow - minRow + 1) * (maxCol - minCol + 1) : int.MaxValue / 3;
    }

    private int[][] Rotate90(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        int[][] rotated = new int[m][];
        for (int j = 0; j < m; j++)
        {
            rotated[m - j - 1] = new int[n];
            for (int i = 0; i < n; i++)
            {
                rotated[m - j - 1][i] = grid[i][j];
            }
        }
        return rotated;
    }

    private int Solve(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        int ans = n * m;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < m - 1; j++)
            {
                ans = Math.Min(ans,
                    MinimumSumSingle(grid, 0, i, 0, m - 1) +
                    MinimumSumSingle(grid, i + 1, n - 1, 0, j) +
                    MinimumSumSingle(grid, i + 1, n - 1, j + 1, m - 1)
                );
                ans = Math.Min(ans,
                    MinimumSumSingle(grid, i + 1, n - 1, 0, m - 1) +
                    MinimumSumSingle(grid, 0, i, 0, j) +
                    MinimumSumSingle(grid, 0, i, j + 1, m - 1)
                );
            }
        }
        for (int i = 0; i < n - 2; i++)
        {
            for (int j = i + 1; j < n - 1; j++)
            {
                ans = Math.Min(ans,
                     MinimumSumSingle(grid, 0, i, 0, m - 1) +
                     MinimumSumSingle(grid, i + 1, j, 0, m - 1) +
                     MinimumSumSingle(grid, j + 1, n - 1, 0, m - 1)
                 );
            }
        }
        return ans;
    }
}