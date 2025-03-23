public class Solution
{
    public long MOD = 1_000_000_007;
    public int CountPaths(int n, int[][] roads)
    {
        // create adjList
        List<(int, int)>[] adjList = new List<(int, int)>[n];
        for (int i = 0; i < n; i++)
            adjList[i] = new();
        foreach (var road in roads)
        {
            adjList[road[0]].Add((road[1], road[2]));
            adjList[road[1]].Add((road[0], road[2]));
        }

        // init min heap
        PriorityQueue<(int, long), long> pq = new();

        // init minTimes to record min time to each node
        long[] minTimes = new long[n];
        // set root to 0, and others set to max value
        Array.Fill(minTimes, long.MaxValue);
        minTimes[0] = 0;

        // record the count of min time path to each node
        int[] pathCounts = new int[n];
        pathCounts[0] = 1;

        // enqueue the root
        pq.Enqueue((0, 0), 0);

        while (pq.Count > 0)
        {
            var (curNode, curTime) = pq.Dequeue();

            if (curTime > minTimes[curNode]) continue;

            foreach (var (neighborNode, roadTime) in adjList[curNode])
            {
                long totalTime = roadTime + curTime;
                if (totalTime < minTimes[neighborNode])
                {
                    minTimes[neighborNode] = totalTime;
                    pathCounts[neighborNode] = pathCounts[curNode];
                    pq.Enqueue((neighborNode, totalTime), totalTime);
                }
                else if (totalTime == minTimes[neighborNode])
                {
                    pathCounts[neighborNode] = (int)((pathCounts[neighborNode] + pathCounts[curNode]) % MOD);
                }
            }
        }
        return pathCounts[n - 1];
    }
}