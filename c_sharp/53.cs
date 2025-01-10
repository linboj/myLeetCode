public class Solution
{
    public int MaxSubArray(int[] nums)
    {
        // Kadane's Algorithm
        int endHereMax = 0, result = nums[0];
        foreach (var num in nums)
        {
            endHereMax = Math.Max(endHereMax, 0);
            endHereMax += num;
            result = Math.Max(result, endHereMax);
        }
        return result;
    }
}