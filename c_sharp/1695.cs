public class Solution
{
    public int MaximumUniqueSubarray(int[] nums)
    {
        int n = nums.Length;
        bool[] used = new bool[10001];
        int left = 0;
        int ans = 0, sum = 0;

        for (int right = 0; right < n; right++)
        {
            while (used[nums[right]])
            {
                used[nums[left]] = false;
                sum -= nums[left];
                left++;
            }

            used[nums[right]] = true;
            sum += nums[right];
            ans = Math.Max(ans, sum);
        }

        return ans;
    }
}