public class Solution
{
    public int LongestCommonPrefix(int[] arr1, int[] arr2)
    {
        Trie t = new Trie();

        foreach (var num in arr1)
        {
            t.Insert(num);
        }

        int ans = 0;

        foreach (var num in arr2)
        {
            ans = Math.Max(ans, t.FindLongestPath(num));
        }

        return ans;
    }

    class TrieNode
    {
        public TrieNode[] children = new TrieNode[10];
    }

    class Trie
    {
        TrieNode root = new TrieNode();

        public void Insert(int num)
        {
            TrieNode node = root;
            var numStr = num.ToString();
            foreach (var c in numStr)
            {
                int idx = c - '0';
                if (node.children[idx] == null)
                {
                    node.children[idx] = new TrieNode();
                }

                node = node.children[idx];
            }
        }

        public int FindLongestPath(int num)
        {
            TrieNode node = root;
            var numStr = num.ToString();
            int level = 0;

            foreach (var c in numStr)
            {
                int idx = c - '0';
                if (node.children[idx] != null)
                {
                    level++;
                    node = node.children[idx];
                }
                else
                {
                    break;
                }
            }

            return level;
        }
    }
}