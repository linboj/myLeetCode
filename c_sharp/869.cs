public class Solution
{
    public bool ReorderedPowerOf2(int n)
    {
        int[] nCount = countDigitCount(n);

        for (int i = 0; i < 31; i++)
        {
            if (isMatch(nCount, countDigitCount(1 << i))) return true;
        }
        return false;
    }

    private int[] countDigitCount(int n)
    {
        int[] digitCount = new int[10];
        while (n > 0)
        {
            digitCount[n % 10]++;
            n /= 10;
        }
        return digitCount;
    }

    private bool isMatch(int[] a, int[] b)
    {
        for (int i = 0; i < 10; i++)
        {
            if (a[i] != b[i]) return false;
        }
        return true;
    }
}