public class Solution
{
    public bool CanBeValid(string s, string locked)
    {
        if (s.Length % 2 == 1) return false;
        int openCount = 0, unlocked = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (locked[i] == '0')
                unlocked++;
            else if (s[i] == '(')
                openCount++;
            else if (s[i] == ')')
            {
                if (openCount > 0)
                {
                    openCount--;
                }
                else if (unlocked > 0)
                {
                    unlocked--;
                }
                else
                {
                    return false;
                }
            }
        }

        int balance = 0;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (locked[i] == '0')
            {
                balance--;
                unlocked--;
            }
            else if (s[i] == '(')
            {
                balance++;
                openCount--;
            }
            else if (s[i] == ')')
            {
                balance--;
            }
            if (balance > 0) return false;
            if (unlocked == 0 && openCount == 0) break;
        }
        if (openCount > 0) return false;
        return true;
    }
}

public class Solution2
{
    public bool CanBeValid(string s, string locked)
    {
        if (s.Length % 2 == 1) return false;
        int n = s.Length;
        int open = 0, close = 0;

        for (int i = 0; i < n; i++)
        {
            if (locked[i] == '1' && s[i] == ')') close++;
            if (locked[n - 1 - i] == '1' && s[n - 1 - i] == '(') open++;
            if (open > (i+1)/2 || close > (i+1)/2) return false;
        }
        return true;
    }
}