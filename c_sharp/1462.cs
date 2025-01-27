public class Solution
{
    // Kahn's Algorithm
    public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries)
    {
        bool[] ans = new bool[queries.Length];
        if (prerequisites.Length == 0) return ans;
        List<int>[] adjList = new List<int>[numCourses];
        int[] inDegree = new int[numCourses];   // how many nodes point to it.

        foreach (var item in prerequisites)
        {
            if (adjList[item[0]] == null) adjList[item[0]] = new List<int>();
            adjList[item[0]].Add(item[1]);
            inDegree[item[1]]++;
        }

        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < numCourses; i++)
        {
            if (inDegree[i] == 0) queue.Enqueue(i);
        }
        HashSet<int>[] nodePrerequisites = new HashSet<int>[numCourses];
        for (int i = 0; i < numCourses; i++)
        {
            nodePrerequisites[i] = new HashSet<int>();
        }
        while (queue.Count > 0){
            var course = queue.Dequeue();
            if (adjList[course] == null) continue;
            foreach (var adj in adjList[course])
            {
                if (nodePrerequisites[adj] == null) nodePrerequisites[adj] = new HashSet<int>();
                nodePrerequisites[adj].Add(course);
                foreach (var item in nodePrerequisites[course])
                {
                    nodePrerequisites[adj].Add(item);
                }
                inDegree[adj]--;
                if (inDegree[adj] == 0) queue.Enqueue(adj);
            }
        }
        
        for (int i = 0; i < queries.Length; i++){
            if (nodePrerequisites[queries[i][1]].Contains(queries[i][0])){
                ans[i] = true;
            }
        }
        return ans;

    }
}

public class Solution2
{
    // Tree Traversal - Preprocessed
    public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries)
    {
        bool[] ans = new bool[queries.Length];
        if (prerequisites.Length == 0) return ans;
        List<int>[] adjList = new List<int>[numCourses];
        bool[][] isPrerequisite = new bool[numCourses][];
        for (int i = 0; i < numCourses; i++)
        {
            adjList[i] = new List<int>();
            isPrerequisite[i] = new bool[numCourses];
        }

        foreach (var item in prerequisites){
            adjList[item[0]].Add(item[1]);
        }

        preprocess(numCourses, adjList, isPrerequisite);
        for (int i = 0; i < queries.Length; i++){
            ans[i] = isPrerequisite[queries[i][0]][queries[i][1]];
        }
        return ans;

    }

    private void preprocess(int numCourses, List<int>[] adjList, bool[][] isPrerequisite){
        for (int i = 0; i < numCourses; i++)
        {
            Queue<int> queue = new ();
            queue.Enqueue(i);

            while (queue.Count > 0){
                var node = queue.Dequeue();
                foreach (var adj in adjList[node])
                {
                    if (!isPrerequisite[i][adj]){
                        isPrerequisite[i][adj] = true;
                        queue.Enqueue(adj);
                    }
                }
            }
        }
    }
}