public class Solution
{
    public IList<bool> PrefixesDivBy5(int[] nums)
    {
        int mod = 0, n = nums.Length;
        bool[] ans = new bool[n];

        for (int i = 0; i < n; i++)
        {
            mod = ((mod << 1) + nums[i]) % 5;
            ans[i] = mod == 0;
        }

        return ans;
    }
}