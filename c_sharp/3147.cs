public class Solution
{
    public int MaximumEnergy(int[] energy, int k)
    {
        int n = energy.Length;
        int[] dp = new int[n];
        int max = energy[n - 1];

        for (int i = n - 1; i >= n - k; i--)
        {
            dp[i] = energy[i];
            max = Math.Max(max, dp[i]);
        }

        for (int i = n - k - 1; i >= 0; i--)
        {
            dp[i] = dp[i + k] + energy[i];
            max = Math.Max(max, dp[i]);
        }
        return max;
    }
}