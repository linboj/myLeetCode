public class Solution
{
    public bool HasIncreasingSubarrays(IList<int> nums, int k)
    {
        int n = nums.Count;
        int count = 1, preCount = 0, ans = 0;

        for (int i = 1; i < n; i++)
        {
            if (nums[i - 1] < nums[i])
                count++;
            else
            {
                preCount = count;
                count = 1;
            }
            ans = Math.Max(ans, Math.Min(count, preCount));
            ans = Math.Max(ans, count / 2);
        }
        return ans >= k;
    }
}

public class Solution2
{
    public bool HasIncreasingSubarrays(IList<int> nums, int k)
    {
        int n = nums.Count;
        if (k == 1) return true;
        int count = 1;
        for (int i = 1, j = k + 1; j < n; i++, j++)
        {
            if (nums[i - 1] >= nums[i])
                count = 0;
            else if (nums[j - 1] >= nums[j])
                count = 0;
            if (++count == k) return true;
        }
        return false;
    }
}