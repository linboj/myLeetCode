public class Solution
{
    public int MaxFrequency(int[] nums, int k, int numOperations)
    {
        Array.Sort(nums);
        int n = nums.Length;

        int left = 0, right = 0;
        int sumCount = 0;
        int ans = 0;
        int left2 = 0;
        int sumCount2 = 0;
        int count = 0;
        int prev = int.MinValue;

        foreach (int num in nums)
        {
            if (num == prev)
            {
                count++;
            }
            else
            {
                prev = num;
                count = 1;
            }

            while (nums[left] < num - k)
            {
                sumCount--;
                left++;
            }

            while (right < n && nums[right] <= num + k)
            {
                sumCount++;
                right++;
            }

            ans = Math.Max(ans, count + Math.Min(sumCount - count, numOperations));

            sumCount2++;
            while (nums[left2] < num - 2L * k)
            {
                sumCount2--;
                left2++;
            }

            ans = Math.Max(ans, Math.Min(sumCount2, numOperations));
        }
        return ans;
    }
}