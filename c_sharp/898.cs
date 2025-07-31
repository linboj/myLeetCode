public class Solution
{
    public int SubarrayBitwiseORs(int[] arr)
    {
        HashSet<int> ans = new();
        HashSet<int> current = new();
        current.Add(0);

        foreach (var x in arr)
        {
            HashSet<int> next = new();
            foreach (var y in current)
                next.Add(x | y);
            next.Add(x);
            current = next;
            foreach (var val in current)
                ans.Add(val);
        }
        return ans.Count;
    }
}