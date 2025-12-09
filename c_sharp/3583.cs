public class Solution
{
    private const int MOD = 1_000_000_007;
    public int SpecialTriplets(int[] nums)
    {
        int n = nums.Length;
        long ans = 0;
        Dictionary<int, int> allCnts = new();
        Dictionary<int, int> leftCnts = new();

        foreach (var num in nums)
        {
            if (!allCnts.ContainsKey(num))
                allCnts[num] = 0;
            allCnts[num]++;
        }

        foreach (var num in nums)
        {
            int target = num * 2;
            int leftCnt = leftCnts.GetValueOrDefault(target, 0);

            if (!leftCnts.ContainsKey(num))
                leftCnts[num] = 0;
            leftCnts[num]++;

            int allCnt = allCnts.GetValueOrDefault(target, 0);
            int rightCnt = allCnt - leftCnts.GetValueOrDefault(target, 0);

            ans = (ans + ((long)leftCnt * rightCnt)) % MOD;

        }
        return (int)ans;
    }
}