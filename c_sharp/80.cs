public class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        int k = 2;
        for (int i = 2; i < nums.Length; i++)
        {
            if (nums[i] != nums[k - 2]) nums[k++] = nums[i];
        }
        return Math.Min(k, nums.Length);
    }
}