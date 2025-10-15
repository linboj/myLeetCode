public class Solution
{
    public int MaxIncreasingSubarrays(IList<int> nums)
    {
        int n = nums.Count;
        int preCount = 0, count = 1, ans = 0;

        for (int i = 1; i < n; i++)
        {
            if (nums[i] > nums[i - 1])
            {
                count++;
            }
            else
            {
                preCount = count;
                count = 1;
            }
            ans = Math.Max(ans, Math.Min(preCount, count));
            ans = Math.Max(ans, count / 2);
        }
        return ans;
    }
}