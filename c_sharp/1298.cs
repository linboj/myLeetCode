public class Solution
{
    public int MaxCandies(int[] status, int[] candies, int[][] keys, int[][] containedBoxes, int[] initialBoxes)
    {
        int n = status.Length;
        int ans = 0;
        Queue<int> queue = new();
        bool[] hasBox = new bool[n];
        bool[] canOpen = new bool[n];
        bool[] used = new bool[n];

        for (int i = 0; i < n; i++)
        {
            canOpen[i] = status[i] == 1;
        }

        foreach (var box in initialBoxes)
        {
            hasBox[box] = true;
            if (canOpen[box])
            {
                queue.Enqueue(box);
                used[box] = true;
                ans += candies[box];
            }
        }

        while (queue.Count > 0)
        {
            int currentBox = queue.Dequeue();
            foreach (var box in keys[currentBox])
            {
                canOpen[box] = true;
                if (!used[box] && hasBox[box])
                {
                    queue.Enqueue(box);
                    used[box] = true;
                    ans += candies[box];
                }
            }

            foreach (var box in containedBoxes[currentBox])
            {
                hasBox[box] = true;
                if (!used[box] && canOpen[box])
                {
                    queue.Enqueue(box);
                    used[box] = true;
                    ans += candies[box];
                }
            }
        }
        return ans;

    }
}