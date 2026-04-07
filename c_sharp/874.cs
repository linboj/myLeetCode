public class Solution
{
    private const int HASH_M = 60016;
    private readonly int[][] DIRECTIONS = [[0, 1], [1, 0], [0, -1], [-1, 0]];
    public int RobotSim(int[] commands, int[][] obstacles)
    {
        HashSet<long> hasObstacles = new();

        foreach (var obstacle in obstacles)
        {
            hasObstacles.Add(obstacle[0] + obstacle[1] * HASH_M);
        }

        int x = 0, y = 0;
        int curDir = 0;
        int ans = 0;

        foreach (var command in commands)
        {
            if (command == -1)
            {
                curDir = (curDir + 1) % 4;
                continue;
            }

            if (command == -2)
            {
                curDir = (curDir + 3) % 4;
                continue;
            }

            int[] direction = DIRECTIONS[curDir];
            for (int i = 0; i < command; i++)
            {
                int nextX = x + direction[0];
                int nextY = y + direction[1];

                long hash = nextX + nextY * HASH_M;
                if (hasObstacles.Contains(hash))
                    break;

                x = nextX;
                y = nextY;
            }

            ans = Math.Max(ans, x * x + y * y);
        }

        return ans;
    }
}