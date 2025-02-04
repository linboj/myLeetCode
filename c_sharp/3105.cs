public class Solution
{
    public int LongestMonotonicSubarray(int[] nums)
    {
        int increasingCount = 1, decreasingCount = 1, max = 0;
        int prev = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > prev)
            {
                increasingCount++;
            }
            else
            {
                max = Math.Max(max, increasingCount);
                increasingCount = 1;
            }

            if (nums[i] < prev)
            {
                decreasingCount++;
            }
            else
            {
                max = Math.Max(max, decreasingCount);
                decreasingCount = 1;
            }
            prev = nums[i];
        }
        max = Math.Max(Math.Max(max, decreasingCount), increasingCount);
        return max;
    }
}