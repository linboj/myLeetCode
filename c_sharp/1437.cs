public class Solution
{
    public bool KLengthApart(int[] nums, int k)
    {
        int n = nums.Length;
        int cnt = k;

        foreach (var num in nums)
        {
            if (num == 0)
            {
                cnt++;
                continue;
            }

            if (cnt < k) return false;

            cnt = 0;
        }
        return true;
    }
}