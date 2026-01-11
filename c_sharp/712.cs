public class Solution
{
    public int MinimumDeleteSum(string s1, string s2)
    {
        int n = s1.Length, m = s2.Length;
        int[] dp = new int[m + 1];

        for (int i = 1; i <= m; i++)
        {
            dp[i] = dp[i - 1] + s2[i - 1];
        }

        for (int i = 1; i <= n; i++)
        {
            int prev = dp[0];
            dp[0] += s1[i - 1];

            for (int j = 1; j <= m; j++)
            {
                int temp = dp[j];

                if (s1[i - 1] == s2[j - 1])
                {
                    dp[j] = prev;
                }
                else
                {
                    dp[j] = Math.Min(dp[j] + s1[i - 1], dp[j - 1] + s2[j - 1]);
                }

                prev = temp;
            }
        }
        return dp[m];
    }
}