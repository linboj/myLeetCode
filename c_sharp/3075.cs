public class Solution
{
    public long MaximumHappinessSum(int[] happiness, int k)
    {
        long ans = 0;
        Array.Sort(happiness, (a, b) => b.CompareTo(a));

        for (int i = 0; i < k; i++)
        {
            ans += Math.Max(0, happiness[i] - i);
        }

        return ans;
    }
}