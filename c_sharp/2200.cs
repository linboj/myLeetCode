public class Solution
{
    public IList<int> FindKDistantIndices(int[] nums, int key, int k)
    {
        int n = nums.Length;
        List<int> ans = new();
        int right = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] == key)
            {
                int left = Math.Max(right, i - k);
                right = Math.Min(k + i, n - 1) + 1;
                for (int j = left; j <= i + k && j < n; j++)
                {
                    ans.Add(j);
                }
                if (right >= n)
                    break;
            }
        }
        return ans;
    }
}