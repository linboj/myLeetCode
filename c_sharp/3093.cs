public class Solution
{
    public int[] StringIndices(string[] wordsContainer, string[] wordsQuery)
    {
        Trie trie = new();

        for (int i = 0; i < wordsContainer.Length; i++)
        {
            var chars = wordsContainer[i].ToCharArray();
            Array.Reverse(chars);
            trie.Insert(new string(chars), i);
        }

        int n = wordsQuery.Length;
        int[] ans = new int[n];

        for (int i = 0; i < n; i++)
        {
            var chars = wordsQuery[i].ToCharArray();
            Array.Reverse(chars);
            ans[i] = trie.Query(new string(chars));
        }

        return ans;
    }

    class TrieNode
    {
        public TrieNode[] children = new TrieNode[26];
        public int minLen = int.MaxValue;
        public int idx = int.MaxValue;

        public TrieNode() { }
    }

    class Trie
    {
        public TrieNode root = new TrieNode();

        public void Insert(string s, int idx)
        {
            int n = s.Length;
            TrieNode node = root;
            if (n < node.minLen)
            {
                node.minLen = n;
                node.idx = idx;
            }

            foreach (var c in s)
            {
                int p = c - 'a';
                if (node.children[p] == null)
                {
                    node.children[p] = new TrieNode();
                }

                node = node.children[p];

                if (n < node.minLen)
                {
                    node.minLen = n;
                    node.idx = idx;
                }
            }
        }

        public int Query(string s)
        {
            TrieNode node = root;

            foreach (var c in s)
            {
                int p = c - 'a';
                if (node.children[p] != null)
                {
                    node = node.children[p];
                }
                else
                {
                    break;
                }
            }

            return node.idx;
        }
    }
}