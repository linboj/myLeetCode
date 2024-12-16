public class Solution
{
    public double MaxAverageRatio(int[][] classes, int extraStudents)
    {
        PriorityQueue<int, double> pq = new(Comparer<double>.Create((a, b) => b.CompareTo(a)));
        for (int i = 0; i < classes.Length; i++)
        {
            double change = (double)(classes[i][0] + 1) / (classes[i][1] + 1) - (double)classes[i][0] / classes[i][1];
            pq.Enqueue(i, change);
        }

        while (extraStudents > 0)
        {
            int maxChangeIdx = pq.Dequeue();
            classes[maxChangeIdx][0] += 1;
            classes[maxChangeIdx][1] += 1;
            extraStudents--;
            double change = (double)(classes[maxChangeIdx][0] + 1) / (classes[maxChangeIdx][1] + 1) - (double)classes[maxChangeIdx][0] / classes[maxChangeIdx][1];
            pq.Enqueue(maxChangeIdx, change);
        }

        double ans = 0d;
        foreach (var item in classes)
        {
            ans += (double)item[0] / item[1];
        }
        return ans / classes.Length;
    }
}