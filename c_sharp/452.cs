public class Solution
{
    public int FindMinArrowShots(int[][] points)
    {
        Array.Sort(points, (a, b) => a[0].CompareTo(b[0]));
        int count = 1;
        var start = points[0][0];
        var end = points[0][1];

        for (int i = 1; i < points.Length; i++)
        {
            start = Math.Max(points[i][0], start);
            end = Math.Min(points[i][1], end);
            if (start > end)
            {
                count++;
                start = points[i][0];
                end = points[i][1];
            }
        }

        return count;
    }
}