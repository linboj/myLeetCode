public class Solution
{
    public int FindClosest(int x, int y, int z)
    {
        int dx = Math.Abs(x - z);
        int dy = Math.Abs(y - z);
        if (dx < dy)
            return 1;
        else if (dx > dy)
            return 2;
        else
            return 0;
    }
}