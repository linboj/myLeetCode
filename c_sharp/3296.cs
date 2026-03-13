public class Solution
{
    private const double EPS = 1e-7;
    public long MinNumberOfSeconds(int mountainHeight, int[] workerTimes)
    {
        int maxTime = 0;
        foreach (var workerTime in workerTimes)
        {
            maxTime = Math.Max(maxTime, workerTime);
        }

        long l = 1;
        long r = (long)maxTime * (mountainHeight + 1) * mountainHeight / 2;

        long ans = 0;

        while (l <= r)
        {
            long mid = (l + r) / 2;
            long cnt = 0;

            foreach (var workerTime in workerTimes)
            {
                long work = mid / workerTime;

                long k = (long)((-1.0 + Math.Sqrt(1 + work * 8)) / 2 + EPS);
                cnt += k;
            }

            if (cnt >= mountainHeight)
            {
                ans = mid;
                r = mid - 1;
            }
            else
            {
                l = mid + 1;
            }
        }

        return ans;
    }
}