public class Solution
{
    public int MaxWalls(int[] robots, int[] distance, int[] walls)
    {
        int n = robots.Length;
        int[][] robotDist = new int[n][];
        for (int i = 0; i < n; i++)
        {
            robotDist[i] = new int[] { robots[i], distance[i] };
        }

        Array.Sort(robotDist, (a, b) => a[0].CompareTo(b[0]));
        Array.Sort(walls);

        int m = walls.Length;
        int leftPtr = 0, rightPtr = 0, curPtr = 0, robotPtr = 0;

        int prevL = 0, prevR = 0, prevNum = 0;
        int subL = 0, subR = 0;

        for (int i = 0; i < n; i++)
        {
            int robotPos = robotDist[i][0];
            int dist = robotDist[i][1];

            while (rightPtr < m && walls[rightPtr] <= robotPos)
            {
                rightPtr++;
            }
            int pos1 = rightPtr;

            while (curPtr < m && walls[curPtr] < robotPos)
            {
                curPtr++;
            }
            int pos2 = curPtr;

            int leftBound = robotPos - dist;
            if (i > 0)
            {
                leftBound = Math.Max(leftBound, robotDist[i - 1][0] + 1);
            }

            while (leftPtr < m && walls[leftPtr] < leftBound)
            {
                leftPtr++;
            }
            int lPos = leftPtr;
            int curL = pos1 - lPos;

            int rightBound = robotPos + dist;
            if (i < n - 1)
            {
                rightBound = Math.Min(rightBound, robotDist[i + 1][0] - 1);
            }

            while (rightPtr < m && walls[rightPtr] <= rightBound)
            {
                rightPtr++;
            }
            int rPos = rightPtr;
            int curR = rPos - pos2;

            int curNum = 0;
            if (i > 0)
            {
                while (robotPtr < m && walls[robotPtr] < robotDist[i - 1][0])
                {
                    robotPtr++;
                }

                int pos3 = robotPtr;
                curNum = pos1 - pos3;
            }

            if (i == 0)
            {
                subL = curL;
                subR = curR;
            }
            else
            {
                int newSubL = Math.Max(subL + curL, subR - prevR + Math.Min(curL + prevR, curNum));
                int newSubR = Math.Max(subL + curR, subR + curR);

                subL = newSubL;
                subR = newSubR;
            }

            prevL = curL;
            prevR = curR;
            prevNum = curNum;
        }

        return Math.Max(subL, subR);
    }
}