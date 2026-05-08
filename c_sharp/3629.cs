public class Solution
{
    private static readonly int mx = 1000001;
    private static readonly List<int>[] factors = new List<int>[mx];

    static Solution()
    {
        for (int i = 0; i < mx; i++)
        {
            factors[i] = new();
        }

        for (int i = 2; i < mx; i++)
        {
            if (factors[i].Count == 0)
            {
                for (int j = i; j < mx; j += i)
                {
                    factors[j].Add(i);
                }
            }
        }
    }

    public int MinJumps(int[] nums)
    {
        int n = nums.Length;
        var edges = new Dictionary<int, List<int>>();

        for (int i = 0; i < n; i++)
        {
            foreach (var p in factors[nums[i]])
            {
                if (!edges.ContainsKey(p))
                    edges[p] = new();

                edges[p].Add(i);
            }
        }

        int ans = 0;
        bool[] seen = new bool[n];
        seen[0] = true;
        List<int> q = new List<int> { 0 };
        while (true)
        {
            List<int> q2 = new List<int>();
            foreach (var i in q)
            {
                if (i == n - 1)
                    return ans;

                if (i > 0 && !seen[i - 1])
                {
                    seen[i - 1] = true;
                    q2.Add(i - 1);
                }

                if (i < n - 1 && !seen[i + 1])
                {
                    seen[i + 1] = true;
                    q2.Add(i + 1);
                }

                if (factors[nums[i]].Count == 1)
                {
                    int p = nums[i];
                    if (edges.TryGetValue(p, out var list))
                    {
                        foreach (var j in list)
                        {
                            if (!seen[j])
                            {
                                seen[j] = true;
                                q2.Add(j);
                            }
                        }
                        list.Clear();
                    }
                }
            }
            q = q2;
            ans++;
        }
    }
}