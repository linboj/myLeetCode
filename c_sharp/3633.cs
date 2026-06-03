public class Solution
{
    public int EarliestFinishTime(int[] landStartTime, int[] landDuration, int[] waterStartTime, int[] waterDuration)
    {
        int n = landStartTime.Length, m = waterStartTime.Length;

        int ans = int.MaxValue;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                int landS = landStartTime[i], landD = landDuration[i];
                int waterS = waterStartTime[j], waterD = waterDuration[j];

                ans = Math.Min(ans, Math.Max(landS + landD, waterS) + waterD);
                ans = Math.Min(ans, Math.Max(landS, waterS + waterD) + landD);
            }
        }

        return ans;
    }
}

public class Solution2
{
    public int EarliestFinishTime(int[] landStartTime, int[] landDuration, int[] waterStartTime, int[] waterDuration)
    {
        int landFirst = Solve(landStartTime, landDuration, waterStartTime, waterDuration);
        int waterFirst = Solve(waterStartTime, waterDuration, landStartTime, landDuration);

        return Math.Min(landFirst, waterFirst);
    }

    private int Solve(int[] start1, int[] duration1, int[] start2, int[] duration2)
    {
        int finish1 = int.MaxValue;
        for (int i = 0; i < start1.Length; i++)
        {
            finish1 = Math.Min(finish1, start1[i] + duration1[i]);
        }

        int finish2 = int.MaxValue;
        for (int i = 0; i < start2.Length; i++)
        {
            finish2 = Math.Min(finish2, Math.Max(start2[i], finish1) + duration2[i]);
        }

        return finish2;
    }
}