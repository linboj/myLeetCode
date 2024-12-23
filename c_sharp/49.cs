public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        if (strs == null || strs.Length == 0) {
            return new List<IList<string>>();
        }

        Dictionary<string, List<string>> dict = new ();
        foreach (string str in strs) {
            char[] chars = new char[26];
            foreach (char c in str) {
                chars[c - 'a']++;
            }
            string key = new string(chars);

            if (!dict.ContainsKey(key)) {
                dict.Add(key, new List<string>());
            }
            dict[key].Add(str);
        }
        return new List<IList<string>>(dict.Values);

    }
}