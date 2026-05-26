public class Solution
{
    public bool CanReach(string s, int minJump, int maxJump)
    {
        int n = s.Length;
        int[] f = new int[n];
        int[] pre = new int[n];

        f[0] = 1;
        for (int i = 0; i < minJump; i++)
        {
            pre[i] = 1;
        }

        for (int i = minJump; i < n; i++)
        {
            int l = i - maxJump;
            int r = i - minJump;

            if (s[i] == '0')
            {
                int sum = pre[r] - (l <= 0 ? 0 : pre[l - 1]);
                f[i] = sum != 0 ? 1 : 0;
            }
            pre[i] = pre[i - 1] + f[i];
        }

        return f[n - 1] == 1;
    }
}