public class Solution
{
    public int NumSteps(string s)
    {
        int n = s.Length;
        int carry = 0, ops = 0;

        for (int i = n - 1; i >= 1; i--)
        {
            int digit = s[i] - '0' + carry;

            if (digit % 2 == 0)
            {
                ops++;
            }
            else
            {
                ops += 2;
                carry = 1;
            }
        }

        return ops + carry;
    }
}