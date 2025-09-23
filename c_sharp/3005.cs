public class Solution
{
    public int MaxFrequencyElements(int[] nums)
    {
        int ans = 0;
        int maxCnts = 1;
        int[] cnts = new int[101];

        foreach (var num in nums)
        {
            cnts[num]++;
            if (cnts[num] > maxCnts)
            {
                ans = cnts[num];
                maxCnts = cnts[num];
            }
            else if (cnts[num] == maxCnts)
                ans += cnts[num];
        }
        return ans;
    }
}