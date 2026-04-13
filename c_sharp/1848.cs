public class Solution
{
    public int GetMinDistance(int[] nums, int target, int start)
    {
        int n = nums.Length;
        int l = start, r = start;

        while (r < n || l >= 0)
        {
            if (r < n && nums[r] == target)
                return r - start;

            if (l >= 0 && nums[l] == target)
                return start - l;

            r++;
            l--;
        }

        return -1;
    }
}