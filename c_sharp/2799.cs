public class Solution
{
    public int CountCompleteSubarrays(int[] nums)
    {
        int ans = 0;
        int n = nums.Length, right = 0, currentDistinct = 0;
        Dictionary<int, int> counts = new();
        int distinct = new HashSet<int>(nums).Count;

        for (int left = 0; left < n; left++)
        {
            if (left > 0)
            {
                int prev = nums[left - 1];
                counts[prev]--;
                if (counts[prev] == 0)
                    currentDistinct--;
            }

            while (right < n && currentDistinct < distinct)
            {
                int currentValue = nums[right];
                if (!counts.ContainsKey(currentValue) || counts[currentValue] == 0)
                {
                    counts[currentValue] = 0;
                    currentDistinct++;
                }
                counts[currentValue]++;
                right++;
            }

            if (currentDistinct == distinct)
            {
                ans += n - right + 1;
            }
        }

        return ans;
    }
}