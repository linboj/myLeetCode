public class Solution
{
    private const int MOD = 1000000007;
    public int NumSub(string s)
    {
        long ans = 0, cnt = 0;

        foreach (var c in s)
        {
            if (c == '0')
            {
                ans = (ans + cnt * (cnt + 1) / 2) % MOD;
                cnt = 0;
            }
            else
            {
                cnt++;
            }
        }
        ans = (ans + cnt * (cnt + 1) / 2) % MOD;

        return (int)ans;
    }
}