public class Solution
{
    private const int MOD = 1_000_000_007;
    public int MaximizeSquareArea(int m, int n, int[] hFences, int[] vFences)
    {
        long maxEdge = 0;
        HashSet<int> diffSet = new();
        List<int> hEdges = new(hFences), vEdges = new(vFences);
        hEdges.Add(1);
        hEdges.Add(m);
        vEdges.Add(1);
        vEdges.Add(n);
        int hL = hEdges.Count, vL = vEdges.Count;

        for (int i = 0; i < hL; i++)
        {
            for (int j = i + 1; j < hL; j++)
            {
                diffSet.Add(Math.Abs(hEdges[i] - hEdges[j]));
            }
        }

        for (int i = 0; i < vL; i++)
        {
            for (int j = i + 1; j < vL; j++)
            {
                int diff = Math.Abs(vEdges[i] - vEdges[j]);
                if (diffSet.Contains(diff))
                    maxEdge = Math.Max(diff, maxEdge);
            }
        }

        if (maxEdge == 0) return -1;

        return (int)(maxEdge * maxEdge % MOD);
    }
}