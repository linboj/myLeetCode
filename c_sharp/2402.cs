public class Solution
{
    public int MostBooked(int n, int[][] meetings)
    {
        Array.Sort(meetings, (a, b) => a[0] == b[0] ? a[1] - b[1] : a[0] - b[0]);
        PriorityQueue<int, int> unUsed = new PriorityQueue<int, int>();
        PriorityQueue<(int endTime, int room), (int endTime, int room)> inUse = new(Comparer<(int endTime, int room)>.Create(
            (a, b) => a.endTime == b.endTime ? a.room - b.room : a.endTime - b.endTime));
        int[] times = new int[n];

        for (int i = 0; i < n; i++)
        {
            unUsed.Enqueue(i, i);
        }

        foreach (var meeting in meetings)
        {
            int startTime = meeting[0], endTime = meeting[1];

            while (inUse.Count > 0 && inUse.Peek().endTime <= startTime)
            {
                int room = inUse.Dequeue().room;
                unUsed.Enqueue(room, room);
            }

            if (unUsed.Count > 0)
            {
                int room = unUsed.Dequeue();
                inUse.Enqueue((endTime, room), (endTime, room));
                times[room]++;
            }
            else
            {
                var (nextEndTime, room) = inUse.Dequeue();
                int changedEndTime = nextEndTime + endTime - startTime;
                inUse.Enqueue((changedEndTime, room), (changedEndTime, room));
                times[room]++;
            }
        }

        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            if (times[ans] < times[i])
            {
                ans = i;
            }
        }
        return ans;
    }
}