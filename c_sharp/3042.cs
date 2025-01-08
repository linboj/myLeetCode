public class Solution
{
    public int CountPrefixSuffixPairs(string[] words)
    {
        int ans = 0;
        for (int i = 0; i < words.Length; i++)
        {
            for (int j = i + 1; j < words.Length; j++)
            {
                if (isPrefixAndSuffix(words[i], words[j]))
                {
                    ans++;
                }
            }
        }
        return ans;
    }

    private bool isPrefixAndSuffix(string str1, string str2)
    {
        if (str1.Length > str2.Length) return false;

        for (int i = 0; i < str1.Length; i++)
        {
            if (str1[i] != str2[i]) return false;
        }

        for (int i = 1; i <= str1.Length; i++)
        {
            if (str1[^i] != str2[^i]) return false;
        }

        return true;
    }
}

public class Solution2
{
    public int CountPrefixSuffixPairs(string[] words)
    {
        int ans = 0;
        for (int i = 0; i < words.Length; i++)
        {
            Trie prefixTrie = new Trie();
            Trie suffixTrie = new Trie();

            prefixTrie.Insert(words[i]);

            var revWord = new string(words[i].Reverse().ToArray());
            suffixTrie.Insert(revWord);

            for (int j = 0; j < i; j++) {
                if (words[j].Length > words[i].Length) continue;

                string prefixWord = words[j];
                string revPrefixWord = new string(prefixWord.Reverse().ToArray());

                if (
                    prefixTrie.StartsWith(prefixWord) &&
                    suffixTrie.StartsWith(revPrefixWord)
                ) {
                    ans++;
                }
            }
        }
        return ans;
    }

    class Node
    {
        private Node[] links = new Node[26];

        public bool Contains(char c)
        {
            return links[c - 'a'] != null;
        }

        public void put(char c, Node node)
        {
            links[c - 'a'] = node;
        }

        public Node next(char c)
        {
            return links[c - 'a'];
        }
    }

    class Trie
    {
        private Node root;

        public Trie()
        {
            root = new Node();
        }

        public void Insert(string word)
        {
            Node node = root;
            foreach (var c in word)
            {
                if (!node.Contains(c))
                {
                    node.put(c, new Node());
                }
                node = node.next(c);
            }
        }

        public bool StartsWith(string prefix)
        {
            Node node = root;
            foreach (var c in prefix)
            {
                if (!node.Contains(c)) return false;

                node = node.next(c);
            }
            return true;
        }
    }

}