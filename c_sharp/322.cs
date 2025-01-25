public class Solution
{
    public int CoinChange(int[] coins, int amount)
    {
        int[] dp = new int[amount + 1];
        Array.Fill(dp, -1);
        dp[0] = 0;
        for (int i = 1; i <= amount; i++)
        {
            int fewestCoin = int.MaxValue;
            foreach (var coin in coins)
            {
                if (i - coin >= 0 && dp[i - coin] >= 0)
                {
                    fewestCoin = Math.Min(fewestCoin, dp[i - coin] + 1);
                }
            }
            dp[i] = fewestCoin == int.MaxValue ? -1 : fewestCoin;
        }
        return dp[amount];
    }
}

public class Solution2
{
    public int CoinChange(int[] coins, int amount)
    {
        int[] dp = new int[amount + 1];
        Array.Fill(dp, amount + 1);
        dp[0] = 0;
        foreach (var coin in coins)
        {
            for (int i = coin; i <= amount; i++)
            {
                dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
            }
        }
        if (dp[amount] > amount) return -1;

        return dp[amount];
    }
}