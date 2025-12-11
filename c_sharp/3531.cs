public class Solution
{
    public int CountCoveredBuildings(int n, int[][] buildings)
    {
        int[] maxXInY = new int[n + 1];
        int[] minXInY = new int[n + 1];
        int[] maxYInX = new int[n + 1];
        int[] minYInX = new int[n + 1];

        Array.Fill(minXInY, n + 1);
        Array.Fill(minYInX, n + 1);

        foreach (var b in buildings)
        {
            int x = b[0], y = b[1];
            maxXInY[y] = Math.Max(maxXInY[y], x);
            minXInY[y] = Math.Min(minXInY[y], x);
            maxYInX[x] = Math.Max(maxYInX[x], y);
            minYInX[x] = Math.Min(minYInX[x], y);
        }

        int ans = 0;
        foreach (var b in buildings)
        {
            int x = b[0], y = b[1];
            if (x < maxXInY[y] && x > minXInY[y] && y < maxYInX[x] && y > minYInX[x])
                ans++;
        }
        return ans;
    }
}