public class Solution
{
    public void SortColors(int[] nums)
    {
        int n = nums.Length;
        int left = 0, right = n - 1;

        int ordered = 0;

        while (left <= right)
        {
            if (nums[left] == 0)
            {
                nums[ordered++] = 0;
                left++;
            }
            else if (nums[left] == 2)
            {
                nums[left] = nums[right];
                nums[right--] = 2;
            }
            else
            {
                left++;
            }
        }

        while (left > ordered)
        {
            nums[ordered++] = 1;
        }
    }
}