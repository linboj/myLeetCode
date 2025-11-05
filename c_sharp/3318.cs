public class Solution
{
    public int[] FindXSum(int[] nums, int k, int x)
    {
        int n = nums.Length;
        int[] ans = new int[n - k + 1];
        Dictionary<int, int> cnts = new();
        for (int i = 0; i < k; i++)
        {
            if (!cnts.ContainsKey(nums[i]))
                cnts[nums[i]] = 0;
            cnts[nums[i]]++;
        }

        for (int i = 0; i < ans.Length; i++)
        {
            if (i > 0)
            {
                cnts[nums[i - 1]]--;
                if (!cnts.ContainsKey(nums[i + k - 1]))
                    cnts[nums[i + k - 1]] = 0;
                cnts[nums[i + k - 1]]++;
            }

            List<int[]> freq = new();
            foreach (var item in cnts)
            {
                freq.Add([item.Key, item.Value]);
            }

            freq.Sort((a, b) => a[1] == b[1] ? b[0].CompareTo(a[0]) : b[1].CompareTo(a[1]));
            int sum = 0;
            for (int j = 0; j < x && j < freq.Count; j++)
            {
                sum += freq[j][0] * freq[j][1];
            }
            ans[i] = sum;
        }
        return ans;
    }
}