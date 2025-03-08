public class Solution
{
    public int MinimumRecolors(string blocks, int k)
    {
        int n = blocks.Length;
        int minOp = int.MaxValue;
        int whiteBlock = 0;
        for (int i = 0; i < k; i++)
        {
            if (blocks[i] == 'W') whiteBlock++;
        }
        minOp = Math.Min(minOp, whiteBlock);
        for (int i = k; i < n; i++)
        {
            if (blocks[i] == 'W') whiteBlock++;
            if (blocks[i - k] == 'W') whiteBlock--;
            minOp = Math.Min(minOp, whiteBlock);
        }
        return minOp;
    }
}