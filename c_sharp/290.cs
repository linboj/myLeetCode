public class Solution
{
    public bool WordPattern(string pattern, string s)
    {
        Dictionary<char, string> dic = new();
        var words = s.Split(" ");

        if (words.Length != pattern.Length) return false;

        for (int i = 0; i < pattern.Length; i++)
        {
            if (dic.TryGetValue(pattern[i], out var mapWord))
            {
                if (mapWord != words[i]) return false;
                continue;
            }
            if (dic.ContainsValue(words[i]))
                return false;
            else
                dic.Add(pattern[i], words[i]);
        }
        return true;
    }
}