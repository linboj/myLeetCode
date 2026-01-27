public class Solution
{
    public IList<IList<int>> MinimumAbsDifference(int[] arr)
    {
        List<int[]> ans = new();
        Array.Sort(arr);
        int minDiff = int.MaxValue;

        for (int i = 0; i < arr.Length - 1; i++)
        {
            int diff = arr[i + 1] - arr[i];
            if (diff < minDiff)
            {
                ans.Clear();
                minDiff = diff;
                ans.Add([arr[i], arr[i + 1]]);
            }
            else if (diff == minDiff)
            {
                ans.Add([arr[i], arr[i + 1]]);
            }
        }
        return ans.ToArray();
    }
}