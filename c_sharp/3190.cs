public class Solution
{
    public int MinimumOperations(int[] nums)
    {
        int ans = 0;
        foreach (var num in nums)
        {
            ans += Math.Min(num % 3, 3 - (num % 3));
        }
        return ans;
    }
}