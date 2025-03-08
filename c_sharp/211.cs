public class WordDictionary
{

    public TrieNode root;
    public WordDictionary()
    {
        root = new TrieNode();
    }

    public void AddWord(string word)
    {
        var current = root;
        foreach (var c in word)
        {
            int idx = c - 'a';
            if (current.Nexts[idx] == null)
                current.Nexts[idx] = new TrieNode();
            current = current.Nexts[idx];
        }
        current.IsWordEnd = true;
    }

    public bool Search(string word)
    {
        return Search(word, root, 0);
    }

    public bool Search(string word, TrieNode current, int index)
    {
        int curIdx = index;
        while (curIdx < word.Length)
        {
            if (word[curIdx] == '.') break;

            current = current.Nexts[word[curIdx] - 'a'];
            if (current == null) return false;
            curIdx++;
        }

        if (curIdx >= word.Length)
            return current.IsWordEnd;

        for (int i = 0; i < 26; i++)
        {
            if (current.Nexts[i] != null && Search(word, current.Nexts[i], curIdx + 1))
                return true;
        }
        return false;
    }
}

public class TrieNode
{
    public TrieNode[] Nexts;
    public bool IsWordEnd;

    public TrieNode()
    {
        Nexts = new TrieNode[26];
        IsWordEnd = false;
    }
}

/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */