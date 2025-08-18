public class Solution
{
    private const double EPS = 1e-6;
    public bool JudgePoint24(int[] cards)
    {
        List<double> nums = new();
        foreach (var card in cards)
            nums.Add(card);
        return dfs(nums);
    }

    private bool dfs(List<double> nums)
    {
        int n = nums.Count;
        if (n == 1)
            return Math.Abs(nums[0] - 24.0) < EPS;

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                double a = nums[i], b = nums[j];
                List<double> next = new();
                for (int k = 0; k < n; k++)
                {
                    if (k != i && k != j)
                        next.Add(nums[k]);
                }

                double[] cand = [a + b, a - b, b - a, a * b];
                foreach (var c in cand)
                {
                    next.Add(c);
                    if (dfs(next))
                        return true;
                    next.RemoveAt(next.Count - 1);
                }

                if (Math.Abs(b) > EPS)  // avoid a / 0
                {
                    next.Add(a / b);
                    if (dfs(next))
                        return true;
                    next.RemoveAt(next.Count - 1);
                }

                if (Math.Abs(a) > EPS)  // avoid b / 0
                {
                    next.Add(b / a);
                    if (dfs(next))
                        return true;
                    next.RemoveAt(next.Count - 1);
                }
            }
        }
        return false;
    }
}