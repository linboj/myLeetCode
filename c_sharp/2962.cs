public class Solution
{
    public long CountSubarrays(int[] nums, int k)
    {
        int n = nums.Length;
        long ans = 0;
        int max = 0, count = 0, right = 0;

        foreach (var num in nums)
        {
            max = Math.Max(max, num);
        }

        for (int left = 0; left < n; left++)
        {
            while (right < n && count < k)
            {
                if (nums[right] == max)
                    count++;
                right++;
            }

            if (count < k)
                break;

            ans += n - right + 1;

            if (nums[left] == max)
                count--;
        }
        return ans;
    }
}