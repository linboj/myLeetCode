public class Solution
{
    public int MaximizeSquareHoleArea(int n, int m, int[] hBars, int[] vBars)
    {
        Array.Sort(hBars);
        Array.Sort(vBars);
        int hCMax = 1;
        int vCMax = 1;
        int cnt = 1;

        for (int i = 1; i < hBars.Length; i++)
        {
            if (hBars[i] == hBars[i - 1] + 1)
                cnt++;
            else
                cnt = 1;

            hCMax = Math.Max(hCMax, cnt);
        }

        cnt = 1;
        for (int i = 1; i < vBars.Length; i++)
        {
            if (vBars[i] == vBars[i - 1] + 1)
                cnt++;
            else
                cnt = 1;

            vCMax = Math.Max(vCMax, cnt);
        }

        int l = Math.Min(vCMax, hCMax) + 1;
        return l * l;
    }
}