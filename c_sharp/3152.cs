public class Solution
{
    public bool[] IsArraySpecial(int[] nums, int[][] queries)
    {
        bool[] ans = new bool[queries.Length];
        int[] prefixs = new int[nums.Length];

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i - 1] % 2 == nums[i] % 2)
            {
                prefixs[i] = prefixs[i - 1] + 1;
            }
            else
            {
                prefixs[i] = prefixs[i - 1];
            }
        }

        for (int idx = 0; idx < queries.Length; idx++)
        {
            var query = queries[idx];
            ans[idx] = (prefixs[query[0]] - prefixs[query[1]]) == 0;
        }
        return ans;
    }
}