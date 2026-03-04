public class Solution
{
    public char FindKthBit(int n, int k)
    {
        int invertCnt = 0;
        int len = (1 << n) - 1;

        while (k > 1)
        {
            if (k == len / 2 + 1)
                return (invertCnt & 1) == 1 ? '0' : '1';

            if (k > len / 2)
            {
                k = len + 1 - k;
                invertCnt++;
            }

            len /= 2;
        }

        return (invertCnt & 1) == 1 ? '1' : '0';
    }
}