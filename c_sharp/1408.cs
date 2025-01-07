using System.Runtime.CompilerServices;

public class Solution
{

    class TrieNode
    {
        public int frequency;
        public Dictionary<char, TrieNode> childNodes;

        public TrieNode()
        {
            frequency = 0;
            childNodes = new();
        }
    }



    public IList<string> StringMatching(string[] words)
    {
        List<string> result = new();
        TrieNode root = new TrieNode();

        foreach (var word in words)
        {
            for (int i = 0; i < word.Length; i++)
            {
                insertWord(root, word.Substring(i));
            }
        }

        foreach (var word in words)
        {
            if (isSubString(root, word))
            {
                result.Add(word);
            }
        }

        return result;
    }

    private void insertWord(TrieNode root, string word)
    {
        TrieNode current = root;
        foreach (var c in word)
        {
            if (!current.childNodes.ContainsKey(c))
            {
                current.childNodes[c] = new TrieNode();
            }
            current = current.childNodes[c];
            current.frequency++;
        }
    }

    private bool isSubString(TrieNode root, string word)
    {
        TrieNode current = root;
        foreach (var c in word)
        {
            current = current.childNodes[c];
        }

        return current.frequency > 1;
    }
}

public class Solution2
{

    public IList<string> StringMatching(string[] words)
    {
        List<string> result = new();
        for (int i = 0; i < words.Length; i++)
        {
            var lps = computeLPSArray(words[i]);
            for (int j = 0; j < words.Length; j++)
            {
                if (i == j) continue;
                if (words[i].Length == 0 || words[j].Length == 0 ) continue;
                if (IsSubstringOf(words[i], words[j], lps))
                {
                    result.Add(words[i]);
                    words[i] = "";
                }
            }
        }

        return result;
    }

    private int[] computeLPSArray(string sub)
    {
        int[] lps = new int[sub.Length];

        int currentIdx = 1, len = 0;

        while (currentIdx < sub.Length)
        {
            if (sub[currentIdx] == sub[len])
            {
                len++;
                lps[currentIdx] = len;
                currentIdx++;
            }
            else
            {
                if (len > 0)
                {
                    len = lps[len - 1];
                }
                else
                {
                    currentIdx++;
                }
            }
        }

        return lps;
    }

    private bool IsSubstringOf(string sub, string main, int[] lps)
    {
        int mainIdx = 0, subIdx = 0;
        while (mainIdx < main.Length)
        {
            if (main[mainIdx] == sub[subIdx])
            {
                mainIdx++;
                subIdx++;
                if (subIdx == sub.Length) return true;
            }
            else
            {
                if (subIdx > 0)
                {
                    subIdx = lps[subIdx - 1];
                }
                else
                {
                    mainIdx++;
                }
            }
        }
        return false;
    }
}