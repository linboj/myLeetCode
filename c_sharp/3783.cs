public class Solution
{
    public int MirrorDistance(int n)
    {
        return Math.Abs(n - Rev(n));
    }

    private int Rev(int num)
    {
        int ans = 0;
        while (num > 0)
        {
            ans *= 10;
            ans += num % 10;
            num /= 10;
        }
        return ans;
    }
}