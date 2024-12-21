public class Solution {
    public int MaxArea(int[] height) {
        int left = 0, right = height.Length - 1;
        int maxArea = 0;

        while (left < right) {
            int area = Math.Min(height[left], height[right])*(right - left);
            maxArea = Math.Max(maxArea, area);
            
            if (height[left] > height[right]) {
                right--;
            }else{
                left++;
            }
            
        }

        return maxArea;
    }
}