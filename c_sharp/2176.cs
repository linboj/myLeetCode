public class Solution
{
    public int CountPairs(int[] nums, int k)
    {
        int n = nums.Length, ans = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if ((j * i) % k == 0 && nums[j] == nums[i])
                    ans++;
            }
        }
        return ans;
    }
}