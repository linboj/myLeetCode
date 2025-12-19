public class Solution
{
    public long MaxProfit(int[] prices, int[] strategy, int k)
    {
        int n = prices.Length;
        long[] profitSum = new long[n + 1];
        long[] priceSum = new long[n + 1];

        for (int i = 0; i < n; i++)
        {
            profitSum[i + 1] = profitSum[i] + prices[i] * strategy[i];
            priceSum[i + 1] = priceSum[i] + prices[i];
        }

        long ans = profitSum[n];
        for (int i = 0; i < n - k + 1; i++)
        {
            long leftPart = profitSum[i];
            long rightPart = profitSum[n] - profitSum[i + k];
            long opsPart = priceSum[i + k] - priceSum[i + k / 2];
            ans = Math.Max(ans, leftPart + rightPart + opsPart);
        }
        return ans;
    }
}

public class Solution2
{
    public long MaxProfit(int[] prices, int[] strategy, int k)
    {
        int n = prices.Length;
        long maxDiff = 0;
        long diff = 0;
        long ori = 0;
        for (int i = 0; i < k / 2; i++)
        {
            diff += (0 - strategy[i]) * prices[i];
            ori += strategy[i] * prices[i];
        }

        for (int i = k / 2; i < k; i++)
        {
            diff += (1 - strategy[i]) * prices[i];
            ori += strategy[i] * prices[i];
        }

        maxDiff = Math.Max(maxDiff, diff);

        for (int i = k; i < n; i++)
        {
            diff -= (0 - strategy[i - k]) * prices[i - k];
            diff -= prices[i - k / 2];
            diff += (1 - strategy[i]) * prices[i];
            maxDiff = Math.Max(maxDiff, diff);
            ori += strategy[i] * prices[i];
        }
        return ori + maxDiff;
    }
}