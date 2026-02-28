public class Solution
{
    public int MinOperations(string s, int k)
    {
        int n = s.Length;
        int ones = 0;

        foreach (var c in s)
        {
            ones += c - '0';
        }

        int zeros = n - ones;

        if (zeros == 0) return 0;

        if (n == k) return ((n == zeros ? 1 : 0) << 1) - 1;

        int _base = n - k;

        int odd = Math.Max((zeros + k - 1) / k, (ones + _base - 1) / _base);
        odd += ~odd & 1;

        int even = Math.Max((zeros + k - 1) / k, (zeros + _base - 1) / _base);
        even += even & 1;

        int ans = int.MaxValue;

        if ((k & 1) == (zeros & 1))
            ans = Math.Min(ans, odd);

        if ((~zeros & 1) == 1)
            ans = Math.Min(ans, even);

        return ans == int.MaxValue ? -1 : ans;
    }
}