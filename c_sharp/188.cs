public class Solution
{
    public int MaxProfit(int k, int[] prices)
    {
        int n = prices.Length;
        if (n == 0 || k == 0) return 0;

        if (k >= n / 2)
        {
            int profits = 0;
            for (int i = 1; i < n; i++)
                profits = Math.Max(profits, profits + prices[i] - prices[i - 1]);
            return profits;
        }

        int[] buys = new int[k + 1];
        Array.Fill(buys, int.MinValue);
        int[] sells = new int[k + 1];
        foreach (var price in prices)
        {
            for (int i = 1; i <= k; i++)
            {
                buys[i] = Math.Max(buys[i], sells[i - 1] - price);
                sells[i] = Math.Max(sells[i], buys[i] + price);
            }
        }
        return sells[k];
    }
}