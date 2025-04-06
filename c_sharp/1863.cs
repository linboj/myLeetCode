public class Solution
{
    // Bit Manipulation
    public int SubsetXORSum(int[] nums)
    {
        int result = 0;

        foreach (var num in nums)
        {
            result |= num;
        }

        return result << (nums.Length - 1);
    }
}

public class Solution2
{
    // Backtracking
    public int SubsetXORSum(int[] nums)
    {
        return XORSum(nums, 0, 0);
    }

    private int XORSum(int[] nums, int idx, int currentXOR)
    {
        if (idx == nums.Length) return currentXOR;

        var include = XORSum(nums, idx + 1, currentXOR ^ nums[idx]);
        var exclude = XORSum(nums, idx + 1, currentXOR);

        return include + exclude;
    }
}