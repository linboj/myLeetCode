public class Solution
{
    public int FurthestDistanceFromOrigin(string moves)
    {
        int any = 0, l = 0, r = 0;

        foreach (var c in moves)
        {
            switch (c)
            {
                case 'R':
                    r++;
                    break;
                case 'L':
                    l++;
                    break;
                default:
                    any++;
                    break;
            }
        }

        return Math.Max(Math.Abs(l + any - r), Math.Abs(r + any - l));
    }
}