using System.Text;

public class Solution {
    public string LongestCommonPrefix(string[] strs) {

        /*
        var ans = new StringBuilder(strs[0]);
        foreach (var str in strs[1..])
        {
            if (ans.Length <= 0) break;
            int min = Math.Min(str.Length, ans.Length);
            if (ans.Length > min) ans.Remove(min, ans.Length - min );
            for (int i = 0; i < min; i++)
            {
                if (str[i] != ans[i]){
                    ans.Clear();
                    if (i>0) ans.Append(str[..i]);
                    break;
                }
            }
        }

        return ans.ToString();
        */

        if (strs == null || strs.Length == 0) return string.Empty;

        int minLen = strs.Min(s=>s.Length);

        for (int i = 0; i < minLen; i++)
        {
            char curChar = strs[0][i];
            if (!strs.All(s => s[i] == curChar)){
                return strs[0][..i];
            }
        }

        return strs[0][..minLen];

    }
}