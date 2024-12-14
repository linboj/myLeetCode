public class Solution
{
    public int RemoveElement(int[] nums, int val)
    {
        int start = 0, end = nums.Length - 1;

        while (start <= end)
        {
            while (start < nums.Length && nums[start] != val) start++;
            while (end > 0 && nums[end] == val) end--;
            if (start < end && start < nums.Length && end > 0)
            {
                (nums[start], nums[end]) = (nums[end], nums[start]);
            }
            else
            {
                break;
            }
        }
        return start;
    }
}