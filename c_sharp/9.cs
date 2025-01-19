public class Solution
{
    public bool IsPalindrome(int x)
    {
        if (x < 0) return false;
        int nLength = (int)Math.Log10(x);
        int maxBase = (int)Math.Pow(10, nLength);
        int minBase = 1;

        for (int i = 0; i <= nLength / 2; i++)
        {
            int maxN = x / maxBase % 10;
            int minN = x / minBase % 10;

            if (maxN != minN) return false;
            maxBase /= 10;
            minBase *= 10;
        }
        return true;
    }
}

public class Solution2
{
    public bool IsPalindrome(int x)
    {
        if (x < 0) return false;
        int original = x;
        int curr = 0;
        
        while (x!=0){
            int tmp = x % 10;
            curr = curr * 10 + tmp;
            x /= 10;
        }

        return curr == original;
    }
}