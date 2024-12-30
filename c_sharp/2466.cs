public class Solution
{
    public int CountGoodStrings(int low, int high, int zero, int one)
    {
        int[] dp = new int[high + 1];
        dp[0] = 1;
        const int mod = 1_000_000_007;

        for (int end = 1; end <= high; end++)
        {
            if (end >= zero)
            {
                dp[end] += dp[end - zero];
            }
            if (end >= one){
                dp[end] += dp[end - one];
            }
            dp[end] %= mod;
        }

        int ans = 0;
        for (int i = low; i <= high; i++){
            ans += dp[i];
            ans %= mod;
        }
        return ans;

    }
}