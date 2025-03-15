public class Solution
{
    public int MinCapability(int[] nums, int k)
    {
        int low = 1, high = 0;
        int n = nums.Length;

        foreach (var num in nums)
        {
            high = Math.Max(high, num);
        }

        while (low < high){
            int mid = (low + high) / 2;
            int robbed = 0;

            for (int i = 0; i < n; i++)
            {
                if (nums[i] <= mid){
                    robbed++;
                    i++;
                }
            }
            if (robbed >= k){
                high = mid;
            }else{
                low = mid + 1;
            }
        }
        return low;
    }
}