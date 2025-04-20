public class Solution
{
    public long CountFairPairs(int[] nums, int lower, int upper)
    {
        Array.Sort(nums);
        return LowerBound(nums, upper + 1) - LowerBound(nums, lower);
    }

    public long LowerBound(int[] nums, int val)
    {
        int n = nums.Length;
        long result = 0;
        for (int left = 0, right = n - 1; left < right; left++)
        {
            while (left < right && nums[left] + nums[right] >= val)
            {
                right--;
            }
            result += right - left;
        }
        return result;
    }
}