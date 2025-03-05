public class Solution
{
    public long ColoredCells(int n)
    {
        long result = 1;

        for (int i = n - 1; i > 0; i--)
        {
            result += 4 * i;
        }
        return result;
    }
}

public class Solution2
{
    public long ColoredCells(int n)
    {
        long result = n - 1;

        result = 1 + 4 * (result + 1) * result / 2;

        return result;
    }
}