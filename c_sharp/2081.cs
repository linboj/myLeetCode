public class Solution
{
    private int[] digits = new int[100];

    public long KMirror(int k, int n)
    {
        int left = 1, count = 0;
        long ans = 0;
        while (count < n)
        {
            int right = left * 10;

            for (int opt = 0; opt < 2; opt++)
            {
                for (int i = left; i < right && count < n; i++)
                {
                    long combined = i;
                    int x = opt == 0 ? i / 10 : i;
                    while (x > 0)
                    {
                        combined = combined * 10 + (x % 10);
                        x /= 10;
                    }
                    if (isPalindrome(combined, k))
                    {
                        count++;
                        ans += combined;
                    }
                }
            }
            left = right;
        }
        return ans;
    }

    private bool isPalindrome(long x, int k)
    {
        int length = -1;
        while (x > 0)
        {
            ++length;
            digits[length] = (int)(x % k);
            x /= k;
        }

        for (int i = 0, j = length; i < j; i++, j--)
        {
            if (digits[i] != digits[j])
                return false;
        }
        return true;
    }
}