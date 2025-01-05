public class Solution
{
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        List<int>[] depends = new List<int>[numCourses];
        int[] preCount = new int[numCourses];
        int visited = 0;
        foreach (var item in prerequisites)
        {
            if (depends[item[1]] == null)
            {
                depends[item[1]] = new List<int>();
            }
            depends[item[1]].Add(item[0]);
            preCount[item[0]]++;
        }
        for (int i = 0; i < preCount.Length; i++)
        {
            if (preCount[i] == 0){
                Visit(i);
            }
        }

        void Visit(int item){
            preCount[item]=-1;
            visited++;
            if (depends[item] == null) return;
            foreach (var next in depends[item])
            {
                if (--preCount[next] == 0)
                    Visit(next);
            }
        }

        return visited == numCourses;
    }
}