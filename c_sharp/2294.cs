public class Solution
{
    public int PartitionArray(int[] nums, int k)
    {
        int n = nums.Length, ans = 0;
        Array.Sort(nums);
        int idx = 1, current = 0;

        while (current < n)
        {
            while (idx < n && nums[idx] - nums[current] <= k)
                idx++;

            ans++;
            current = idx++;
        }

        return ans;
    }
}