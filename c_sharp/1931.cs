public class Solution
{
    private const int MOD = 1000000007;
    private List<int> states = new();
    public int ColorTheGrid(int m, int n)
    {
        // get all valid column state
        Dfs(0, -1, 0, m);

        int statesCount = states.Count;
        // get compatibility states to each valid column 
        var compatibility = new List<int>[statesCount];
        for (int i = 0; i < statesCount; i++)
        {
            compatibility[i] = new List<int>();
        }
        for (int i = 0; i < statesCount; i++)
        {
            for (int j = 0; j < statesCount; j++)
            {
                int cell1 = states[i], cell2 = states[j];
                bool isValid = true;
                for (int k = 0; k < m; k++)
                {
                    if (cell1 % 3 == cell2 % 3)
                    {
                        isValid = false;
                        break;
                    }
                    cell1 /= 3;
                    cell2 /= 3;
                }
                if (isValid)
                    compatibility[i].Add(j);
            }
        }

        var dp = new int[statesCount];
        Array.Fill(dp, 1);
        var new_dp = new int[statesCount];
        for (int t = 0; t < n - 1; t++)
        {
            Array.Fill(new_dp, 0);
            for (int i = 0; i < statesCount; i++)
            {
                int dpv = dp[i];
                if (dpv != 0)
                {
                    foreach (int j in compatibility[i])
                    {
                        new_dp[j] = (new_dp[j] + dpv) % MOD;
                    }
                }
            }
            var tmp = dp;
            dp = new_dp;
            new_dp = tmp;
        }

        long ans = 0;
        foreach (int v in dp)
            ans = (ans + v) % MOD;
        return (int)ans;
    }

    private void Dfs(int pos, int prevColor, int mask, int m)
    {
        if (pos == m)
        {
            states.Add(mask);
            return;
        }

        for (int color = 0; color < 3; color++)
        {
            if (color != prevColor)
                Dfs(pos + 1, color, 3 * mask + color, m);
        }
    }
}