public class Solution
{
    public int BinaryGap(int n)
    {
        int ans = 0;
        int prev = n, idx = -1;

        while (n > 0)
        {
            idx++;
            int bit = n % 2;
            if (bit == 1)
            {
                ans = Math.Max(ans, idx - prev);
                prev = idx;
            }

            n /= 2;
        }
        return ans;
    }
}