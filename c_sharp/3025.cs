public class Solution
{
    public int NumberOfPairs(int[][] points)
    {
        Array.Sort(points, (a, b) => a[0] == b[0] ? b[1].CompareTo(a[1]) : a[0].CompareTo(b[0]));

        int n = points.Length;
        int ans = 0;

        for (int i = 0; i < n; i++)
        {
            int top = points[i][1];
            int bottom = int.MinValue;

            for (int j = i + 1; j < n; j++)
            {
                int y = points[j][1];
                if (bottom < y && y <= top)
                {
                    ans++;
                    bottom = y;
                    if (bottom == top) break;
                }
            }
        }
        return ans;
    }
}