public class Solution
{
    public IList<int> EventualSafeNodes(int[][] graph)
    {
        int n = graph.Length;
        int[] count = new int[n];
        List<int>[] reverseGraph = new List<int>[n];
        Queue<int> queue = new();
        for (int i = 0; i < n; i++)
        {
            reverseGraph[i] = new List<int>();
        }
        for (int i = 0; i < n; i++)
        {
            if (graph[i].Length == 0)
                queue.Enqueue(i);
            else
            {
                foreach (var neighbor in graph[i])
                {
                    count[i]++;
                    reverseGraph[neighbor].Add(i);
                }
            }
        }
        while (queue.Count > 0)
        {
            int safe = queue.Dequeue();
            foreach (var neighbor in reverseGraph[safe])
            {
                count[neighbor]--;
                if (count[neighbor] == 0) queue.Enqueue(neighbor);
            }
        }
        List<int> ans = new();
        for (int i = 0; i < n; i++)
        {
            if (count[i] == 0) ans.Add(i);
        }
        return ans;
    }
}

public class Solution2
{
    public IList<int> EventualSafeNodes(int[][] graph)
    {
        int n = graph.Length;
        bool[] visited = new bool[n];
        bool[] inStack = new bool[n];

        for (int i = 0; i < n; i++)
        {
            DFS(i, graph, visited, inStack);
        }

        List<int> ans = new();
        for (int i = 0; i < n; i++)
        {
            if (!inStack[i]) ans.Add(i);
        }
        return ans;
    }

    private bool DFS(int node, int[][] adj, bool[] visit, bool[] inStack){
        if (inStack[node]) return true;

        if (visit[node]) return false;

        visit[node] = true;
        inStack[node] = true;
        foreach (var neighbor in adj[node])
        {
            if (DFS(neighbor, adj, visit, inStack)) return true;
        }

        inStack[node] = false;
        return false;
    }
}