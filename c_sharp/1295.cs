public class Solution
{
    public int FindNumbers(int[] nums)
    {
        int ans = 0;

        foreach (var num in nums)
        {
            ans += ((int)Math.Log10(num)) & 1;
        }
        return ans;
    }
}