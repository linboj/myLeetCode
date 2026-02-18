using System.Numerics;

public class Solution
{
    public IList<string> ReadBinaryWatch(int turnedOn)
    {
        IList<string> ans = new List<string>();

        for (int h = 0; h < 12; h++)
        {
            for (int m = 0; m < 60; m++)
            {
                if (h < 12 && m < 60 &&
                BitOperations.PopCount((nuint)h) + BitOperations.PopCount((nuint)m) == turnedOn)
                {
                    ans.Add(h + ":" + (m < 10 ? "0" : "") + m);
                }
            }
        }

        return ans;
    }
}

public class Solution2
{
    public IList<string> ReadBinaryWatch(int turnedOn)
    {
        IList<string> ans = new List<string>();

        for (int h = 0; h < 12; h++)
        {
            for (int m = 0; m < 60; m++)
            {

                if (h < 12 && m < 60 &&
                BitCount(h) + BitCount(m) == turnedOn)
                {
                    ans.Add(h + ":" + (m < 10 ? "0" : "") + m);
                }
            }
        }

        return ans;
    }

    // Parallel Bit Count
    private static int BitCount(int i)
    {
        // 每 2 個 bit 當成一組，計算每組裡面有幾個 1
        i -= (i >> 1) & 0x55555555;                         // 01010101 01010101 01010101 01010101                         
        // 把2-bit count 合併成 4-bit count
        i = (i & 0x33333333) + ((i >> 2) & 0x33333333);     // 00110011 00110011 00110011 00110011
        // 把4-bit count 合併成 8 bit count
        i = (i + (i >> 4)) & 0x0f0f0f0f;                    // 00001111 00001111 00001111 00001111
        // 把8-bit count 合併成 16-bit count 
        i += i >> 8;
        // 把16-bit count 合併成 32-bit count
        i += i >> 16;
        // 32-bit最多32個1 用6-bit即可
        return i & 0x3f;
    }
}