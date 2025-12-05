public class Solution
{
    public int CountPartitions(int[] nums)
    {
        int sum = 0;

        foreach (var num in nums)
        {
            sum += num;
        }

        return sum % 2 == 1 ? 0 : nums.Length - 1;
    }
}