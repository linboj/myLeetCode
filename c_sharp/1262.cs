public class Solution
{
    public int MaxSumDivThree(int[] nums)
    {
        int[] prev = [0, int.MinValue, int.MinValue];

        foreach (var num in nums)
        {
            int[] cur = new int[3];
            for (int i = 0; i < 3; i++)
            {
                int idx = (i + num % 3) % 3;
                cur[idx] = Math.Max(prev[idx], prev[i] + num);
            }
            prev = cur;
        }
        return prev[0];
    }
}