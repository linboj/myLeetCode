public class Solution
{
    public int[] SmallestSubarrays(int[] nums)
    {
        int n = nums.Length;
        int[] ans = new int[n];
        int[] pos = new int[31];
        Array.Fill(pos, -1);

        for (int left = n - 1; left >= 0; left--)
        {
            int current = nums[left];
            int right = left;

            for (int bit = 0; bit < 31; bit++)
            {
                if ((current & 1) == 1)
                {
                    pos[bit] = left;
                }
                right = Math.Max(right, pos[bit]);
                current >>= 1;
            }

            ans[left] = right - left + 1;
        }
        return ans;
    }
}