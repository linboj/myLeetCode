public class Solution
{
    public int CountValidSelections(int[] nums)
    {
        int n = nums.Length;
        int sum = 0;
        foreach (int num in nums)
        {
            sum += num;
        }
        int left = 0, ans = 0;
        foreach (var num in nums)
        {
            if (num == 0)
            {
                if (left == sum)
                    ans += 2;
                else if (Math.Abs(sum - left) <= 1)
                    ans++;
            }
            else
            {
                left += num;
                sum -= num;
            }
        }
        return ans;
    }
}