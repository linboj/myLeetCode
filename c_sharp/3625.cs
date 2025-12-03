public class Solution
{
    private const int INF = 1_000_000_007;
    public int CountTrapezoids(int[][] points)
    {
        int n = points.Length;
        Dictionary<double, List<double>> slopToIntercept = new();
        Dictionary<double, List<double>> midToSlop = new();
        int ans = 0;

        for (int i = 0; i < n; i++)
        {
            int x1 = points[i][0];
            int y1 = points[i][1];
            for (int j = i + 1; j < n; j++)
            {
                int x2 = points[j][0];
                int y2 = points[j][1];
                int dx = x1 - x2;
                int dy = y1 - y2;
                double a, b;

                if (x1 == x2)
                {
                    a = INF;
                    b = x1;
                }
                else
                {
                    a = (double)dy / dx;
                    b = (double)(y1 * dx - x1 * dy) / dx;
                }

                double mid = (x1 + x2) * 10000.0 + y1 + y2;
                if (!slopToIntercept.ContainsKey(a))
                    slopToIntercept[a] = new();
                if (!midToSlop.ContainsKey(mid))
                    midToSlop[mid] = new();

                slopToIntercept[a].Add(b);
                midToSlop[mid].Add(a);
            }
        }

        foreach (var bValtList in slopToIntercept.Values)
        {
            if (bValtList.Count == 1)
                continue;

            Dictionary<double, int> cnt = new();
            foreach (double bVal in bValtList)
            {
                cnt[bVal] = cnt.GetValueOrDefault(bVal, 0) + 1;
            }
            int totalSum = 0;
            foreach (int count in cnt.Values)
            {
                ans += totalSum * count;
                totalSum += count;
            }
        }

        foreach (var sloptList in midToSlop.Values)
        {
            if (sloptList.Count == 1)
                continue;

            Dictionary<double, int> cnt = new();
            foreach (double slop in sloptList)
            {
                cnt[slop] = cnt.GetValueOrDefault(slop, 0) + 1;
            }
            int totalSum = 0;
            foreach (int count in cnt.Values)
            {
                ans -= totalSum * count;
                totalSum += count;
            }
        }
        return ans;
    }
}