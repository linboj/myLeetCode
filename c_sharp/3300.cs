public class Solution
{
    public int MinElement(int[] nums)
    {
        int ans = int.MaxValue;

        foreach (var num in nums)
        {
            int cur = num;
            int sum = 0;
            while (cur > 0)
            {
                sum += cur % 10;
                cur /= 10;
            }

            ans = Math.Min(ans, sum);
        }

        return ans;
    }
}