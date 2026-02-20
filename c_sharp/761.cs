public class Solution
{
    public string MakeLargestSpecial(string s)
    {
        int cnt = 0;
        int j = 0;
        List<string> list = new();

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '1')
                cnt++;
            else
                cnt--;

            if (cnt == 0)
            {
                list.Add("1" + MakeLargestSpecial(s.Substring(j + 1, i - j - 1)) + "0");
                j = i + 1;
            }
        }

        list.Sort((a, b) => string.Compare(b, a, StringComparison.Ordinal));

        return string.Join("", list);
    }
}