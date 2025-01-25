public class Solution
{
    public int MinPathSum(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        int[] dp = new int[n];
        dp[0] = grid[0][0];
        for (int i = 1; i < n; i++)
        {
            dp[i] = dp[i - 1] + grid[0][i];
        }

        for (int i = 1; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int min = int.MaxValue;
                if (i - 1 >= 0) min = Math.Min(min, dp[j]);
                if (j - 1 >= 0) min = Math.Min(min, dp[j - 1]);
                dp[j] = min + grid[i][j];
            }
        }
        return dp[n - 1];
    }
}

public class Solution2
{
    public int MinPathSum(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        for (int i = 1; i < n; i++)
        {
            grid[0][i] = grid[0][i - 1] + grid[0][i];
        }

        for (int i = 1; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int min = int.MaxValue;
                if (i - 1 >= 0) min = Math.Min(min, grid[i - 1][j]);
                if (j - 1 >= 0) min = Math.Min(min, grid[i][j - 1]);
                grid[i][j] = min + grid[i][j];
            }
        }
        return grid[m - 1][n - 1];
    }
}