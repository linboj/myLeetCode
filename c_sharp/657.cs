public class Solution
{
    public bool JudgeCircle(string moves)
    {
        int dx = 0, dy = 0;

        foreach (var move in moves)
        {
            switch (move)
            {
                case 'U':
                    dy--;
                    break;
                case 'D':
                    dy++;
                    break;
                case 'L':
                    dx--;
                    break;
                case 'R':
                    dx++;
                    break;
                default:
                    break;
            }
        }

        return dx == 0 && dy == 0;
    }
}