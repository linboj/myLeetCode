public class Solution
{
    public int MinimumScore(int[] nums, int[][] edges)
    {
        int n = nums.Length;
        List<List<int>> adj = new List<List<int>>();
        for (int i = 0; i < n; i++)
        {
            adj.Add(new List<int>());
        }

        foreach (var edge in edges)
        {
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }

        int[] sum = new int[n];
        int[] inSeq = new int[n];
        int[] outSeq = new int[n];
        int count = 0;
        Dfs(0, -1, nums, adj, sum, inSeq, outSeq, ref count);

        int ans = int.MaxValue;
        for (int u = 1; u < n; u++)
        {
            for (int v = u + 1; v < n; v++)
            {
                if (inSeq[v] > inSeq[u] && inSeq[v] < outSeq[u])
                    ans = Math.Min(ans, Calc(sum[0] ^ sum[u], sum[u] ^ sum[v], sum[v]));
                else if (inSeq[u] > inSeq[v] && inSeq[u] < outSeq[v])
                    ans = Math.Min(ans, Calc(sum[0] ^ sum[v], sum[v] ^ sum[u], sum[u]));
                else
                    ans = Math.Min(ans, Calc(sum[0] ^ sum[u] ^ sum[v], sum[u], sum[v]));
            }
        }
        return ans;
    }

    private void Dfs(int x, int f, int[] nums, List<List<int>> adj, int[] sum, int[] inSeq, int[] outSeq, ref int count)
    {
        inSeq[x] = count++;
        sum[x] = nums[x];
        foreach (int y in adj[x])
        {
            if (y == f)
                continue;
            Dfs(y, x, nums, adj, sum, inSeq, outSeq, ref count);
            sum[x] ^= sum[y];
        }
        outSeq[x] = count;
    }

    private int Calc(int part1, int part2, int part3)
    {
        return Math.Max(part1, Math.Max(part2, part3)) -
               Math.Min(part1, Math.Min(part2, part3));
    }
}