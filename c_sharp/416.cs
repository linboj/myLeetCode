public class Solution
{
    public bool CanPartition(int[] nums)
    {
        int sum = 0;
        foreach (var num in nums)
        {
            sum += num;
        }

        if (sum % 2 != 0) return false;

        int needSum = sum / 2;
        bool[] available = new bool[needSum + 1];
        available[0] = true;

        foreach (var num in nums)
        {
            for (int i = needSum; i >= num; i--)
            {
                available[i] = available[i] || available[i - num];
            }
            if (available[needSum]) return true;
        }

        return available[needSum];
    }
}