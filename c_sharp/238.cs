public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        
        int[] right = new int[nums.Length];
        int pv = 1;
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            right[i] = pv;
            pv *= nums[i];
        }

        pv = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            right[i] *= pv;
            pv *= nums[i];            
        }

        return right;
    }
}