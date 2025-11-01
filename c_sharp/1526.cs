public class Solution
{
    public int MinNumberOperations(int[] target)
    {
        int ans = 0, now = 0;
        foreach (var num in target)
        {
            if (num > now)
                ans += num - now;

            now = num;
        }
        return ans;
    }
}