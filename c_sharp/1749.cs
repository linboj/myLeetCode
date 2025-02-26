public class Solution {
    public int MaxAbsoluteSum(int[] nums) {
        int maxAbsSum = 0, minPrefixSum = 0, maxPrefixSum = 0;
        foreach (var num in nums)
        {
            minPrefixSum = Math.Min(0, minPrefixSum + num);
            maxPrefixSum = Math.Max(0, maxPrefixSum + num);
            maxAbsSum = Math.Max(maxAbsSum, maxPrefixSum);
            maxAbsSum = Math.Max(maxAbsSum, -minPrefixSum);
        }
        return maxAbsSum;
    }
}

public class Solution2 {
    public int MaxAbsoluteSum(int[] nums) {
        int prefixSum = 0, minPrefixSum = 0, maxPrefixSum = 0;
        foreach (var num in nums)
        {
            prefixSum += num;
            minPrefixSum = Math.Min(minPrefixSum, prefixSum);
            maxPrefixSum = Math.Max(maxPrefixSum, prefixSum);
        }
        return maxPrefixSum - minPrefixSum;
    }
}