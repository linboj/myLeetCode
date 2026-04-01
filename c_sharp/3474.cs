public class Solution
{
    public string GenerateString(string str1, string str2)
    {
        int n = str1.Length, m = str2.Length;

        char[] ans = new char[n + m - 1];
        int[] _fixed = new int[n + m - 1];

        Array.Fill(ans, 'a');
        for (int i = 0; i < n; i++)
        {
            if (str1[i] == 'T')
            {
                for (int j = i; j < i + m; j++)
                {
                    if (_fixed[j] == 1 && ans[j] != str2[j - i])
                        return "";
                    else
                    {
                        ans[j] = str2[j - i];
                        _fixed[j] = 1;
                    }
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (str1[i] == 'F')
            {
                bool flag = false;
                int idx = -1;
                for (int j = i + m - 1; j >= i; j--)
                {
                    if (str2[j - i] != ans[j])
                        flag = true;

                    if (idx == -1 && _fixed[j] == 0)
                        idx = j;
                }

                if (flag)
                    continue;
                else if (idx != -1)
                    ans[idx] = 'b';
                else
                    return "";
            }
        }

        return new string(ans);
    }
}