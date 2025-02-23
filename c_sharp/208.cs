public class Trie
{

    public Dictionary<char, Trie> _dict;
    public Trie()
    {
        _dict = new();
    }

    public void Insert(string word)
    {
        var t = _dict;
        foreach (var ch in word)
        {
            if (!t.ContainsKey(ch)) t[ch] = new Trie();
            t = t[ch]._dict;
        }
        t[' '] = new Trie();
    }

    public bool Search(string word)
    {
        var t = _dict;
        foreach (var ch in word)
        {
            if (!t.ContainsKey(ch)) return false;
            t = t[ch]._dict;
        }
        return t.ContainsKey(' ');
    }

    public bool StartsWith(string prefix)
    {
        var t = _dict;
        foreach (var ch in prefix)
        {
            if (!t.ContainsKey(ch)) return false;
            t = t[ch]._dict;
        }
        return true;
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */