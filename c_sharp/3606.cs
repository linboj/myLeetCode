using System.Text.RegularExpressions;

public class Solution
{
    private const string codePattern = @"^[A-Za-z0-9_]+$";
    private Dictionary<string, int> categoryMap = new() { { "electronics", 0 }, { "grocery", 1 }, { "pharmacy", 2 }, { "restaurant", 3 } };
    public IList<string> ValidateCoupons(string[] code, string[] businessLine, bool[] isActive)
    {
        int n = code.Length;
        PriorityQueue<string, (int, string)> pq = new(
            Comparer<(int, string)>.Create(
                (a, b) => a.Item1.Equals(b.Item1) ? string.Compare(a.Item2, b.Item2, StringComparison.Ordinal) : a.Item1.CompareTo(b.Item1)
                ));

        for (int i = 0; i < n; i++)
        {
            if (!isActive[i])
                continue;
            if (!Regex.IsMatch(code[i], codePattern))
                continue;
            if (!categoryMap.ContainsKey(businessLine[i]))
                continue;

            pq.Enqueue(code[i], (categoryMap.GetValueOrDefault(businessLine[i], 4), code[i]));
        }

        List<string> ans = new();
        while (pq.Count > 0)
        {
            ans.Add(pq.Dequeue());
        }
        return ans;
    }
}

public class Solution2
{
    private const string codePattern = @"^[A-Za-z0-9_]+$";
    private Dictionary<string, int> categoryMap = new() { { "electronics", 0 }, { "grocery", 1 }, { "pharmacy", 2 }, { "restaurant", 3 } };
    public IList<string> ValidateCoupons(string[] code, string[] businessLine, bool[] isActive)
    {
        int n = code.Length;
        List<(int type, string code)> validItems = new();

        for (int i = 0; i < n; i++)
        {
            if (!isActive[i])
                continue;
            if (!Regex.IsMatch(code[i], codePattern))
                continue;
            if (!categoryMap.ContainsKey(businessLine[i]))
                continue;

            validItems.Add((categoryMap.GetValueOrDefault(businessLine[i], 4), code[i]));
        }

        validItems.Sort(
            (a, b) => a.type.Equals(b.type) ? string.Compare(a.code, b.code, StringComparison.Ordinal) : a.type.CompareTo(b.type));

        List<string> ans = new();
        foreach (var validItem in validItems)
        {
            ans.Add(validItem.code);
        }
        return ans;
    }
}