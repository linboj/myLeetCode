public class Solution
{
    public int ClimbStairs(int n)
    {
        int[] memo = new int[n + 1];
        memo[0] = 1;
        memo[1] = 1;
        if (n < 2) return memo[n];
        memo[n] = Solve(n - 1, memo) + Solve(n - 2, memo);
        return memo[n];
    }

    private int Solve(int n, int[] memo)
    {
        if (memo[n] != 0) return memo[n];
        memo[n] = Solve(n - 1, memo) + Solve(n - 2, memo);
        return memo[n];
    }
}

public class Solution2
{
    public int ClimbStairs(int n)
    {
        int[] memo = new int[n + 1];
        memo[0] = 1;
        memo[1] = 1;
        for (int i = 2; i <= n; i++)
        {
            memo[i] = memo[i - 1] + memo[i - 2];
        }
        return memo[n];
    }
}