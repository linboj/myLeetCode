public class Solution
{
    public int MaxDistance(string s, int k)
    {
        int n = s.Length;
        int dx = 0, dy = 0, ans = 0;
        int[] counts = new int[4];

        foreach (var ch in s)
        {
            switch (ch)
            {
                case 'N':
                    dy++;
                    counts[0]++;
                    break;
                case 'S':
                    dy--;
                    counts[1]++;
                    break;
                case 'E':
                    dx++;
                    counts[2]++;
                    break;
                case 'W':
                    dx--;
                    counts[3]++;
                    break;
            }
            int y = Math.Min(Math.Min(counts[0], counts[1]), k);
            int x = Math.Min(Math.Min(counts[2], counts[3]), k - y);
            ans = Math.Max(ans, Math.Abs(dy) + y * 2 + Math.Abs(dx) + x * 2);
        }
        return ans;
    }
}

public class Solution2
{
    public int MaxDistance(string s, int k)
    {
        int n = s.Length;
        int dx = 0, dy = 0, ans = 0;

        for (int i = 0; i < n; i++)
        {
            char ch = s[i];
            switch (ch)
            {
                case 'N':
                    dy++;
                    break;
                case 'S':
                    dy--;
                    break;
                case 'E':
                    dx++;
                    break;
                case 'W':
                    dx--;
                    break;
            }
            ans = Math.Max(ans, Math.Min(Math.Abs(dy) + Math.Abs(dx) + 2 * k, i + 1));
        }
        return ans;
    }
}