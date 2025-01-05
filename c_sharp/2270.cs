public class Solution {
    public int WaysToSplitArray(int[] nums) {
        long rightSum = 0;
        foreach (var num in nums)
        {
            rightSum += num;
        }

        long leftSum = 0;
        int count = 0;
        for (int i = 0; i < nums.Length -1; i++)
        {
            leftSum += nums[i];
            rightSum -= nums[i];
            if (leftSum >= rightSum){
                count++;
            }
        }
        return count;
    }
}