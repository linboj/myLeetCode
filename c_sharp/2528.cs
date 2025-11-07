public class Solution
{
    public long MaxPower(int[] stations, int r, int k)
    {
        int n = stations.Length;
        long[] cnts = new long[n + 1];
        long low = long.MaxValue;
        long high = k;

        for (int i = 0; i < n; i++)
        {
            int s = Math.Max(0, i - r);
            int e = Math.Min(n, i + r + 1);
            cnts[s] += stations[i];
            cnts[e] -= stations[i];
            low = Math.Min(low, stations[i]);
            high += stations[i];
        }

        long ans = 0;

        while (low <= high)
        {
            long mid = (low + high) / 2;
            if (Check(cnts, mid, r, k))
            {
                ans = mid;
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }
        return ans;
    }

    private bool Check(long[] cnts, long val, int r, int k)
    {
        int n = cnts.Length - 1;
        long[] diff = (long[])cnts.Clone();
        long sum = 0;
        long remaining = k;

        for (int i = 0; i < n; i++)
        {
            sum += diff[i];
            if (sum < val)
            {
                long add = val - sum;
                if (add > remaining)
                    return false;

                remaining -= add;
                int end = Math.Min(n, i + 2 * r + 1);
                diff[end] -= add;
                sum += add;
            }
        }
        return true;
    }
}