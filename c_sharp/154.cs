public class Solution
{
    public int FindMin(int[] nums)
    {
        int l = 0, r = nums.Length - 1;

        while (l < r)
        {
            int mid = (l + r) / 2;

            if (nums[mid] < nums[r])
                r = mid;
            else if (nums[mid] > nums[r])
                l = mid + 1;
            else
                r--;
        }

        return nums[l];
    }
}