public class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        int i = 0, j = 0, count = 1;
        while (i < nums.Length - 1)
        {
            while (i < nums.Length - 1 && nums[i] != nums[i + 1])
            {
                nums[count++] = nums[++i];
            }
            j = i + 1;
            while (j < nums.Length && nums[i] == nums[j]) j++;
            if (j >= nums.Length) break;
            nums[count++] = nums[j];
            i = j;
        }
        return count;
    }
}