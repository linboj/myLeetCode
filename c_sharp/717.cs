public class Solution
{
    public bool IsOneBitCharacter(int[] bits)
    {
        int n = bits.Length;
        int cur = 0;

        while (cur < n - 1)
        {
            if (bits[cur] == 1)
                cur += 2;
            else
                cur++;
        }
        return cur != n;
    }
}