public class Solution
{
    public int MinMaxDifference(int num)
    {
        string numStr = num.ToString();
        string numStrc = numStr;
        int n = numStr.Length;
        int pos = 0;
        while (pos < n && numStr[pos] == '9')
        {
            pos++;
        }

        if (pos < n)
        {
            numStr = numStrc.Replace(numStr[pos], '9');
        }
        numStrc = numStrc.Replace(numStrc[0], '0');

        return int.Parse(numStr) - int.Parse(numStrc);
    }
}

public class Solution2
{
    public int MinMaxDifference(int num)
    {
        int n = (int)Math.Log10(num) + 1;
        int[] digits = new int[n];
        int idx = n, curr = num;
        for (int i = n - 1; i >= 0; i--)
        {
            digits[i] = curr % 10;
            curr /= 10;

            if (digits[i] != 9)
                idx = i;
        }

        if (idx == n)
            return num;

        int maxV = 0, minV = 0;
        for (int i = 0; i < n; i++)
        {
            maxV *= 10;
            minV *= 10;
            int currMax = digits[i] == digits[idx] ? 9 : digits[i];
            int currMin = digits[i] == digits[0] ? 0 : digits[i];
            maxV += currMax;
            minV += currMin;
        }
        return maxV - minV;
    }
}