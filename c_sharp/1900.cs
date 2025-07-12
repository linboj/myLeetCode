public class Solution
{
    private int[,,] F = new int[30, 30, 30];
    private int[,,] G = new int[30, 30, 30];
    public int[] EarliestAndLatest(int n, int firstPlayer, int secondPlayer)
    {
        if (firstPlayer > secondPlayer)
        {
            (firstPlayer, secondPlayer) = (secondPlayer, firstPlayer);
        }

        int[] ans = dp(n, firstPlayer, secondPlayer);
        return ans;
    }

    private int[] dp(int n, int f, int s)
    {
        if (F[n, f, s] != 0)
        {
            return [F[n, f, s], G[n, f, s]];
        }

        if (f + s == n + 1)
        {
            return [1, 1];
        }

        if (f + s > n + 1)
        {
            int[] res = dp(n, n + 1 - s, n + 1 - f);
            F[n, f, s] = res[0];
            G[n, f, s] = res[1];
            return [F[n, f, s], G[n, f, s]];
        }

        int earliest = int.MaxValue;
        int latest = int.MinValue;
        int nHalf = (n + 1) / 2;
        if (s <= nHalf)
        {
            for (int i = 0; i < f; ++i)
            {
                for (int j = 0; j < s - f; ++j)
                {
                    int[] res = dp(nHalf, i + 1, i + j + 2);
                    earliest = Math.Min(earliest, res[0]);
                    latest = Math.Max(latest, res[1]);
                }
            }
        }
        else
        {
            int sPrime = n + 1 - s;
            int mid = (n - 2 * sPrime + 1) / 2;
            for (int i = 0; i < f; ++i)
            {
                for (int j = 0; j < sPrime - f; ++j)
                {
                    int[] res = dp(nHalf, i + 1, i + j + mid + 2);
                    earliest = Math.Min(earliest, res[0]);
                    latest = Math.Max(latest, res[1]);
                }
            }
        }

        F[n, f, s] = earliest + 1;
        G[n, f, s] = latest + 1;
        return [F[n, f, s], G[n, f, s]];
    }
}