public class Solution
{
    public int[] AvoidFlood(int[] rains)
    {
        int n = rains.Length;
        int[] ans = new int[n];
        Array.Fill(ans, 1);
        Dictionary<int, int> filled = new();
        List<int> dryDays = new();

        for (int i = 0; i < n; i++)
        {
            int current = rains[i];

            if (current == 0)
                dryDays.Add(i);
            else
            {
                if (filled.ContainsKey(current))
                {
                    int fullDay = filled[current];
                    int idx = dryDays.BinarySearch(fullDay);
                    if (idx < 0)
                        idx = ~idx;

                    if (idx >= dryDays.Count)
                        return [];

                    int dryDay = dryDays[idx];
                    dryDays.RemoveAt(idx);
                    ans[dryDay] = current;
                    filled[current] = i;
                }

                if (!filled.ContainsKey(current))
                    filled.Add(current, i);
                else
                    filled[current] = i;

                ans[i] = -1;
            }
        }
        return ans;
    }
}

public class Solution2 // UNION FIND
{
    public int[] AvoidFlood(int[] rains)
    {
        int n = rains.Length;
        int[] parent = new int[n + 1];
        for (int i = 0; i <= n; i++)
        {
            parent[i] = i;
        }
        int[] ans = new int[n];
        Array.Fill(ans, 1);
        Dictionary<int, int> filled = new();

        for (int i = 0; i < n; i++)
        {
            int current = rains[i];

            if (current != 0)
            {
                ans[i] = -1;
                Union(parent, i, i + 1);

                if (filled.ContainsKey(current))
                {
                    int fullDay = filled[current];
                    int dry = Find(parent, fullDay + 1);

                    if (dry >= i)
                        return [];

                    ans[dry] = current;
                    Union(parent, dry, dry + 1);
                    filled[current] = i;
                }
                else
                {
                    filled.Add(current, i);
                }

            }
        }
        return ans;
    }

    private int Find(int[] parent, int n)
    {
        if (parent[n] != n)
            parent[n] = Find(parent, parent[n]);

        return parent[n];
    }

    private void Union(int[] parent, int x, int y)
    {
        parent[Find(parent, x)] = Find(parent, y);
    }
}