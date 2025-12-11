public class Solution
{
    private const int MOD = 1_000_000_007;
    public int CountPermutations(int[] complexity)
    {
        int n = complexity.Length;
        long ans = 1;
        int min = complexity[0];

        for (int i = 1; i < n; i++)
        {
            if (complexity[i] <= min)
                return 0;

            ans = ans * i % MOD;
        }
        return (int)ans;
    }
}