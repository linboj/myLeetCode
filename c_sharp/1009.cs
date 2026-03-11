public class Solution
{
    public int BitwiseComplement(int n)
    {
        if (n == 0)
            return 1;

        int cnt = 0, tmp = n;

        while (tmp > 0)
        {
            cnt++;
            tmp >>= 1;
        }
        int num = (int)Math.Pow(2, cnt) - 1;
        return num - n;
    }
}