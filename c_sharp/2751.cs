public class Solution
{
    public IList<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions)
    {
        int n = positions.Length;

        int[] indics = new int[n];
        List<int> ans = new();
        Stack<int> stack = new();

        for (int i = 0; i < n; i++)
        {
            indics[i] = i;
        }

        Array.Sort(indics, (l, r) => positions[l].CompareTo(positions[r]));

        foreach (var idx in indics)
        {
            if (directions[idx] == 'R')
            {
                stack.Push(idx);
            }
            else
            {
                while (stack.Count > 0 && healths[idx] > 0)
                {
                    int topIdx = stack.Pop();

                    if (healths[idx] > healths[topIdx])
                    {
                        healths[idx]--;
                        healths[topIdx] = 0;
                    }
                    else if (healths[idx] < healths[topIdx])
                    {
                        healths[idx] = 0;
                        healths[topIdx]--;
                        stack.Push(topIdx);
                    }
                    else
                    {
                        healths[idx] = 0;
                        healths[topIdx] = 0;
                    }
                }
            }
        }

        foreach (var health in healths)
        {
            if (health > 0)
                ans.Add(health);
        }

        return ans;
    }
}