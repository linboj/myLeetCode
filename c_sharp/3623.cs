public class Solution
{
    private const int MOD = 1_000_000_007;
    public int CountTrapezoids(int[][] points)
    {
        Dictionary<int, int> yCnts = new();
        long ans = 0, sum = 0;

        foreach (var point in points)
        {
            if (!yCnts.ContainsKey(point[1]))
            {
                yCnts[point[1]] = 0;
            }
            yCnts[point[1]]++;
        }

        foreach (var val in yCnts.Values)
        {
            long edges = (long)val * (val - 1) / 2;
            ans = (ans + sum * edges) % MOD;
            sum = (sum + edges) % MOD;
        }
        return (int)ans;
    }
}