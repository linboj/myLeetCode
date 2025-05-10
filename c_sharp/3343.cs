public class Solution
{
    private const int MOD = 1000000007;

    public int CountBalancedPermutations(string num)
    {
        int n = num.Length;
        int[] counts = new int[10];
        int totalSum = 0;
        foreach (var c in num)
        {
            int digit = c - '0';
            counts[digit]++;
            totalSum += digit;
        }
        if (totalSum % 2 == 1)
            return 0;

        int target = totalSum / 2;
        int maxOdd = (n + 1) / 2;
        long[][] combination = new long[maxOdd + 1][];
        long[][] dp = new long[maxOdd + 1][];

        for (int i = 0; i <= maxOdd; i++)
        {
            combination[i] = new long[maxOdd + 1];
            combination[i][i] = combination[i][0] = 1;
            for (int j = 1; j < i; j++)
            {
                combination[i][j] = (combination[i - 1][j] + combination[i - 1][j - 1]) % MOD;
            }
            dp[i] = new long[target + 1];
        }

        dp[0][0] = 1;
        int nCurDigit = 0, currentSum = 0;
        for (int i = 0; i <= 9; i++)
        {
            nCurDigit += counts[i];
            currentSum += counts[i] * i;
            for (int nOdd = Math.Min(nCurDigit, maxOdd); nOdd >= Math.Max(0, nCurDigit - (n - maxOdd)); nOdd--)
            {
                int nEven = nCurDigit - nOdd;
                for (int curr = Math.Min(currentSum, target); curr >= Math.Max(0, currentSum - target); curr--)
                {
                    long ans = 0;
                    for (int j = Math.Max(0, counts[i] - nEven); j <= Math.Min(counts[i], nOdd) && i * j <= curr; j++)
                    {
                        int prevOdd = nOdd - j;
                        int prevSum = curr - i * j;

                        if (prevOdd >= 0 && prevOdd <= maxOdd && prevSum >= 0 && prevSum <= target)
                        {
                            long ways = combination[nOdd][j] * combination[nEven][counts[i] - j] % MOD;
                            ans = (ans + ways * dp[prevOdd][prevSum] % MOD) % MOD;
                        }
                    }
                    dp[nOdd][curr] = ans % MOD;
                }
            }
        }

        return (int)dp[maxOdd][target];
    }
}