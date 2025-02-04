public class Solution {
    public int MaxAscendingSum(int[] nums) {
        int prev = nums[0], sum= nums[0], max = nums[0];
        for (int i = 1; i < nums.Length; i++) {
            if (prev < nums[i]){
                sum += nums[i];
            }else{
                max = Math.Max(max, sum);
                sum = nums[i];
            }
            prev = nums[i];
        }
        return Math.Max(max, sum);
    }
}