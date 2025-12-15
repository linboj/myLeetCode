public class Solution
{
    public long GetDescentPeriods(int[] prices)
    {
        long ans = 0;
        int matches = 1;
        int cur = -1;

        foreach (var price in prices)
        {
            if (price == cur - 1)
                matches++;
            else
                matches = 1;
            cur = price;
            ans += matches;
        }
        return ans;
    }
}