public class Solution
{
    // one pass with sliding window
    public int NumberOfAlternatingGroups(int[] colors, int k)
    {
        int n = colors.Length;
        int ans = 0;
        int slidingWindowLen = 1;
        int lastColor = colors[0];

        for (int i = 0; i < n + k - 1; i++)
        {
            int curIdx = i % n;
            if (colors[curIdx] == lastColor)
            {
                slidingWindowLen = 1;
                lastColor = colors[curIdx];
                continue;
            }

            slidingWindowLen++;

            if (slidingWindowLen >= k)
            {
                ans++;
            }

            lastColor = colors[curIdx];
        }
        return ans;
    }
}

public class Solution2
{
    // two pass with sliding window
    public int NumberOfAlternatingGroups(int[] colors, int k)
    {
        int n = colors.Length;
        int ans = 0;
        int slidingWindowLen = 1;
        int lastColor = colors[0];

        for (int i = 0; i < n; i++)
        {
            if (colors[i] == lastColor)
            {
                slidingWindowLen = 1;
                lastColor = colors[i];
                continue;
            }

            if (++slidingWindowLen >= k)
                ans++;

            lastColor = colors[i];
        }

        for (int i = 0; i < k - 1; i++)
        {
            if (colors[i] == lastColor) break;

            if (++slidingWindowLen >= k)
                ans++;

            lastColor = colors[i];
        }

        return ans;
    }
}