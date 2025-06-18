public class Solution
{
    public int[][] DivideArray(int[] nums, int k)
    {
        int n = nums.Length;
        List<int[]> ans = new();

        Array.Sort(nums);
        for (int i = 0; i < n; i += 3)
        {
            if (nums[i + 2] - nums[i] > k)
            {
                return Array.Empty<int[]>();
            }
            ans.Add(new int[] { nums[i], nums[i + 1], nums[i + 2] });
        }
        return ans.ToArray();

    }
}