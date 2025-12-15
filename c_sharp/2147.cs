public class Solution
{
    private const int MOD = 1_000_000_007;
    public int NumberOfWays(string corridor)
    {
        long ans = 1;

        int n = corridor.Length;
        int seats = 0;

        int previousPairLast = -1;

        for (int i = 0; i < n; i++)
        {
            char curChar = corridor[i];

            if (curChar == 'S')
            {
                seats++;

                if (seats == 2)
                {
                    previousPairLast = i;
                    seats = 0;
                }
                else if (seats == 1 && previousPairLast != -1)
                {
                    ans *= i - previousPairLast;
                    ans %= MOD;
                }
            }
        }

        if (seats == 1 || previousPairLast == -1)
            return 0;

        return (int)ans;
    }
}

public class Solution2
{
    private const int MOD = 1_000_000_007;
    public int NumberOfWays(string corridor)
    {
        int zero = 0, one = 0, two = 1;

        foreach (var c in corridor)
        {
            if (c == 'S')
            {
                zero = one;
                one = two;
                two = zero;
            }
            else
            {
                two = (two + zero) % MOD;
            }
        }

        return zero;
    }
}