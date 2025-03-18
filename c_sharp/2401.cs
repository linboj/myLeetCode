public class Solution
{
    public int LongestNiceSubarray(int[] nums)
    {
        int n = nums.Length;
        int left = 0, right = 0;
        int sum = 0, longest = 0;

        while (right < n)
        {
            while ((sum & nums[right]) != 0)
            {
                sum -= nums[left++];
            }
            longest = Math.Max(longest, right - left + 1);
            sum += nums[right];
            right++;
        }
        return longest;
    }
}