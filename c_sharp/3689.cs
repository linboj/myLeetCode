public class Solution
{
    public long MaxTotalValue(int[] nums, int k)
    {
        int maxVal = int.MinValue;
        int minVal = int.MaxValue;

        foreach (var num in nums)
        {
            maxVal = Math.Max(num, maxVal);
            minVal = Math.Min(num, minVal);
        }

        return (long)(maxVal - minVal) * k;
    }
}