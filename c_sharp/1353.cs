public class Solution
{
    public int MaxEvents(int[][] events)
    {
        int n = events.Length;
        int lastDay = 0, ans = 0;
        Array.Sort(events, (a, b) => a[0] - b[0]);
        foreach (var item in events)
        {
            lastDay = Math.Max(lastDay, item[1]);
        }

        PriorityQueue<int, int> pq = new();
        int currentIdx = 0;
        for (int i = 1; i <= lastDay; i++)
        {
            while (currentIdx < n && events[currentIdx][0] == i)
            {
                pq.Enqueue(events[currentIdx][1], events[currentIdx][1]);
                currentIdx++;
            }

            while (pq.Count > 0 && pq.Peek() < i)
            {
                pq.Dequeue();
            }

            if (pq.Count > 0)
            {
                pq.Dequeue();
                ans++;
            }
        }
        return ans;
    }
}