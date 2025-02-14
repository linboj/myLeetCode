public class Solution {
    public int Trap(int[] height) {
        int l = 0, r = height.Length - 1;
        int lMax = height[l], rMax = height[r];
        int ans = 0;

        while (l < r) {
            if (height[l] <= height[r]){
                lMax = Math.Max(height[l], lMax);
                ans += lMax - height[l];
                l++;
            }else{
                rMax = Math.Max(rMax, height[r]);
                ans += rMax - height[r];
                r--;
            }
        }
        return ans;
    }
}