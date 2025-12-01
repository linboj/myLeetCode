public class Solution
{
    public int MinSubarray(int[] nums, int p)
    {
        int n = nums.Length;
        int totalSum = 0;
        foreach (var num in nums)
        {
            totalSum = (totalSum + num) % p;
        }

        if (totalSum == 0)
            return 0;

        Dictionary<int, int> mods = new();
        mods.Add(0, -1);

        int curSum = 0;
        int minLen = n;

        for (int i = 0; i < n; i++)
        {
            curSum = (curSum + nums[i]) % p;

            int needed = (curSum - totalSum + p) % p;

            if (mods.ContainsKey(needed))
                minLen = Math.Min(minLen, i - mods[needed]);

            mods[curSum] = i;
        }
        return minLen == n ? -1 : minLen;
    }
}