public class Solution
{

    class Tire
    {
        public string Serial { get; set; } = "";
        public Dictionary<string, Tire> Children { get; } = new();
    }

    public IList<IList<string>> DeleteDuplicateFolder(IList<IList<string>> paths)
    {
        Tire root = new();

        foreach (var path in paths)
        {
            Tire current = root;
            foreach (var node in path)
            {
                if (!current.Children.ContainsKey(node))
                {
                    current.Children[node] = new Tire();
                }
                current = current.Children[node];
            }
        }

        Dictionary<string, int> freq = new();
        Construct(root, freq);
        List<IList<string>> ans = new();
        List<string> pathStack = new();
        Opt(root, freq, pathStack, ans);
        return ans;
    }

    private void Construct(Tire node, Dictionary<string, int> freq)
    {
        if (node.Children.Count == 0)
            return;

        List<string> childrenSerial = new();

        foreach (var (key, tire) in node.Children)
        {
            Construct(tire, freq);
            childrenSerial.Add($"{key}({tire.Serial})");
        }
        childrenSerial.Sort();
        node.Serial = string.Join("", childrenSerial);
        if (!freq.ContainsKey(node.Serial))
            freq[node.Serial] = 0;
        freq[node.Serial]++;
    }

    private void Opt(Tire node, Dictionary<string, int> freq, List<string> path, List<IList<string>> ans)
    {
        if (freq.TryGetValue(node.Serial, out int count) && count > 1)
            return;

        if (path.Count > 0)
            ans.Add(new List<string>(path));

        foreach (var (key, tire) in node.Children)
        {
            path.Add(key);
            Opt(tire, freq, path, ans);
            path.RemoveAt(path.Count - 1);
        }
    }
}