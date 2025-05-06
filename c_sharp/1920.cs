public class Solution
{
    public int[] BuildArray(int[] nums)
    {
        int n = nums.Length;
        int[] ans = new int[n];

        for (int i = 0; i < n; i++)
        {
            ans[i] = nums[nums[i]];
        }

        return ans;
    }
}

public class Solution2
{
    public int[] BuildArray(int[] nums)
    {
        int n = nums.Length;

        for (int i = 0; i < n; i++)
        {
            nums[i] += 1000 * (nums[nums[i]] % 1000);
        }

        for (int i = 0; i < n; i++)
        {
            nums[i] /= 1000;
        }

        return nums;
    }
}