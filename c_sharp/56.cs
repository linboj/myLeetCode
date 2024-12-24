public class Solution
{
    public int[][] Merge(int[][] intervals)
    {
        if (intervals.Length == 0) return new int[0][];
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        List<int[]> result = new List<int[]>();
        for (int i = 0; i < intervals.Length; i++)
        {

            int startIdx = i;
            int end = intervals[i][1];
            while (i < intervals.Length - 1 && end >= intervals[i + 1][0])
            {
                i++;
                if (intervals[i][1] > end) end = intervals[i][1];
            }

            result.Add([intervals[startIdx][0], end]);
        }

        return result.ToArray();

    }
}