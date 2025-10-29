public class Solution
{
    public int SmallestNumber(int n)
    {
        int ans = 1;
        while (ans < n)
            ans = ans * 2 + 1;

        return ans;
    }
}