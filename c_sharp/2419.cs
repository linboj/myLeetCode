public class Solution
{
    public int LongestSubarray(int[] nums)
    {
        int ans = 0, current = 0;
        int max = 0;

        foreach (var num in nums)
        {
            if (num > max)
            {
                max = num;
                current = 0;
                ans = 0;
            }

            if (num == max)
                current++;
            else
                current = 0;

            ans = Math.Max(ans, current);
        }
        return ans;
    }
}