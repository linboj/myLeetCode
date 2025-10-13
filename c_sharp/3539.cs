public class Solution
{
    private const int MOD = 1_000_000_007;
    public int MagicalSum(int m, int k, int[] nums)
    {
        int n = nums.Length;
        long[][] powerTable = new long[n][];
        for (int i = 0; i < n; i++)
        {
            powerTable[i] = new long[m + 1];
            powerTable[i][0] = 1;
            for (int p = 1; p <= m; p++)
            {
                powerTable[i][p] = powerTable[i][p - 1] * nums[i] % MOD;
            }
        }

        long[][] combinations = new long[m + 1][];
        for (int r = 0; r <= m; r++)
        {
            combinations[r] = new long[m + 1];
            combinations[r][0] = 1;
            for (int c = 1; c <= r; c++)
            {
                combinations[r][c] = (combinations[r - 1][c - 1] + combinations[r - 1][c]) % MOD;
            }
        }

        long[,,] currentState = new long[m + 1, m + 1, k + 1];
        currentState[m, 0, 0] = 1;

        for (int i = 0; i < n; i++)
        {
            long[,,] nextState = new long[m + 1, m + 1, k + 1];
            long[] currentPowerTable = powerTable[i];

            for (int r = 0; r <= m; r++)
            {
                for (int c = 0; c <= m; c++)
                {
                    for (int onesCount = 0; onesCount <= k; onesCount++)
                    {
                        long currentValue = currentState[r, c, onesCount];
                        if (currentValue == 0)
                            continue;

                        for (int used = 0; used <= r; used++)
                        {
                            int total = used + c;
                            int bit = total & 1;
                            int newOnesCount = onesCount + bit;
                            if (newOnesCount > k)
                                continue;

                            int newC = total >> 1;
                            int newR = r - used;

                            long addValue = (currentValue * combinations[r][used]) % MOD;
                            addValue = (addValue * currentPowerTable[used]) % MOD;

                            nextState[newR, newC, newOnesCount] =
                                (nextState[newR, newC, newOnesCount] + addValue) % MOD;
                        }
                    }
                }
            }

            currentState = nextState;
        }

        long ans = 0;
        for (int Carry = 0; Carry <= m; Carry++)
        {
            int extraOnes = CountBits(Carry);
            int neededOnes = k - extraOnes;

            if (neededOnes >= 0 && neededOnes <= k)
            {
                ans = (ans + currentState[0, Carry, neededOnes]) % MOD;
            }
        }

        return (int)ans;
    }

    private int CountBits(int num)
    {
        int count = 0;
        while (num != 0)
        {
            num &= (num - 1);
            count++;
        }
        return count;
    }

}