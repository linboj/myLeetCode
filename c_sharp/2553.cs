public class Solution
{
    public int[] SeparateDigits(int[] nums)
    {
        int n = nums.Length;
        List<int> ans = new();

        for (int i = n - 1; i >= 0; i--)
        {
            int cur = nums[i];
            while (cur > 0)
            {
                ans.Add(cur % 10);
                cur /= 10;
            }

        }
        ans.Reverse();

        return ans.ToArray();
    }
}