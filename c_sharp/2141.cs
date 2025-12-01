public class Solution
{
    public long MaxRunTime(int n, int[] batteries)
    {
        long totalSum = 0;
        foreach (var power in batteries)
        {
            totalSum += power;
        }

        long l = 1, r = totalSum / n;

        while (l < r)
        {
            long mid = r - (r - l) / 2;
            long extra = 0;

            foreach (var power in batteries)
            {
                extra += Math.Min(power, mid);
            }

            if (extra >= (long)(n * mid))
                l = mid;
            else
                r = mid - 1;
        }
        return l;
    }
}