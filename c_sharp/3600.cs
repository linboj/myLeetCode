public class Solution
{
    const int MAX_STABILITY = 200000;
    public int MaxStability(int n, int[][] edges, int k)
    {
        int ans = -1;

        if (edges.Length < n - 1)
            return ans;

        List<int[]> mustE = new();
        List<int[]> optionalE = new();

        foreach (var edge in edges)
        {
            if (edge[3] == 1)
                mustE.Add(edge);
            else
                optionalE.Add(edge);
        }

        if (mustE.Count > n - 1)
            return ans;

        optionalE.Sort((a, b) => b[2].CompareTo(a[2]));

        int selectedI = 0;
        int minStabilityI = MAX_STABILITY;
        var parent = Enumerable.Range(0, n).ToArray();

        DSU dsuI = new DSU(parent);

        foreach (var edge in mustE)
        {
            if (dsuI.Find(edge[0]) == dsuI.Find(edge[1]) || selectedI == n - 1)
                return -1;

            dsuI.Join(edge[0], edge[1]);
            selectedI++;
            minStabilityI = Math.Min(minStabilityI, edge[2]);
        }

        int l = 0, r = minStabilityI;

        while (l < r)
        {
            int mid = l + (r + 1 - l) / 2;

            DSU dsu = new DSU((int[])dsuI.parent.Clone());

            int selected = selectedI;
            int doubleCnt = 0;

            foreach (var edge in optionalE)
            {
                if (dsu.Find(edge[0]) == dsu.Find(edge[1]))
                    continue;

                if (edge[2] >= mid)
                {
                    dsu.Join(edge[0], edge[1]);
                    selected++;
                }
                else if (doubleCnt < k && edge[2] * 2 >= mid)
                {
                    doubleCnt++;
                    dsu.Join(edge[0], edge[1]);
                    selected++;
                }
                else
                {
                    break;
                }

                if (selected == n - 1)
                    break;
            }

            if (selected != n - 1)
                r = mid - 1;
            else
                ans = l = mid;
        }

        return ans;
    }
}

public class DSU
{
    public int[] parent;

    public DSU(int[] parent)
    {
        this.parent = parent;
    }

    public int Find(int x)
    {
        if (parent[x] == x) return x;

        return parent[x] = Find(parent[x]);
    }

    public void Join(int x, int y)
    {
        int xp = Find(x);
        int yp = Find(y);
        parent[xp] = yp;
    }
}