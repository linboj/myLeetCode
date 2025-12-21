public class Solution
{
    public int MinDeletionSize(string[] strs)
    {
        int ans = 0;
        if (strs.Length == 0) return ans;
        int n = strs.Length, m = strs[0].Length;
        bool[] cuts = new bool[n - 1];

        for (int c = 0; c < m; c++)
        {
            bool isValid = true;
            for (int r = 0; r < n - 1; r++)
            {
                if (!cuts[r] && strs[r][c] > strs[r + 1][c])
                {
                    isValid = false;
                    ans++;
                    break;
                }
            }

            if (!isValid) continue;

            for (int r = 0; r < n - 1; r++)
            {
                if (strs[r][c] < strs[r + 1][c])
                    cuts[r] = true;
            }
        }
        return ans;
    }
}