public class Solution {
    public int MaximumCandies(int[] candies, long k) {
        int minCandies = 1, maxCandies = 0;
        foreach (var candy in candies)
        {
            maxCandies = Math.Max(maxCandies, candy);
        }
        int ans = 0;
        while (minCandies <= maxCandies){
            int mid = (minCandies + maxCandies) / 2;
            if (canDistribute(candies, k, mid)){
                ans = Math.Max(ans, mid);
                minCandies = mid + 1;
            }else {
                maxCandies = mid - 1;
            }
        }
        return ans;
    }

    private bool canDistribute(int[] candies, long k, int candiesPerChild){
        long count = 0;
        foreach (var candy in candies)
        {
            count += candy / candiesPerChild;
        }
        return count >= k;
    }
}