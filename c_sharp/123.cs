public class Solution {
    public int MaxProfit(int[] prices) {
        int n = prices.Length;
        int[] profits = new int[n];

        int minBuyPrice = prices[0];
        int maxSellPrice = prices[n - 1];

        for (int i = 1; i < n; i++)
        {
            int price = prices[i];
            minBuyPrice = Math.Min(minBuyPrice, price);
            profits[i] = Math.Max(profits[i-1], price - minBuyPrice);
        }

        for (int i = n - 2; i >= 0 ; i--)
        {
            int price = prices[i];
            maxSellPrice = Math.Max(price, maxSellPrice);
            profits[i] = Math.Max(profits[i+1], profits[i] + maxSellPrice - price);
        }

        return profits[0];
        
    }
}

public class Solution2 {
    public int MaxProfit(int[] prices) {
        int buy1 = int.MinValue;
        int sell1 = 0;
        int buy2 = int.MinValue;
        int sell2 = 0;

        foreach (var price in prices)
        {
            buy1 = Math.Max(buy1, -price);
            sell1 = Math.Max(sell1, price + buy1);
            buy2 = Math.Max(buy2, sell1 - price);
            sell2 = Math.Max(sell2, buy2 + price);
        }

        return sell2;
    }
}