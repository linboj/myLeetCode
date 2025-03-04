public class Solution {
    public int[] PivotArray(int[] nums, int pivot) {
        int n = nums.Length;
        int[] ans = new int[n];
        int lessIdx = 0, greaterIdx = n - 1;

        for (int l = 0, r = n-1 ; l < n; l++, r--){
            if (nums[l] < pivot) {
                ans[lessIdx++] = nums[l];
            }
            if (nums[r] > pivot) {
                ans[greaterIdx--] = nums[r];
            }
        }

        while (lessIdx <= greaterIdx) {
            ans[lessIdx++] = pivot;
        }
        return ans;
    }
}