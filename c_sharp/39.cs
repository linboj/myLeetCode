public class Solution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        List<IList<int>> result = new();
        List<int> current = new();
        Solve(candidates, target, 0, current, result);
        return result;
    }

    private void Solve(int[] candidates, int target, int index, List<int> current, List<IList<int>> result)
    {
        if (target == 0)
        {
            result.Add(new List<int>(current));
            return;
        }
        for (int i = index; i < candidates.Length; i++)
        {
            if (candidates[i] <= target)
            {
                current.Add(candidates[i]);
                Solve(candidates, target - candidates[i], i, current, result);
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}