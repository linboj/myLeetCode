public class Solution
{
    public int MaxTotalFruits(int[][] fruits, int startPos, int k)
    {
        int n = fruits.Length;
        int left = 0, right = 0;
        int ans = 0, sum = 0;

        while (right < n)
        {
            sum += fruits[right][1];
            while (left <= right && Step(fruits, startPos, left, right) > k)
            {
                sum -= fruits[left][1];
                left++;
            }
            right++;
            ans = Math.Max(ans, sum);
        }
        return ans;
    }

    private int Step(int[][] fruits, int startPos, int left, int right)
    {
        if (startPos <= fruits[left][0])
            return fruits[right][0] - startPos;
        else if (startPos >= fruits[right][0])
            return startPos - fruits[left][0];
        else
            return Math.Min(
                        Math.Abs(startPos - fruits[left][0]),
                        Math.Abs(startPos - fruits[right][0])
                    ) + (fruits[right][0] - fruits[left][0]);
    }
}