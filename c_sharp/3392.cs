public class Solution
{
    public int CountSubarrays(int[] nums)
    {
        int ans = 0;

        for (int i = 0; i < nums.Length - 2; i++)
        {
            if ((nums[i] + nums[i + 2]) * 2 == nums[i + 1])
            {
                ans++;
            }
        }

        return ans;
    }
}