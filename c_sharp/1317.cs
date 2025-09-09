public class Solution
{
    public int[] GetNoZeroIntegers(int n)
    {
        int[] ans = new int[2];
        for (int i = 1; i <= (n + 1) / 2; i++)
        {
            if (!IsNoZeroInteger(i))
                continue;

            int other = n - i;
            if (IsNoZeroInteger(other))
            {
                ans[0] = i;
                ans[1] = other;
                return ans;
            }
        }
        return ans;
    }

    private bool IsNoZeroInteger(int n)
    {
        if (n == 0) return false;
        while (n > 0)
        {
            if (n % 10 == 0)
                return false;
            n /= 10;
        }
        return true;
    }
}