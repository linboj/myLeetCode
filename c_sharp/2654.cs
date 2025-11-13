public class Solution
{
    public int MinOperations(int[] nums)
    {
        int n = nums.Length;
        int g = 0;
        int ones = 0;

        foreach (var num in nums)
        {
            if (num == 1)
                ones++;

            g = Gcd(g, num);
        }

        if (ones > 0)
            return n - ones;

        if (g > 1)
            return -1;

        int minLen = n;
        for (int i = 0; i < n; i++)
        {
            g = 0;
            for (int j = i; j < n; j++)
            {
                g = Gcd(g, nums[j]);
                if (g == 1)
                {
                    minLen = Math.Min(minLen, j - i + 1);
                    break;
                }
            }
        }
        return minLen + n - 2;

    }

    private int Gcd(int x, int y)
    {
        while (y != 0)
        {
            int temp = y;
            y = x % y;
            x = temp;
        }
        return x;
    }
}
public class Solution
{
    public int MinOperations(int[] nums)
    {
        int n = nums.Length;
        int g = 0;
        int ones = 0;

        foreach (var num in nums)
        {
            if (num == 1)
                ones++;

            g = Gcd(g, num);
        }

        if (ones > 0)
            return n - ones;

        if (g > 1)
            return -1;

        int minLen = n;
        for (int i = 0; i < n; i++)
        {
            g = 0;
            for (int j = i; j < n; j++)
            {
                g = Gcd(g, nums[j]);
                if (g == 1)
                {
                    minLen = Math.Min(minLen, j - i + 1);
                    break;
                }
            }
        }
        return minLen + n - 2;

    }

    private int Gcd(int x, int y)
    {
        while (y != 0)
        {
            int temp = y;
            y = x % y;
            x = temp;
        }
        return x;
    }
}