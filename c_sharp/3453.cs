public class Solution
{
    public double SeparateSquares(int[][] squares)
    {
        long totalArea = 0;
        List<int[]> events = new();

        foreach (var square in squares)
        {
            int y = square[1];
            int l = square[2];

            totalArea += (long)l * l;
            events.Add([y, l, 1]);
            events.Add([y + l, l, -1]);
        }

        events.Sort((a, b) => a[0].CompareTo(b[0]));
        double coveredWidth = 0;
        double curArea = 0;
        double prevH = 0;

        foreach (var e in events)
        {
            int y = e[0];
            int l = e[1];
            int d = e[2];

            int diff = y - (int)prevH;
            double area = coveredWidth * diff;

            if (2L * (curArea + area) >= totalArea)
                return prevH + (totalArea - 2.0 * curArea) / (2.0 * coveredWidth);

            coveredWidth += d * l;
            curArea += area;
            prevH = y;
        }
        return 0.0;
    }
}

public class Solution2
{
    public double SeparateSquares(int[][] squares)
    {
        double totalArea = 0;
        double high = 0;

        foreach (var square in squares)
        {
            int y = square[1], l = square[2];
            totalArea += (double)l * l;
            high = Math.Max(high, (double)y + l);
        }

        double low = 0;
        double eps = 1e-5;
        while (Math.Abs(high - low) > eps)
        {
            double mid = (high + low) / 2.0;
            if (Check(mid, squares, totalArea))
                high = mid;
            else
                low = mid;
        }

        return high;
    }

    private bool Check(double h, int[][] squares, double totalArea)
    {
        double area = 0;
        foreach (var square in squares)
        {
            int y = square[1], l = square[2];
            if (y < h)
                area += (double)l * Math.Min(h - y, (double)l);
        }

        return area >= totalArea / 2;
    }
}