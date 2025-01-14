public class Solution {
    public int MaxSubarraySumCircular(int[] nums) {
        // Kadane's Algorithm
        int endHereMin = 0, minSum = nums[0], total = 0;
        int endHereMax = 0, maxSum = nums[0];
        foreach (var num in nums)
        {
            total += num;
            // find max sum subarray
            endHereMax = Math.Max(endHereMax, 0);
            maxSum = Math.Max(maxSum, endHereMax);
            endHereMax += num;
            // find min sum subarray
            endHereMin = Math.Min(endHereMin, 0);
            minSum = Math.Min(minSum, endHereMin);
            endHereMin += num;
        }
        if (maxSum <= 0) return maxSum;

        return Math.Max(maxSum, total - minSum);
    }
}