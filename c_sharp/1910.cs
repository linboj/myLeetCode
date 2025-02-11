using System.Text;

public class Solution
{
    // stack
    public string RemoveOccurrences(string s, string part)
    {
        Stack<char> stack = new();
        int nS = s.Length, nPart = part.Length;
        foreach (var c in s)
        {
            stack.Push(c);

            if (stack.Count >= nPart && checkMatch(stack, part))
            {
                for (int i = 0; i < nPart; i++)
                {
                    stack.Pop();
                }
            }
        }
        StringBuilder result = new StringBuilder();
        foreach (var item in stack.ToArray().Reverse())
        {
            result.Append(item);
        }
        return result.ToString();
    }

    private bool checkMatch(Stack<char> stack, string part)
    {
        Stack<char> tmp = new(stack.ToArray().Reverse());
        for (int i = part.Length - 1; i >= 0; i--)
        {
            if (tmp.Count == 0 || tmp.Peek() != part[i]) return false;
            tmp.Pop();
        }
        return true;
    }
}

public class Solution2
{
    // KMP algorithm
    public string RemoveOccurrences(string s, string part)
    {
        var lps = computeLongestPrefixSuffix(part);
        Stack<char> stack = new();
        int[] patternIndexes = new int[s.Length + 1];
        int patternIndex = 0;
        for (int strIndex = 0; strIndex < s.Length; strIndex++)
        {
            char c = s[strIndex];
            stack.Push(c);

            if (c == part[patternIndex])
            {
                int stackSize = stack.Count;
                patternIndexes[stackSize] = ++patternIndex;
                if (patternIndex == part.Length)
                {
                    for (int i = 0; i < part.Length; i++)
                    {
                        stack.Pop();
                    }
                    stackSize = stack.Count;
                    patternIndex = stackSize > 0 ? patternIndexes[stackSize] : 0;
                }
            }
            else
            {
                if (patternIndex != 0)
                {
                    strIndex--;
                    patternIndex = lps[patternIndex - 1];
                    stack.Pop();
                }
                else
                {
                    patternIndexes[stack.Count] = 0;
                }
            }
        }
        StringBuilder result = new StringBuilder();
        foreach (var item in stack.ToArray().Reverse())
        {
            result.Append(item);
        }
        return result.ToString();
    }

    private int[] computeLongestPrefixSuffix(string part)
    {
        int[] lps = new int[part.Length];
        int prefixLength = 0;
        for (int current = 1; current < part.Length;)
        {
            if (part[current] == part[prefixLength])
            {
                lps[current] = ++prefixLength;
                current++;
            }
            else if (prefixLength != 0)
            {
                prefixLength = lps[prefixLength - 1];
            }
            else
            {
                lps[current] = 0;
                current++;
            }
        }
        return lps;
    }
}