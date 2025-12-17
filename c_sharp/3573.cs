public class Solution
{
    public long MaximumProfit(int[] prices, int k)
    {
        int n = prices.Length;
        long[][] dp = new long[k + 1][];

        for (int i = 0; i <= k; i++)
        {
            dp[i] = new long[3];
            dp[i][1] = -prices[0];
            dp[i][2] = prices[0];
        }

        dp[0][1] = 0;
        dp[0][2] = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = k; j > 0; j--)
            {
                dp[j][0] = Math.Max(dp[j][0], Math.Max(dp[j][1] + prices[i], dp[j][2] - prices[i]));
                dp[j][1] = Math.Max(dp[j][1], dp[j - 1][0] - prices[i]);
                dp[j][2] = Math.Max(dp[j][2], dp[j - 1][0] + prices[i]);
            }
        }
        return dp[k][0];
    }
}