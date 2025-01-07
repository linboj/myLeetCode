public class Solution
{
    public IList<IList<int>> Combine(int n, int k)
    {
        List<IList<int>> ans = new();
        Solve(n, k, ans, new List<int>(), 1);
        return ans;

    }

    private void Solve(int n, int k, List<IList<int>> ans, List<int> tmp, int start)
    {
        if (tmp.Count == k)
        {
            ans.Add(new List<int>(tmp));
            return;
        }
        if (start > n) return;
        for (int i = start; i <= n; i++)
        {
            tmp.Add(i);
            Solve(n, k, ans, tmp, i + 1);
            tmp.RemoveAt(tmp.Count - 1);
        }
    }
}