public class Solution
{
    public int CountSymmetricIntegers(int low, int high)
    {
        int ans = 0;

        for (int i = low; i <= high; i++)
        {
            if (IsOddDigit(i))
            {
                int nDigit = (int)Math.Log10(i);
                i = (int)Math.Pow(10, nDigit + 1) - 1;

                continue;
            }

            if (IsSymmetric(i))
                ans++;
        }

        return ans;
    }

    private bool IsOddDigit(int num)
    {
        int nDigit = (int)Math.Log10(num);
        return nDigit % 2 == 0;
    }

    private bool IsSymmetric(int num)
    {
        int nDigit = (int)Math.Log10(num);
        if (nDigit % 2 == 0) return false;

        int nDigitHalf = (nDigit + 1) / 2;
        int suffixSum = 0, prefixSum = 0;
        for (int i = 0; i < nDigitHalf; i++)
        {
            suffixSum += num % 10;
            num /= 10;
        }

        for (int i = 0; i < nDigitHalf; i++)
        {
            prefixSum += num % 10;
            num /= 10;
        }

        return prefixSum == suffixSum;
    }
}