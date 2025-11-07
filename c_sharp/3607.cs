public class Solution
{
    private int[] parents;
    public int[] ProcessQueries(int c, int[][] connections, int[][] queries)
    {
        parents = new int[c + 1];
        bool[] online = new bool[c + 1];
        int[] offlineCnts = new int[c + 1];
        for (int i = 0; i <= c; i++)
        {
            parents[i] = i;
            online[i] = true;
        }

        foreach (var item in connections)
        {
            Join(item[0], item[1]);
        }

        Dictionary<int, int> minOnlineStation = new();
        foreach (var q in queries)
        {
            int op = q[0], p = q[1];
            if (op == 2)
            {
                online[p] = false;
                offlineCnts[p]++;
            }
        }

        for (int i = 1; i <= c; i++)
        {
            int root = Find(i);
            if (!minOnlineStation.ContainsKey(root))
                minOnlineStation[root] = -1;

            int station = minOnlineStation[root];
            if (online[i])
            {
                if (station == -1 || station > i)
                    minOnlineStation[root] = i;
            }
        }

        int n = queries.Length;
        List<int> ans = new();
        for (int i = n - 1; i >= 0; i--)
        {
            int op = queries[i][0], p = queries[i][1];
            int root = Find(p);
            int station = minOnlineStation[root];

            if (op == 1)
            {
                if (online[p])
                    ans.Add(p);
                else
                    ans.Add(station);
            }

            if (op == 2)
            {
                if (offlineCnts[p] > 1)
                    offlineCnts[p]--;
                else
                {
                    online[p] = true;
                    if (station == -1 || station > p)
                    {
                        minOnlineStation[root] = p;
                    }
                }
            }
        }
        ans.Reverse();
        return ans.ToArray();
    }

    private int Find(int x)
    {
        return parents[x] == x ? x : (parents[x] = Find(parents[x]));
    }

    private void Join(int x, int y)
    {
        parents[Find(y)] = Find(x);
    }
}