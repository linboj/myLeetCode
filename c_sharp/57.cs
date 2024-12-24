public class Solution
{
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        List<int[]> ans = new List<int[]>();

        if (intervals.Length == 0) return [newInterval];

        int idx = 0;

        while (idx < intervals.Length && intervals[idx][1] < newInterval[0])
        {
            ans.Add(intervals[idx]);
            idx++;
        }
        int start;
        if (idx < intervals.Length)
        {
            start = Math.Min(intervals[idx][0], newInterval[0]);
        }
        else
        {
            start = newInterval[0];
        }
        while (idx < intervals.Length && intervals[idx][0] <= newInterval[1])
        {
            idx++;
        }
        int end;
        if (idx > 0){
            end = Math.Max(newInterval[1], intervals[idx-1][1]);
        }else{
            end = newInterval[1];
        }
        ans.Add([start, end]);
        while (idx < intervals.Length)
        {
            ans.Add(intervals[idx]);
            idx++;
        }

        return ans.ToArray();

    }
}