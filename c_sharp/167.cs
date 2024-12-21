public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int left = 0, right = numbers.Length - 1, diff = target - numbers[left] - numbers[right];

        while (diff != 0) {
            if ( diff > 0 ) {
                left++;
                diff += numbers[left-1] - numbers[left];
            }

            if ( diff < 0 ) {
                right-- ;
                diff += numbers[right+1] - numbers[right];
            }
        }

        return [left+1, right+1];
    }
}