public class Solution
{
    public int MinimumOperations(int[] nums)
    {
        bool[] seen = new bool[100];
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            if (seen[nums[i] - 1])
            {
                return i / 3 + 1;
            }
            seen[nums[i] - 1] = true;
        }

        return 0;
    }
}