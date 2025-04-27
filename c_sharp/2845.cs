public class Solution
{
    public long CountInterestingSubarrays(IList<int> nums, int modulo, int k)
    {
        int n = nums.Count;
        Dictionary<int, int> cnts = new();
        cnts[0] = 1;
        long ans = 0;
        int prefix = 0;

        for (int i = 0; i < n; i++)
        {
            if (nums[i] % modulo == k)
                prefix++;

            int matchedIdx = (prefix - k + modulo) % modulo;

            if (cnts.ContainsKey(matchedIdx))
                ans += cnts[(prefix - k + modulo) % modulo];

            int belongedIdx = prefix % modulo;
            if (cnts.ContainsKey(belongedIdx))
                cnts[belongedIdx]++;
            else
                cnts[belongedIdx] = 1;
        }

        return ans;
    }
}