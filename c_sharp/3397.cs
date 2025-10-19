public class Solution
{
    public int MaxDistinctElements(int[] nums, int k)
    {
        int prev = int.MinValue;
        int ans = 0;
        Array.Sort(nums);

        foreach (var num in nums)
        {
            int opt = Math.Min(Math.Max(prev + 1, num - k), num + k);
            if (opt > prev)
            {
                ans++;
                prev = opt;
            }
        }
        return ans;
    }
}