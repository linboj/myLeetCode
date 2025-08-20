public class Solution
{
    public long ZeroFilledSubarray(int[] nums)
    {
        long ans = 0;
        int count = 0;

        foreach (var num in nums)
        {
            count = (num == 0) ? count + 1 : 0;
            ans += count;
        }
        return ans;
    }
}