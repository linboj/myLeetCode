public class Solution
{
    public int MinPairSum(int[] nums)
    {
        int n = nums.Length;
        int ans = int.MinValue;
        Array.Sort(nums);

        for (int i = 0; i < n / 2; i++)
        {
            int pairSum = nums[i] + nums[n - i - 1];
            ans = Math.Max(ans, pairSum);
        }
        return ans;
    }
}