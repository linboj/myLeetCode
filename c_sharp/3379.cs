public class Solution
{
    public int[] ConstructTransformedArray(int[] nums)
    {
        int n = nums.Length;
        int[] ans = new int[n];

        for (int i = 0; i < n; i++)
        {
            int num = nums[i];
            if (num > 0)
            {
                int finalIdx = (num + i) % n; ;
                ans[i] = nums[finalIdx];
            }
            else if (num < 0)
            {
                int finalIdx = ((i + num) % n + n) % n;
                ans[i] = nums[finalIdx];
            }
            else
            {
                ans[i] = num;
            }
        }
        return ans;
    }
}