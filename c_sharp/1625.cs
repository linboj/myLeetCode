public class Solution
{
    public string FindLexSmallestString(string s, int a, int b)
    {
        int n = s.Length;
        string ans = s;
        s += s;
        int g = GCD(b, n);

        for (int i = 0; i < n; i += g)
        {
            char[] t = s.Substring(i, n).ToCharArray();
            Add(t, n, a, 1);
            if (b % 2 != 0)
                Add(t, n, a, 0);

            string str = new(t);
            if (str.CompareTo(ans) < 0)
                ans = str;
        }
        return ans;
    }

    private void Add(char[] t, int n, int a, int start)
    {
        int minVal = 10;
        int times = 0;
        int digit = t[start] - '0';
        for (int i = 0; i < 10; i++)
        {
            int added = (digit + i * a) % 10;
            if (added < minVal)
            {
                minVal = added;
                times = i;
            }
        }

        for (int i = start; i < n; i += 2)
        {
            t[i] = (char)('0' + ((t[i] - '0' + times * a) % 10));
        }
    }

    private int GCD(int num1, int num2)
    {
        while (num2 != 0)
        {
            int temp = num1 % num2;
            num1 = num2;
            num2 = temp;
        }
        return num1;
    }
}