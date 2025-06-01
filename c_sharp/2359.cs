public class Solution
{
    public int ClosestMeetingNode(int[] edges, int node1, int node2)
    {
        int n = edges.Length;

        int[] distances1 = new int[n];
        int[] distances2 = new int[n];
        Array.Fill(distances1, int.MaxValue);
        Array.Fill(distances2, int.MaxValue);
        distances1[node1] = 0;
        distances2[node2] = 0;

        bool[] visited1 = new bool[n];
        bool[] visited2 = new bool[n];

        Dfs(node1, edges, distances1, visited1);
        Dfs(node2, edges, distances2, visited2);

        int minDist = int.MaxValue, ans = -1;
        for (int i = 0; i < n; i++)
        {
            int currentNodeDist = Math.Max(distances1[i], distances2[i]);
            if (minDist > currentNodeDist)
            {
                ans = i;
                minDist = currentNodeDist;
            }
        }

        return ans;
    }

    private void Dfs(int node, int[] edges, int[] distances, bool[] visited)
    {
        visited[node] = true;
        int neighbor = edges[node];
        if (neighbor != -1 && !visited[neighbor])
        {
            distances[neighbor] = 1 + distances[node];
            Dfs(neighbor, edges, distances, visited);
        }
    }
}

public class Solution2
{
    public int ClosestMeetingNode(int[] edges, int node1, int node2)
    {
        int n = edges.Length;

        int[] distances1 = GetDistance(node1, edges);
        int[] distances2 = GetDistance(node2, edges);

        int minDist = int.MaxValue, ans = -1;
        for (int i = 0; i < n; i++)
        {
            if (distances1[i] != -1 && distances2[i] != -1)
            {

                int currentNodeDist = Math.Max(distances1[i], distances2[i]);
                if (minDist > currentNodeDist)
                {
                    ans = i;
                    minDist = currentNodeDist;
                }
            }
        }
        return ans;
    }

    private int[] GetDistance(int start, int[] edges)
    {
        int[] distances = new int[edges.Length];
        Array.Fill(distances, -1);
        int distance = 0, current = start;

        while (current != -1 && distances[current] == -1)
        {
            distances[current] = distance++;
            current = edges[current];
        }

        return distances;
    }
}