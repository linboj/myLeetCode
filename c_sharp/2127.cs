public class Solution
{
    public int MaximumInvitations(int[] favorite)
    {
        int n = favorite.Length;
        List<int>[] reversedGraph = new List<int>[n];

        for (int i = 0; i < n; i++)
        {
            if (reversedGraph[i] == null) reversedGraph[i] = new List<int>();
            if (reversedGraph[favorite[i]] == null) reversedGraph[favorite[i]] = new List<int>();
            reversedGraph[favorite[i]].Add(i);
        }
        int longestCycle = 0;
        int twoCycleInvitations = 0;
        bool[] visited = new bool[n];

        for (int person = 0; person < n; person++)
        {
            if (!visited[person])
            {
                Dictionary<int, int> visitedPersons = new();
                int currentPerson = person;
                int distance = 0;
                while (true)
                {
                    if (visited[currentPerson]) break;
                    visited[currentPerson] = true;
                    visitedPersons.Add(currentPerson, distance++);
                    int nextPerson = favorite[currentPerson];

                    if (visitedPersons.ContainsKey(nextPerson))
                    {
                        int cycleLength = distance - visitedPersons[nextPerson];
                        longestCycle = Math.Max(longestCycle, cycleLength);

                        if (cycleLength == 2)
                        {
                            HashSet<int> visitedNodes = new HashSet<int>() { currentPerson, nextPerson };
                            twoCycleInvitations += 2 + BFS(currentPerson, visitedNodes, reversedGraph) + BFS(nextPerson, visitedNodes, reversedGraph);
                        }
                        break;
                    }
                    currentPerson = nextPerson;
                }
            }
        }
        return Math.Max(longestCycle, twoCycleInvitations);

    }

    private int BFS(int startNode, HashSet<int> visitedNodes, List<int>[] reversedGraph)
    {
        Queue<(int node, int distance)> queue = new();
        queue.Enqueue((startNode, 0));
        int maxDistance = 0;
        while (queue.Count > 0)
        {
            var (currentNode, currentDistance) = queue.Dequeue();
            foreach (var neighbor in reversedGraph[currentNode])
            {
                if (visitedNodes.Contains(neighbor)) continue;

                visitedNodes.Add(neighbor);
                queue.Enqueue((neighbor, currentDistance + 1));
                maxDistance = Math.Max(maxDistance, currentDistance + 1);
            }
        }
        return maxDistance;
    }
}

public class Solution2
{
    // Topological Sort to Reduce Non-Cyclic Nodes
    public int MaximumInvitations(int[] favorite)
    {
        int n = favorite.Length;
        int[] inDegree = new int[n];    // how many nodes point to it.

        for (int person = 0; person < n; person++)
        {
            inDegree[favorite[person]]++;
        }

        // remove non-cycle nodes
        Queue<int> queue = new();
        for (int person = 0; person < n; person++)
        {
            if (inDegree[person] == 0) queue.Enqueue(person);
        }

        int[] depth = new int[n];   // the longest path from any starting node to that particular node.
        Array.Fill(depth, 1);

        while (queue.Count > 0)
        {
            int currentNode = queue.Dequeue();
            int nextNode = favorite[currentNode];
            depth[nextNode] = Math.Max(depth[nextNode], depth[currentNode] + 1);
            if (--inDegree[nextNode] == 0) queue.Enqueue(nextNode);
        }

        int longestCycle = 0;
        int twoCycleInvitations = 0;
        
        for (int person = 0; person < n; person++)
        {
            if (depth[person] == 0) continue;

            int cycleLength = 0;
            int current = person;
            while (inDegree[current] != 0)
            {
                inDegree[current] = 0;
                cycleLength++;
                current = favorite[current];
            }

            if (cycleLength == 2)
            {
                twoCycleInvitations += depth[person] + depth[favorite[person]];
            }
            else
            {
                longestCycle = Math.Max(longestCycle, cycleLength);
            }
        }
        return Math.Max(longestCycle, twoCycleInvitations);

    }

}