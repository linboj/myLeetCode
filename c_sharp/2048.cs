public class Solution
{
    public int NextBeautifulNumber(int n)
    {
        string num = n.ToString();
        long len = num.Length;
        long[] count = new long[10];

        long ans = Generate(n, 0, len, count);
        if (ans == 0)
        {
            Array.Fill(count, 0);
            return (int)Generate(0, 0, len + 1, count);
        }
        return (int)ans;
    }

    private long Generate(long n, long current, long remaining, long[] count)
    {
        if (remaining == 0)
        {
            if (current > n)
            {
                for (int d = 0; d < 10; d++)
                {
                    if (count[d] > 0 && count[d] != d) return 0;
                }
                return current;
            }
            return 0;
        }

        long ans = 0;
        for (int d = 0; d < 10 && ans == 0; d++)
        {
            if (count[d] < d && d - count[d] <= remaining)
            {
                count[d]++;
                ans = Generate(n, current * 10 + d, remaining - 1, count);
                count[d]--;
            }
        }
        return ans;
    }
}