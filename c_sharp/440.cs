public class Solution
{
    public int FindKthNumber(int n, int k)
    {
        int current = 1;
        k--;
        while (k > 0)
        {
            int nStep = countSteps(n, current, current + 1);
            if (nStep <= k)
            {
                current++;
                k -= nStep;
            }
            else
            {
                current *= 10;
                k--;
            }
        }

        return current;
    }

    private int countSteps(int n, long prefix1, long prefix2)
    {
        long nStep = 0;
        while (prefix1 <= n)
        {
            nStep += Math.Min(n + 1, prefix2) - prefix1;
            prefix1 *= 10;
            prefix2 *= 10;
        }
        return (int)nStep;
    }
}