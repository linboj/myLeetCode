public class Solution
{
    public long CountSubarrays(int[] nums, int minK, int maxK)
    {
        int n = nums.Length;
        int invalidIdx = -1, minKIdx = -1, maxKIdx = -1;
        long ans = 0;

        for (int i = 0; i < n; i++)
        {
            if (nums[i] < minK || nums[i] > maxK)
                invalidIdx = i;

            if (nums[i] == minK)
                minKIdx = i;

            if (nums[i] == maxK)
                maxKIdx = i;

            ans += Math.Max(0, Math.Min(minKIdx, maxKIdx) - invalidIdx);
        }

        return ans;
    }
}