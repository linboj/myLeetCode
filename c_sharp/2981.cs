public class Solution
{
    public int MaximumLength(string s)
    {
        Dictionary<string, int> count = new Dictionary<string, int>();
        for (int start = 0; start < s.Length; start++)
        {
            for (int end = start; end < s.Length; end++)
            {
                if (s[start] != s[end]) break;
                {
                    string substring = s.Substring(start, end - start + 1);
                    if (count.ContainsKey(substring)){
                        count[substring]++;
                    }else{
                        count[substring] = 1;
                    }
                }
            }
        }

        int ans = -1;
        foreach (var key in count.Keys)
        {
            if (count[key] >= 3 && key.Length > ans){
                ans = key.Length;
            }            
        }
        return ans;
    }
}