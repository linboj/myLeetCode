public class Solution
{
    private int[] parent;
    private int[] rank;

    public int MinimumHammingDistance(int[] source, int[] target, int[][] allowedSwaps)
    {
        int n = source.Length;
        parent = new int[n];
        rank = new int[n];
        for (int i = 0; i < n; i++)
        {
            parent[i] = i;
        }

        foreach (var swap in allowedSwaps)
        {
            Union(swap[0], swap[1]);
        }

        Dictionary<int, Dictionary<int, int>> sets = new();
        for (int i = 0; i < n; i++)
        {
            int p = Find(i);
            if (!sets.ContainsKey(p))
                sets[p] = new();

            if (!sets[p].ContainsKey(source[i]))
                sets[p][source[i]] = 0;

            sets[p][source[i]]++;
        }

        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            int p = Find(i);
            if (sets[p].ContainsKey(target[i]) && sets[p][target[i]] > 0)
                sets[p][target[i]]--;
            else
                ans++;
        }

        return ans;
    }

    private int Find(int x)
    {
        if (parent[x] != x)
            parent[x] = Find(parent[x]);

        return parent[x];
    }

    private void Union(int x, int y)
    {
        x = Find(x);
        y = Find(y);

        if (x == y)
            return;
        if (rank[x] < rank[y])
        {
            (y, x) = (x, y);
        }

        parent[y] = x;
        if (rank[x] == rank[y])
            rank[x]++;
    }
}