public class Solution
{
    public int MaxProfit(int[] prices)
    {
        int max = 0;
        int buyPrice = prices[0];
        for (int i = 0; i < prices.Length; i++)
        {
            if (buyPrice < prices[i]){
                max += prices[i] - buyPrice;
            }
            buyPrice = prices[i];
        }
        return max;
    }
}