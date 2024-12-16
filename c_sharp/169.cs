public class Solution
{
    public int MajorityElement(int[] nums)
    {
        // Boyer-Moore Voting Algorithm
        int currentValue = nums[0];
        int count = 0;

        foreach (int num in nums)
        {
            if (count == 0)
            {
                currentValue = num;
                count = 1;
            }
            else if (num == currentValue) count++;
            else count--;
        }

        return currentValue;
    }
}