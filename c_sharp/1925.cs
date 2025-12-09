public class Solution
{
    public int CountTriples(int n)
    {
        int ans = 0;

        for (int i = n; i > 0; i--)
        {
            for (int j = i - 1; j > 0; j--)
            {
                int diff = i * i - j * j;
                int k = (int)Math.Sqrt(diff);
                if (k * k == diff)
                    ans++;
            }
        }
        return ans;
    }
}