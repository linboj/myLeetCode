public class Solution
{
    public int[] SortByBits(int[] arr)
    {
        Array.Sort(arr, (a, b) =>
        {
            int cntA = Count1Bit(a);
            int cntB = Count1Bit(b);
            return cntA == cntB ? a - b : cntA - cntB;
        });
        return arr;
    }

    private int Count1Bit(int num)
    {
        // Brian Kerninghan's Algorithm
        int cnt = 0;

        while (num > 0)
        {
            cnt++;
            num &= num - 1;
        }

        return cnt;
    }
}

public class Solution2
{
    public int[] SortByBits(int[] arr)
    {
        Array.Sort(arr, (a, b) =>
        {
            int cntA = Count1Bit(a);
            int cntB = Count1Bit(b);
            return cntA == cntB ? a - b : cntA - cntB;
        });
        return arr;
    }

    private int Count1Bit(int num)
    {
        int cnt = 0;

        while (num > 0)
        {
            cnt += num & 1;
            num >>= 1;
        }

        return cnt;
    }
}