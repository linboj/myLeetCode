public class Solution
{
    public int MinJumps(int[] arr)
    {
        int n = arr.Length;
        if (n == 1) return 0;

        Dictionary<int, List<int>> graph = new();

        for (int i = 0; i < n; i++)
        {
            if (!graph.ContainsKey(arr[i]))
                graph[arr[i]] = new();

            graph[arr[i]].Add(i);
        }

        Queue<int> q = new();
        bool[] visited = new bool[n];
        int ans = 0;

        q.Enqueue(0);
        visited[0] = true;


        while (q.Count > 0)
        {
            int levelSize = q.Count;

            for (int i = 0; i < levelSize; i++)
            {
                int node = q.Dequeue();
                if (node == n - 1) return ans;

                if (node - 1 >= 0 && !visited[node - 1])
                {
                    q.Enqueue(node - 1);
                    visited[node - 1] = true;
                }

                if (node + 1 < n && !visited[node + 1])
                {
                    q.Enqueue(node + 1);
                    visited[node + 1] = true;
                }

                if (graph.ContainsKey(arr[node]))
                {
                    foreach (var neighbor in graph[arr[node]])
                    {
                        if (neighbor != node && !visited[neighbor])
                        {
                            q.Enqueue(neighbor);
                            visited[neighbor] = true;
                        }
                    }

                    graph[arr[node]].Clear();
                }
            }
            ans++;
        }

        return -1;
    }
}