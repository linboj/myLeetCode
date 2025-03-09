public class Solution {
    public int NumberOfAlternatingGroups(int[] colors) {
        int n = colors.Length;  
        int slidingWindowLen = 1;
        int lastColor = colors[0];
        int ans = 0;

        for (int i = 0; i < n + 3 - 1; i++) {
            int curIdx = i % n;

            if (colors[curIdx] == lastColor){
                slidingWindowLen = 1;
                lastColor = colors[curIdx];
                continue;
            }

            if (++slidingWindowLen >= 3) ans++;

            lastColor = colors[curIdx];
        }

        return ans;
    }
}