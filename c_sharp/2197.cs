public class Solution
{
    public IList<int> ReplaceNonCoprimes(int[] nums)
    {
        List<int> ans = new();
        int idx = -1;
        foreach (var num in nums)
        {
            int current = num;
            while (idx >= 0 && GCD(ans[idx], current) > 1)
            {
                current = ans[idx] * (current / GCD(ans[idx], current));
                ans.RemoveAt(idx--);
            }
            ans.Add(current);
            idx++;
        }
        return ans;
    }

    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            int tmp = b;
            b = a % b;
            a = tmp;
        }
        return a;
    }
}