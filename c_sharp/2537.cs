public class Solution
{
    public long CountGood(int[] nums, int k)
    {
        int n = nums.Length;
        int right = -1, same = 0;
        Dictionary<int, int> counts = new();
        long ans = 0;

        for (int left = 0; left < n; left++)
        {
            while (same < k && right + 1 < n)
            {
                right++;
                counts.TryGetValue(nums[right], out int current);
                same += current;
                counts[nums[right]] = current + 1;
            }

            if (same >= k)
                ans += n - right;

            counts[nums[left]]--;
            same -= counts[nums[left]];
        }

        return ans;
    }
}