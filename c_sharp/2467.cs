public class Solution
{
    public int MostProfitablePath(int[][] edges, int bob, int[] amount)
    {
        int n = amount.Length;
        // create adjList
        List<int>[] adjList = new List<int>[n];
        foreach (var edge in edges)
        {
            if (adjList[edge[0]] == null) adjList[edge[0]] = new();
            if (adjList[edge[1]] == null) adjList[edge[1]] = new();
            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }
        // find Bob path by DFS
        int[] BobPath = new int[n];
        BobPath[bob] = 1;
        findBobPath(bob, adjList, 1, BobPath);
        
        int maxProfit = int.MinValue;
        Queue<(int, int, int)> queue = new Queue<(int node, int time, int profit)>();

        // find Alice path by BFS
        int[] AlicePath = new int[n];
        AlicePath[0] = 1;
        foreach (var node in adjList[0])
        {
            queue.Enqueue((node, 2, amount[0]));
        }
        
        while (queue.Count > 0){
            var (node, time, profit) = queue.Dequeue();

            if (AlicePath[node] != 0) continue;
            AlicePath[node] = time;
            if (BobPath[node] == 0 || time < BobPath[node]){
                profit += amount[node];
            } else if (BobPath[node] == time){
                profit += amount[node] / 2;
            }

            bool isLeaf = true;

            foreach (var nextNode in adjList[node])
            {
                if (AlicePath[nextNode] != 0) continue;
                isLeaf = false;
                queue.Enqueue((nextNode, time + 1, profit));
            }

            if (isLeaf && profit > maxProfit) maxProfit = profit;
        }
        return maxProfit;
    }

    private bool findBobPath(int current, List<int>[] adjList, int time, int[] BobPath)
    {
        if (current == 0) return true;

        BobPath[current] = time;
        foreach (var node in adjList[current])
        {
            if (BobPath[node] != 0) continue;
            if (findBobPath(node, adjList, time + 1, BobPath))
            {
                return true;
            }
            else
            {
                BobPath[node] = 0;
            }
        }
        return false;
    }
}