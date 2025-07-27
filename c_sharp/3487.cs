public class Solution
{
    public int MaxSum(int[] nums)
    {
        int ans = 0;
        int max = int.MinValue;
        int[] used = new int[101];

        foreach (var num in nums)
        {
            if (num >= 0 && used[num] == 0)
            {
                ans += num;
                used[num]++;
            }
            max = Math.Max(max, num);
        }

        return max < 0 ? max : ans;
    }
}