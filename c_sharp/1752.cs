public class Solution
{
    public bool Check(int[] nums)
    {
        int n = nums.Length;
        bool isMismatchedOnce = false;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > nums[(i + 1) % n])
            {
                if (isMismatchedOnce)
                    return false;
                else
                    isMismatchedOnce = true;
            }
        }
        return true;
    }
}