public class Solution
{
    public long MinOperations(int[][] queries)
    {
        long ans = 0;
        foreach (var query in queries)
        {
            long nOp1 = GetOperations(query[1]);
            long nOp2 = GetOperations(query[0] - 1);
            ans += (nOp1 - nOp2 + 1) / 2;
        }
        return ans;
    }

    private long GetOperations(int num)
    {
        long count = 0;
        int baseVal = 1;
        int i = 1;
        while (num >= baseVal)
        {
            int end = Math.Min(baseVal * 2 - 1, num);
            count += (long)((i + 1) / 2) * (end - baseVal + 1);
            i++;
            baseVal *= 2;
        }
        return count;
    }
}