public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        int[] ans = [-1, -1];
        if (nums.Length == 0) return ans;
        int left = 0, right = nums.Length - 1;
        // find first
        while (left <= right){
            int mid = (left + right) / 2;

            if (nums[mid] == target){
                ans[0] = mid;
                right = mid - 1; 
            }else if (nums[mid] < target){
                left = mid + 1;
            }else{
                right = mid - 1;
            }
        }
        left = 0; 
        right = nums.Length - 1;
        // find last
        while (left <= right){
            int mid = (left + right) / 2;

            if (nums[mid] == target){
                ans[1] = mid;
                left = mid + 1; 
            }else if (nums[mid] < target){
                left = mid + 1;
            }else{
                right = mid - 1;
            }
        }
        return ans;
    }
}