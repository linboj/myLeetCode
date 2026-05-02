public class Solution
{
    public int RotatedDigits(int n)
    {
        int ans = 0;

        for (int i = 1; i <= n; i++)
        {
            if (IsGoodInteger(i))
                ans++;
        }
        return ans;
    }

    private bool IsGoodInteger(int x)
    {
        bool isValid = false;
        while (x > 0)
        {
            int m = x % 10;
            switch (m)
            {
                case 2:
                case 5:
                case 6:
                case 9:
                    isValid = true;
                    break;
                case 0:
                case 1:
                case 8:
                    break;
                default:
                    return false;
            }
            x /= 10;
        }
        return isValid;
    }
}