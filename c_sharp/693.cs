public class Solution
{
    public bool HasAlternatingBits(int n)
    {
        int prev = n % 2;
        n /= 2;
        while (n > 0)
        {
            int cur = n % 2;
            if (cur == prev)
                return false;

            n /= 2;
            prev = cur;
        }
        return true;
    }
}