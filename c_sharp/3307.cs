public class Solution
{
    public char KthCharacter(long k, int[] operations)
    {
        int ans = 0;
        int t;
        while (k != 1)
        {
            t = (int)Math.Log2(k);
            if ((1L << t) == k)
                t--;
            k -= (1L << t);
            ans += operations[t];
        }

        return (char)('a' + (ans % 26));
    }
}