public class Solution
{
    public double LargestTriangleArea(int[][] points)
    {
        double ans = 0.0;
        int n = points.Length;
        for (int i = 0; i < n; i++)
            for (int j = i + 1; j < n; j++)
                for (int k = j + 1; k < n; k++)
                {
                    double area = 0.5 * Math.Abs(
                        points[i][0] * (points[j][1] - points[k][1]) +
                        points[j][0] * (points[k][1] - points[i][1]) +
                        points[k][0] * (points[i][1] - points[j][1])
                        );
                    ans = Math.Max(ans, area);
                }
        return ans;
    }
}