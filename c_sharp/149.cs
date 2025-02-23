public class Solution
{
    public int MaxPoints(int[][] points)
    {
        int n = points.Length;
        if (n < 3) return n;
        int max = 0;
        for (int i = 0; i < n; i++)
        {
            Dictionary<double, int> map = new();
            for (int j = 0; j < n; j++)
            {
                int dx = points[i][0] - points[j][0];
                int dy = points[i][1] - points[j][1];
                if (dx == 0 && dy == 0) continue;
                var atan2 = Math.Atan2(dy, dx);
                if (!map.ContainsKey(atan2)) map[atan2] = 1;
                map[atan2]++;
                if (map[atan2] > max) max = map[atan2];
            }
        }
        return max;
    }

}

public class Solution2
{
    public int MaxPoints(int[][] points)
    {
        int n = points.Length;
        if (n < 3) return n;
        int max = 2;
        for (int i = 0; i < n; i++)
        {
            int x1 = points[i][0], y1 = points[i][1];
            for (int j = i + 1; j < n; j++)
            {
                int x2 = points[j][0], y2 = points[j][1];
                int count = 2;
                for (int k = j + 1; k < n; k++)
                {
                    int x3 = points[k][0], y3 = points[k][1];
                    if ((x1 - x2) * (y1 - y3) == (x1 - x3) * (y1 - y2)) count++;
                }
                max = Math.Max(max, count);
            }
        }
        return max;
    }

}

public class Solution3
{
    public int MaxPoints(int[][] points)
    {
        int n = points.Length;
        if (n < 3) return n;
        int max = 2;
        for (int i = 0; i < n; i++)
        {
            Dictionary<(int, int), int> map = new();
            int duplicate = 1;
            for (int j = i + 1; j < n; j++)
            {
                int dx = points[i][0] - points[j][0];
                int dy = points[i][1] - points[j][1];
                if (dx == 0 && dy == 0)
                {
                    duplicate++;
                    continue;
                }

                int gcd = GCD(dx, dy);
                dx /= gcd;
                dy /= gcd;

                if (dx < 0)
                {
                    dx = -dx;
                    dy = -dy;
                }

                if (!map.ContainsKey((dx, dy))) map[(dx, dy)] = 0;
                map[(dx, dy)]++;
            }
            foreach (var (_, value) in map)
            {
                max = Math.Max(max, value + duplicate);
            }
        }
        return max;
    }
    private int GCD(int a, int b)
    {
        return b == 0 ? a : GCD(b, a % b);
    }
}