// Monotonic Stack
public class Solution
{
    public int[] LeftmostBuildingQueries(int[] heights, int[][] queries)
    {
        List<List<Tuple<int, int>>> newQueries = new(heights.Length);
        List<Tuple<int, int>> monoStack = new();
        int[] ans = new int[queries.Length];
        Array.Fill(ans, -1);

        for (int i = 0; i < heights.Length; i++)
        {
            newQueries.Add(new List<Tuple<int, int>>());
        }

        for (int i = 0; i < queries.Length; i++)
        {
            if (queries[i][0] > queries[i][1])
            {
                int temp = queries[i][0];
                queries[i][0] = queries[i][1];
                queries[i][1] = temp;
            }

            if (queries[i][0] == queries[i][1] || heights[queries[i][0]] < heights[queries[i][1]])
            {
                ans[i] = queries[i][1];
            }
            else
            {
                newQueries[queries[i][1]].Add(new Tuple<int, int>(heights[queries[i][0]], i));
            }
        }

        for (int i = heights.Length - 1; i >= 0; i--)
        {
            int stackSize = monoStack.Count;
            foreach (var tuple in newQueries[i])
            {
                int position = search(tuple.Item1, monoStack);
                if (position < stackSize && position >= 0)
                {
                    ans[tuple.Item2] = monoStack[position].Item2;
                }
            }

            while (monoStack.Count > 0 && monoStack[monoStack.Count - 1].Item1 < heights[i])
            {
                monoStack.RemoveAt(monoStack.Count - 1);
            }

            monoStack.Add(new Tuple<int, int>(heights[i], i));
        }

        return ans;
    }

    private int search(int height, List<Tuple<int, int>> monoStack)
    {
        int left = 0, right = monoStack.Count - 1;
        int ans = -1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (monoStack[mid].Item1 > height)
            {
                ans = Math.Max(ans, mid);
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return ans;
    }
}

// Priority Queue
public class Solution2
{
    public int[] LeftmostBuildingQueries(int[] heights, int[][] queries)
    {
        List<List<Tuple<int, int>>> storeQueries = new(heights.Length);
        for (int i = 0; i < heights.Length; i++)
        {
            storeQueries.Add(new List<Tuple<int, int>>());
        }
        PriorityQueue<Tuple<int, int>, int> pq = new();
        int[] ans = new int[queries.Length];
        Array.Fill(ans, -1);

        //Store the mappings for all queries in storeQueries.
        for (int currQuery = 0; currQuery < queries.Length; currQuery++)
        {
            int a = queries[currQuery][0], b = queries[currQuery][1];
            if (a < b && heights[a] < heights[b])
            {
                ans[currQuery] = b;
            }
            else if (a > b && heights[a] > heights[b])
            {
                ans[currQuery] = a;
            }
            else if (a == b)
            {
                ans[currQuery] = a;
            }
            else
            {
                storeQueries[Math.Max(a, b)].Add(new Tuple<int, int>(Math.Max(heights[a], heights[b]), currQuery));
            }
        }

        for (int i = 0; i < heights.Length; i++)
        {
            while (pq.Count > 0 && pq.Peek().Item1 < heights[i])
            {
                ans[pq.Peek().Item2] = i;
                pq.Dequeue();
            }

            foreach (var element in storeQueries[i])
            {
                pq.Enqueue(element, element.Item1);
            }
        }

        return ans;
    }
}