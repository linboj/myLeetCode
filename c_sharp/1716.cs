public class Solution
{
    public int TotalMoney(int n)
    {
        int ans = 0;
        int week = 0, current = 7;

        while (n > 0)
        {
            if (week == 0)
            {
                current -= 6;
            }
            ans += current++;
            week = (week + 1) % 7;
            n--;
        }
        return ans;
    }
}