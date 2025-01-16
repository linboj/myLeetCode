public class Solution
{
    public int FindMin(int[] nums)
    {
        int left = 0, right = nums.Length - 1;
        int min = int.MaxValue;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (nums[left] <= nums[right])
            {
                min = Math.Min(nums[left], min);
                break;
            }

            if (nums[left] <= nums[mid])
            {
                min = Math.Min(nums[left], min);
                left = mid + 1;
            }
            else
            {
                min = Math.Min(nums[mid], min);
                right = mid - 1;
            }
        }
        return min;

    }
}