public class Solution
{
    public int MinCost(int n, int[][] edges)
    {
        var neighbors = new List<(int node, int weight)>[n];
        for (int i = 0; i < n; i++)
        {
            neighbors[i] = new();
        }

        foreach (var e in edges)
        {
            int from = e[0], to = e[1], w = e[2];
            neighbors[from].Add((to, w));
            neighbors[to].Add((from, w * 2));
        }

        int[] dists = new int[n];
        bool[] visited = new bool[n];
        Array.Fill(dists, int.MaxValue);
        dists[0] = 0;

        PriorityQueue<(int node, int weight), int> pq = new();
        pq.Enqueue((0, 0), 0);

        while (pq.Count > 0)
        {
            var (curNode, curW) = pq.Dequeue();

            if (curNode == n - 1)
                return curW;

            if (visited[curNode])
                continue;

            visited[curNode] = true;

            foreach (var (nextNode, nextW) in neighbors[curNode])
            {
                int sumW = curW + nextW;
                if (sumW < dists[nextNode])
                {
                    dists[nextNode] = sumW;
                    pq.Enqueue((nextNode, dists[nextNode]), dists[nextNode]);
                }
            }
        }
        return -1;
    }
}