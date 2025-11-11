public class Solution
{
    public int FindMaxForm(string[] strs, int m, int n)
    {
        int[][] dp = new int[m + 1][];
        for (int i = 0; i <= m; i++)
        {
            dp[i] = new int[n + 1];
        }

        foreach (var str in strs)
        {
            int ones = 0;
            foreach (var c in str)
            {
                ones += c - '0';
            }
            int zeros = str.Length - ones;

            for (int i = m; i >= zeros; i--)
            {
                for (int j = n; j >= ones; j--)
                {
                    dp[i][j] = Math.Max(dp[i][j], dp[i - zeros][j - ones] + 1);
                }
            }
        }
        return dp[m][n];
    }
}