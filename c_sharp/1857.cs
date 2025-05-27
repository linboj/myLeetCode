public class Solution
{
    public int LargestPathValue(string colors, int[][] edges)
    {
        int n = colors.Length;
        List<int>[] adj = new List<int>[n];
        int[][] counts = new int[n][];
        int[] indegree = new int[n];

        for (int i = 0; i < n; i++)
        {
            adj[i] = new List<int>();
            counts[i] = new int[26];
        }

        foreach (var edge in edges)
        {
            adj[edge[0]].Add(edge[1]);
            indegree[edge[1]]++;
        }

        Queue<int> queue = new();
        for (int i = 0; i < n; i++)
        {
            if (indegree[i] == 0)
                queue.Enqueue(i);
        }

        int nodeProcessed = 0;
        int max = 0;

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
            nodeProcessed++;
            int cIdx = colors[current] - 'a';
            counts[current][cIdx]++;
            max = Math.Max(max, counts[current][cIdx]);

            foreach (var next in adj[current])
            {
                for (int i = 0; i < 26; i++)
                {
                    counts[next][i] = Math.Max(counts[current][i], counts[next][i]);
                }
                if (--indegree[next] == 0)
                    queue.Enqueue(next);
            }
        }

        return nodeProcessed == n ? max : -1;
    }

}