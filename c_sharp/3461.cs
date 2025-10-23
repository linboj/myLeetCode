public class Solution
{
    public bool HasSameDigits(string s)
    {
        int iter = 0;
        char[] str = s.ToCharArray();
        int n = str.Length;

        while (n - iter != 2)
        {
            for (int i = 0; i < n - iter - 1; i++)
            {
                str[i] = (char)((str[i] - '0' + (str[i + 1] - '0')) % 10 + '0');
            }
            iter++;
        }
        return str[0] == str[1];
    }
}