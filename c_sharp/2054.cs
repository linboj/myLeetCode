public class Solution
{
    public int MaxTwoEvents(int[][] events)
    {
        List<int[]> times = new();

        foreach (var e in events)
        {
            times.Add([e[0], 1, e[2]]);
            times.Add([e[1] + 1, 0, e[2]]);
        }
        times.Sort((a, b) => a[0] == b[0] ? a[1].CompareTo(b[1]) : a[0].CompareTo(b[0]));
        int ans = 0, maxVal = 0;

        foreach (var time in times)
        {
            if (time[1] == 1)
            {
                ans = Math.Max(ans, time[2] + maxVal);
            }
            else
            {
                maxVal = Math.Max(maxVal, time[2]);
            }
        }
        return ans;
    }
}

public class Solution2
{
    public int MaxTwoEvents(int[][] events)
    {
        Array.Sort(events, (a, b) => a[0].CompareTo(b[0]));
        PriorityQueue<int[], int> pq = new();

        int ans = 0, maxVal = 0;

        foreach (var e in events)
        {
            int start = e[0], end = e[1], val = e[2];
            while (pq.Count > 0 && pq.Peek()[0] < start)
            {
                maxVal = Math.Max(maxVal, pq.Dequeue()[1]);
            }
            ans = Math.Max(ans, maxVal + val);
            pq.Enqueue([end, val], end);
        }
        return ans;
    }
}