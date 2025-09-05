public class Solution
{
    public int MakeTheIntegerZero(int num1, int num2)
    {
        int i = 1;
        while (true)
        {
            long x = num1 - (long)num2 * i;
            if (x < i)
                return -1;
            if (i >= BitCount(x))
            {
                return i;
            }
            i++;
        }
    }

    private int BitCount(long x)
    {
        int count = 0;
        while (x != 0)
        {
            count++;
            x &= (x - 1);
        }
        return count;
    }
}