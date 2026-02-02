public class Solution
{
    public int MinimumCost(int[] nums)
    {
        int min1 = int.MaxValue;
        int min2 = int.MaxValue;

        for (int i = 1; i < nums.Length; i++)
        {
            int num = nums[i];
            if (num < min1)
            {
                min2 = min1;
                min1 = num;
            }
            else if (num < min2)
            {
                min2 = num;
            }
        }
        return nums[0] + min1 + min2;
    }
}