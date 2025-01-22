public class Solution {
    public int Rob(int[] nums) {
        int prev = 0;
        int curr = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            int temp = Math.Max(prev + nums[i], curr);
            prev = curr;
            curr = temp;
        }
        return curr;
    }
}