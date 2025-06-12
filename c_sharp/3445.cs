public class Solution
{
    public int MaxDifference(string s, int k)
    {
        int n = s.Length;
        int ans = int.MinValue;
        for (char a = '0'; a <= '4'; a++)
        {
            for (char b = '0'; b <= '4'; b++)
            {
                if (a == b) continue;

                int[] best = new int[4];
                Array.Fill(best, int.MaxValue);
                int cntA = 0, cntB = 0;
                int prevA = 0, prevB = 0;
                int left = -1;

                for (int right = 0; right < n; right++)
                {
                    if (s[right] == a) cntA++;
                    if (s[right] == b) cntB++;

                    while (right - left >= k && cntB - prevB >= 2)
                    {
                        int leftStatus = getStatus(prevA, prevB);
                        best[leftStatus] = Math.Min(
                            best[leftStatus],
                            prevA - prevB
                        );
                        ++left;
                        if (s[left] == a) prevA++;
                        if (s[left] == b) prevB++;
                    }

                    int rightStatus = getStatus(cntA, cntB);
                    if (best[rightStatus ^ 0b10] != int.MaxValue)
                    {
                        ans = Math.Max(
                            ans,
                            cntA - cntB - best[rightStatus ^ 0b10]
                        );
                    }
                }
            }
        }
        return ans;
    }

    private int getStatus(int cntA, int cntB)
    {
        return ((cntA & 1) << 1) | (cntB & 1);
    }
}