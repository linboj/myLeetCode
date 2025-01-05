// BFS
public class Solution
{
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        Dictionary<string, List<(string, double)>> map = new();
        for (int i = 0; i < values.Length; i++)
        {
            string src = equations[i][0], dest = equations[i][1];
            if (!map.ContainsKey(src))
            {
                map[src] = new List<(string, double)>();
            }
            map[src].Add((dest, values[i]));
            if (!map.ContainsKey(dest))
            {
                map[dest] = new List<(string, double)>();
            }
            map[dest].Add((src, 1.0 / values[i]));
        }
        double[] ans = new double[queries.Count];
        for (int i = 0; i < ans.Length; i++)
        {

            if (!map.ContainsKey(queries[i][0]) || !map.ContainsKey(queries[i][0]))
            {
                ans[i] = -1.0;
            }
            else
            {
                var curRes = BFS(map, new HashSet<string>(), queries[i][0], queries[i][1]);
                ans[i] = curRes == double.MaxValue ? -1 : curRes;
            }

        }
        return ans;
    }

    private double BFS(Dictionary<string, List<(string, double)>> map, HashSet<string> visited, string src, string dest)
    {
        Queue<(string, double)> queue = new();
        queue.Enqueue((src, 1));
        while (queue.Count > 0)
        {
            var curIterationCount = queue.Count;
            for (int i = 0; i < curIterationCount; i++)
            {
                var (curElem, curPrice) = queue.Dequeue();

                if (curElem == dest) return curPrice;
                else if (visited.Contains(curElem)) continue;

                visited.Add(curElem);

                if (map.ContainsKey(curElem))
                {
                    foreach (var (elem, price) in map[curElem])
                    {
                        queue.Enqueue((elem, curPrice * price));
                    }
                }
            }
        }
        return double.MaxValue;
    }
}

// DFS
public class Solution2
{
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
        Dictionary<string, List<(string, double)>> map = new();
        for (int i = 0; i < values.Length; i++)
        {
            string src = equations[i][0], dest = equations[i][1];
            if (!map.ContainsKey(src))
            {
                map[src] = new List<(string, double)>();
            }
            map[src].Add((dest, values[i]));
            if (!map.ContainsKey(dest))
            {
                map[dest] = new List<(string, double)>();
            }
            map[dest].Add((src, 1.0 / values[i]));
        }
        double[] ans = new double[queries.Count];
        for (int i = 0; i < ans.Length; i++)
        {

            if (!map.ContainsKey(queries[i][0]) || !map.ContainsKey(queries[i][0]))
            {
                ans[i] = -1.0;
            }
            else
            {
                var curRes = DFS(map, new HashSet<string>(), queries[i][0], queries[i][1], 1);
                ans[i] = curRes == double.MaxValue ? -1 : curRes;
            }

        }
        return ans;
    }

    private double DFS(Dictionary<string, List<(string, double)>> map, HashSet<string> visited, string src, string dest, double price)
    {
        if (src == dest) return price;
        else if (visited.Contains(src)) return double.MaxValue;

        visited.Add(src);

        if (map.ContainsKey(src))
        {
            foreach (var (neighborElem, neighborPrice) in map[src])
            {
                var result = DFS(map, visited, neighborElem, dest, price * neighborPrice);

                if (result != double.MaxValue) return result;
            }
        }

        return double.MaxValue;
    }
}