public class Solution
{
    public int FindFinalValue(int[] nums, int original)
    {
        HashSet<int> numsSet = new();

        foreach (int num in nums)
        {
            if (num % original == 0)
                numsSet.Add(num);
        }

        while (numsSet.Contains(original))
        {
            original *= 2;
        }

        return original;
    }
}