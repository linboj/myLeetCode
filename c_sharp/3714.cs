public class Solution
{
    public int LongestBalanced(string s)
    {
        int ans = 0;
        ans = Math.Max(FindLongestFor1(s), ans);
        ans = Math.Max(FindLongestForPair(s, 'a', 'b'), ans);
        ans = Math.Max(FindLongestForPair(s, 'a', 'c'), ans);
        ans = Math.Max(FindLongestForPair(s, 'b', 'c'), ans);
        ans = Math.Max(FindLongestForThree(s), ans);

        return ans;
    }

    private int FindLongestFor1(string s)
    {
        int curA = 0, curB = 0, curC = 0;
        int maxA = 0, maxB = 0, maxC = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == 'a')
            {
                curA = (i > 0 && s[i - 1] == 'a') ? curA + 1 : 1;
                maxA = Math.Max(curA, maxA);
            }
            else if (s[i] == 'b')
            {
                curB = (i > 0 && s[i - 1] == 'b') ? curB + 1 : 1;
                maxB = Math.Max(curB, maxB);
            }
            else
            {
                curC = (i > 0 && s[i - 1] == 'c') ? curC + 1 : 1;
                maxC = Math.Max(curC, maxC);
            }

        }
        return Math.Max(maxA, Math.Max(maxB, maxC));
    }

    private int FindLongestForPair(string s, char c1, char c2)
    {
        int n = s.Length, maxLen = 0;
        int[] first = new int[2 * n + 1];
        Array.Fill(first, -2);

        int clearIdx = -1, diff = n;
        first[diff] = clearIdx;

        for (int i = 0; i < n; i++)
        {
            if (s[i] != c1 && s[i] != c2)
            {
                clearIdx = i;
                diff = n;
                first[diff] = clearIdx;
            }
            else
            {
                if (s[i] == c1) diff++;
                else diff--;

                if (first[diff] < clearIdx)
                {
                    first[diff] = i;
                }
                else
                {
                    maxLen = Math.Max(maxLen, i - first[diff]);
                }
            }
        }
        return maxLen;
    }

    private int FindLongestForThree(string s)
    {
        int maxLen = 0;
        Dictionary<(int, int), int> pos = new();
        pos.Add((0, 0), -1);
        int[] cnts = new int[3];

        for (int i = 0; i < s.Length; i++)
        {
            cnts[s[i] - 'a']++;
            var curDiffKey = (cnts[0] - cnts[1], cnts[1] - cnts[2]);

            if (pos.TryGetValue(curDiffKey, out int prev))
            {
                maxLen = Math.Max(maxLen, i - prev);
            }
            else
            {
                pos.Add(curDiffKey, i);
            }
        }

        return maxLen;
    }
}