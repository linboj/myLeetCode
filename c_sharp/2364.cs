public class Solution
{
    public long CountBadPairs(int[] nums)
    {
        long n = nums.Length;
        Dictionary<long, long> map = new();
        long badPairs = 0;
        for (int i = 0; i < n; i++)
        {
            long diff = nums[i] - i;
            long goodPairs = map.GetValueOrDefault(diff);
            badPairs += i - goodPairs;
            map[diff] = goodPairs + 1;
        }
        return badPairs;
    }
}