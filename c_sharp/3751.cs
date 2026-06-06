public class Solution
{
    public int TotalWaviness(int num1, int num2)
    {
        int ans = 0;

        int start = Math.Max(num1, 100);
        for (int i = start; i <= num2; i++)
        {
            int num = i;
            while (num >= 100)
            {
                int r = num % 10;
                int c = (num % 100 - r) / 10;
                int l = (num % 1000 - c * 10 - r) / 100;
                if (l > c && c < r) ans++;
                if (l < c && c > r) ans++;

                num /= 10;
            }
        }

        return ans;
    }
}