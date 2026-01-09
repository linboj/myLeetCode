public class Solution
{
    public int MaxDotProduct(int[] nums1, int[] nums2)
    {
        int n = nums1.Length, m = nums2.Length;
        int[,] dp = new int[n + 1, m + 1];

        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= m; j++)
            {
                dp[i, j] = int.MinValue;
            }
        }

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                int take = nums1[i - 1] * nums2[j - 1] + Math.Max(0, dp[i - 1, j - 1]);
                dp[i, j] = Math.Max(Math.Max(dp[i - 1, j], dp[i, j - 1]), take);
            }
        }
        return dp[n, m];
    }
}

public class Solution2
{
    public int MaxDotProduct(int[] nums1, int[] nums2)
    {
        int n = nums1.Length, m = nums2.Length;
        int[] current = new int[m + 1], previous = new int[m + 1];
        Array.Fill(current, int.MinValue);
        Array.Fill(previous, int.MinValue);

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                int product = nums1[i - 1] * nums2[j - 1];
                current[j] = Math.Max(Math.Max(Math.Max(product, previous[j]), current[j - 1]), product + Math.Max(0, previous[j - 1]));
            }

            (current, previous) = (previous, current);
        }

        return previous[m];
    }
}