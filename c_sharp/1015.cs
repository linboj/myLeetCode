public class Solution
{
    public int SmallestRepunitDivByK(int k)
    {
        int r = 0;

        for (int i = 0; i < k; i++)
        {
            r *= 10;
            r += 1;
            r %= k;
            if (r == 0)
                return i + 1;
        }
        return -1;
    }
}