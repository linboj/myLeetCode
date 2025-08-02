public class Solution
{
    public IList<IList<int>> Generate(int numRows)
    {
        int n = 2;
        List<IList<int>> ans = new();

        ans.Add(new List<int>() { 1 });

        while (n <= numRows)
        {
            List<int> current = new();
            current.Add(1);
            var prev = ans[n - 2];
            for (int i = 1; i < n - 1; i++)
            {
                current.Add(prev[i - 1] + prev[i]);
            }
            current.Add(1);
            n++;
            ans.Add(current);
        }
        return ans;
    }
}