public class Solution
{
    public long CountSubarrays(int[] nums, long k)
    {
        int n = nums.Length;
        int right = 0, left = 0;
        long currentSum = 0, ans = 0;

        while (right < n)
        {
            currentSum += nums[right];

            while (currentSum * (right - left + 1) >= k)
            {
                currentSum -= nums[left++];
            }

            ans += right - left + 1;
            right++;
        }

        return ans;
    }
}