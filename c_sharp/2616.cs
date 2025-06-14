public class Solution
{
    public int MinimizeMax(int[] nums, int p)
    {
        int n = nums.Length;
        Array.Sort(nums);
        int left = 0, right = nums[n - 1] - nums[0];
        while (left < right)
        {
            int mid = (left + right) / 2;
            int count = countValidPairs(nums, mid);
            if (count >= p)
                right = mid;
            else
                left = mid + 1;
        }
        return left;
    }

    private int countValidPairs(int[] nums, int threshold)
    {
        int n = nums.Length;
        int count = 0;
        for (int i = 0; i < n - 1; i++)
        {
            if (nums[i + 1] - nums[i] <= threshold)
            {
                count++;
                i++;
            }
        }
        return count;
    }
}