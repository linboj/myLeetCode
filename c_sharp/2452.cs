public class Solution
{
    class TriNode
    {
        public TriNode[] children = new TriNode[26];
        public bool isEnd = false;
    }

    TriNode root = new TriNode();

    void Insert(string word)
    {
        var node = root;
        foreach (var c in word)
        {
            int idx = c - 'a';
            if (node.children[idx] == null)
            {
                node.children[idx] = new TriNode();
            }
            node = node.children[idx];
        }
        node.isEnd = true;
    }

    bool Dfs(string word, int i, TriNode node, int cnt)
    {
        if (cnt > 2 || node == null)
            return false;

        if (i == word.Length)
            return true;

        int idx = word[i] - 'a';

        if (node.children[idx] != null)
        {
            if (Dfs(word, i + 1, node.children[idx], cnt))
                return true;
        }

        if (cnt < 2)
        {
            for (int c = 0; c < 26; c++)
            {
                if (c == idx)
                    continue;

                if (node.children[c] != null)
                {
                    if (Dfs(word, i + 1, node.children[c], cnt + 1))
                        return true;
                }
            }
        }
        return false;
    }

    public IList<string> TwoEditWords(string[] queries, string[] dictionary)
    {
        foreach (var word in dictionary)
        {
            Insert(word);
        }

        List<string> ans = new();

        foreach (var q in queries)
        {
            if (Dfs(q, 0, root, 0))
                ans.Add(q);
        }

        return ans;
    }
}