public class Solution
{
    public int[] SumZero(int n)
    {
        int[] ans = new int[n];
        int current = 0;
        for (int i = 0; i < n / 2; i++)
        {
            int val = n / 2 - i;
            ans[current] = -val;
            ans[n - 1 - current] = val;
            current++;
        }
        return ans;
    }
}