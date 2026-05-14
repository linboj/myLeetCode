public class Solution
{
    public bool IsGood(int[] nums)
    {
        int n = nums.Length;

        int[] cnts = new int[n];

        foreach (var num in nums)
        {
            if (num < 1 || num >= n)
                return false;

            if (num < n - 1 && cnts[num] > 0)
                return false;

            if (num == n - 1 && cnts[num] > 1)
                return false;

            cnts[num]++;
        }

        return true;
    }
}