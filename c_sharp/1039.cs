public class Solution
{
    public int MinScoreTriangulation(int[] values)
    {
        int n = values.Length;
        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[n];
        }

        for (int i = n - 1; i >= 0; i--)
            for (int j = i + 1; j < n; j++)
                for (int k = i + 1; k < j; k++)
                {
                    dp[i][j] = Math.Min(
                        dp[i][j] == 0 ? int.MaxValue : dp[i][j],
                        dp[i][k] + values[i] * values[k] * values[j] + dp[k][j]
                    );
                }

        return dp[0][n - 1];
    }
}