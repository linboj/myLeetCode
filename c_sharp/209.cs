public class Solution
{
    public int MinSubArrayLen(int target, int[] nums)
    {
        int left = 0, right = 0, sum = 0, minLen = int.MaxValue;
        while ( right < nums.Length){
            sum += nums[right];
            right++;
            while (sum >= target){
                minLen = Math.Min(minLen, right - left);
                sum -= nums[left];
                left++;
            }
        }

        return minLen == int.MaxValue ? 0 : minLen;
    }
}