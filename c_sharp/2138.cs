public class Solution
{
    public string[] DivideString(string s, int k, char fill)
    {
        List<string> ans = new();
        int n = s.Length;
        int current = 0;

        while (current < n)
        {
            int end = Math.Min(current + k, n);
            ans.Add(s.Substring(current, end - current));
            current += k;
        }

        string last = ans[ans.Count - 1];
        if (last.Length < k)
        {
            last += new string(fill, k - last.Length);
            ans[ans.Count - 1] = last;
        }

        return ans.ToArray();
    }
}

public class Solution2
{
    public string[] DivideString(string s, int k, char fill)
    {
        int n = s.Length;
        string[] ans = new string[(n - 1) / k + 1];
        int count = 0;
        char[] word = new char[k];

        for (int i = 0; i < n; i++)
        {
            word[count++] = s[i];

            if (count == k)
            {
                ans[i / k] = new string(word);
                count = 0;
            }
        }

        if (count > 0 && count < k)
        {
            for (int i = count; i < k; i++)
            {
                word[i] = fill;
            }
            ans[^1] = new string(word);
        }

        return ans;
    }
}