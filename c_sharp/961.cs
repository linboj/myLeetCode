public class Solution
{
    public int RepeatedNTimes(int[] nums)
    {
        for (int i = 1; i <= 3; i++)
        {
            for (int k = 0; k < nums.Length - i; k++)
            {
                if (nums[k] == nums[k + i])
                    return nums[k];
            }
        }
        return -1;
    }
}

public class Solution2
{
    public int RepeatedNTimes(int[] nums)
    {
        Dictionary<int, int> seen = new();

        foreach (var num in nums)
        {
            if (seen.ContainsKey(num))
                return num;
            else
                seen[num] = 1;
        }
        return -1;
    }
}