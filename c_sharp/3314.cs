public class Solution
{
    public int[] MinBitwiseArray(IList<int> nums)
    {
        int n = nums.Count;
        int[] ans = new int[n];
        for (int i = 0; i < n; i++)
        {
            int num = nums[i];
            int r = -1;
            int d = 1;
            while ((num & d) != 0)
            {
                r = num - d;
                d <<= 1;
            }
            ans[i] = r;
        }
        return ans;
    }
}