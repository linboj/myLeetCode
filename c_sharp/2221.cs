public class Solution
{
    public int TriangularSum(int[] nums)
    {
        int n = nums.Length;
        List<int> current = new List<int>(nums);
        while (current.Count > 1)
        {
            List<int> newNums = new();
            for (int i = 0; i < current.Count - 1; i++)
            {
                newNums.Add((current[i] + current[i + 1]) % 10);
            }
            current = newNums;
        }
        return current[0];
    }
}

public class Solution2
{
    public int TriangularSum(int[] nums)
    {
        int n = nums.Length;
        for (int i = n; i > 1; i--)
        {
            for (int j = 1; j < i; j++)
            {
                nums[j - 1] = (nums[j - 1] + nums[j]) % 10;
            }
        }
        return nums[0];
    }
}