public class Solution
{
    public bool CanJump(int[] nums)
    {
        /*
        int maxReach = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (i > maxReach) return false;

            maxReach = Math.Max(maxReach, i + nums[i]);

            if (maxReach >= nums.Length - 1) return true;

        }

        return false;
        */

        int lastIndex = nums.Length - 1;
        for (int i = lastIndex; i >= 0; i--){
            if ( i + nums[i] >= lastIndex){
                if (i == 0) return true;
                lastIndex = i;
            }
        }
        return false;
    }
}