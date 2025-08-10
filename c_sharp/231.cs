public class Solution
{
    public bool IsPowerOfTwo(int n)
    {
        if (n <= 0)
            return false;

        int count = 0;
        for (int i = 0; i < 32; i++)
        {
            if (((n >> i) & 1) == 1)
                count++;

            if (count > 1)
                return false;
        }
        return true;
    }
}

public class Solution2
{
    public bool IsPowerOfTwo(int n)
    {
        return n > 0 && (n & (n - 1)) == 0;
    }
}