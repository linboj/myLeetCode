public class Solution
{
    public int MinDominoRotations(int[] tops, int[] bottoms)
    {
        int ans = Check(tops, bottoms, tops[0]);
        if (ans == -1) ans = Check(tops, bottoms, bottoms[0]);
        return ans;
    }

    private int Check(int[] tops, int[] bottoms, int target)
    {
        int missTop = 0, missBottom = 0;
        for (int i = 0; i < tops.Length; i++)
        {
            if (tops[i] != target && bottoms[i] != target)
                return -1;
            if (tops[i] != target)
                missTop++;
            if (bottoms[i] != target)
                missBottom++;
        }
        return Math.Min(missTop, missBottom);
    }
}