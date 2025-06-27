public class Solution
{
    public string LongestSubsequenceRepeatedK(string s, int k)
    {
        int[] count = new int[26];
        foreach (var ch in s)
        {
            count[ch - 'a']++;
        }
        List<char> candidate = new();
        for (int i = 25; i >= 0; i--)
        {
            if (count[i] >= k)
                candidate.Add((char)(i + 'a'));
        }

        Queue<string> queue = new();
        foreach (var ch in candidate)
        {
            queue.Enqueue(ch.ToString());
        }

        string ans = "";

        while (queue.Count > 0)
        {
            string curr = queue.Dequeue();
            if (curr.Length > ans.Length)
                ans = curr;

            foreach (var ch in candidate)
            {
                string next = curr + ch;
                if (isKRepeatedSubsequence(s, next, k))
                {
                    queue.Enqueue(next);
                }
            }
        }
        return ans;
    }

    private bool isKRepeatedSubsequence(string s, string t, int k)
    {
        int pos = 0, matched = 0;
        int m = t.Length;
        foreach (char ch in s)
        {
            if (ch == t[pos])
            {
                pos++;
                if (pos == m)
                {
                    pos = 0;
                    matched++;
                    if (matched == k)
                        return true;
                }
            }
        }
        return false;
    }
}