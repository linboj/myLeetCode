public class Solution {
    public int MinZeroArray(int[] nums, int[][] queries) {
        int n = nums.Length, sum = 0, ans = 0;
        int[] diffArray = new int[n + 1];
        for (int idx = 0; idx < n; idx++)
        {
            while (sum + diffArray[idx] < nums[idx]){
                ans++;
                if (ans > queries.Length) return -1;
                int left = queries[ans-1][0], right = queries[ans-1][1], val = queries[ans-1][2];
                if (right >= idx){
                    diffArray[Math.Max(left, idx)] += val;
                    diffArray[right+1] -= val;
                }
            }
            sum += diffArray[idx];
        }
        return ans;
    }
}