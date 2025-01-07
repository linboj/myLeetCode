public class Solution
{
    public IList<IList<int>> Permute(int[] nums)
    {
        List<IList<int>> ans = new();
        Solve(nums, 0, ans);

        return ans;
    }

    private void Solve(int[] nums, int start, IList<IList<int>> ans)
    {
        if (start == nums.Length - 1)
        {
            ans.Add(new List<int>(nums));
            return;
        }
        for (int i = start; i < nums.Length; i++)
        {
            Swap(nums, start, i);
            Solve(nums, start + 1, ans);
            Swap(nums, start, i);
        }
    }

    private void Swap(int[] nums, int i, int j)
    {
        int tmp = nums[i];
        nums[i] = nums[j];
        nums[j] = tmp;
    }

}