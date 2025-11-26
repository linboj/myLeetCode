public class Solution
{
    private const int MOD = 1_000_000_007;
    public int NumberOfPaths(int[][] grid, int k)
    {
        int n = grid.Length, m = grid[0].Length;
        int[][][] dp = new int[n + 1][][];
        for (int i = 0; i <= n; i++)
        {
            dp[i] = new int[m + 1][];
            for (int j = 0; j <= m; j++)
            {
                dp[i][j] = new int[k];
            }
        }

        for (int r = 1; r <= n; r++)
        {
            for (int c = 1; c <= m; c++)
            {
                if (r == 1 && c == 1)
                {
                    dp[r][c][grid[0][0] % k] = 1;
                    continue;
                }

                int val = grid[r - 1][c - 1] % k;
                for (int i = 0; i < k; i++)
                {
                    int prevMod = (i - val + k) % k;
                    dp[r][c][i] = (dp[r - 1][c][prevMod] + dp[r][c - 1][prevMod]) % MOD;
                }
            }
        }
        return dp[n][m][0];
    }
}