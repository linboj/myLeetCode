public class Solution
{
    public int MaxFreqSum(string s)
    {
        int[] cnts = new int[26];
        int maxVowl = 0, maxConsonant = 0;

        foreach (var c in s)
        {
            int idx = c - 'a';
            cnts[idx]++;
            if (idx == 0 || idx == 4 || idx == 8 || idx == 14 || idx == 20)
            {
                maxVowl = Math.Max(cnts[idx], maxVowl);
            }
            else
            {
                maxConsonant = Math.Max(maxConsonant, cnts[idx]);
            }
        }
        return maxVowl + maxConsonant;
    }
}