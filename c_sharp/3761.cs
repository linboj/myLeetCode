public class Solution
{
    public int MinMirrorPairDistance(int[] nums)
    {
        int n = nums.Length;
        int ans = int.MaxValue;
        Dictionary<int, int> map = new();

        for (int i = 0; i < n; i++)
        {
            int num = nums[i];
            if (map.ContainsKey(num))
            {
                ans = Math.Min(ans, i - map[num]);
            }
            int rev = Rev(num);
            map[rev] = i;
        }
        return ans == int.MaxValue ? -1 : ans; ;
    }

    private int Rev(int num)
    {
        int result = 0;

        while (num > 0)
        {
            result *= 10;
            result += num % 10;
            num /= 10;
        }

        return result;
    }
}