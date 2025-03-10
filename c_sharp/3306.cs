public class Solution
{
    private HashSet<char> vowels = new() { 'a', 'e', 'i', 'o', 'u' };
    public long CountOfSubstrings(string word, int k)
    {
        long result = 0;
        int start1 = 0, start2 = 0;
        int lastA = -1, lastE = -1, lastI = -1, lastO = -1, lastU = -1;
        int consonantCount = 0, prevConsonant1 = 0, prevConsonant2 = 0;
        for (int end = 0; end < word.Length; end++)
        {
            char newLetter = word[end];
            if (isVowel(newLetter))
            {
                switch (newLetter)
                {
                    case 'a': lastA = end; break;
                    case 'e': lastE = end; break;
                    case 'i': lastI = end; break;
                    case 'o': lastO = end; break;
                    case 'u': lastU = end; break;
                }
            }
            else
                consonantCount++;

            var extraConsonants = consonantCount - k;

            while (start1 <= end && prevConsonant1 < extraConsonants)
            {
                char startLetter = word[start1];
                if (!isVowel(startLetter))
                    prevConsonant1++;
                start1++;
            }

            while (start2 <= end && prevConsonant2 <= extraConsonants)
            {
                char startLetter = word[start2];
                if (!isVowel(startLetter))
                    prevConsonant2++;
                start2++;
            }

            if (lastA == -1 || lastE == -1 || lastI == -1 || lastO == -1 || lastU == -1) continue;
            var vowelThreshold = Math.Min(lastA, Math.Min(lastE, Math.Min(lastI, Math.Min(lastO, lastU)))) + 1;
            var validLeft = Math.Min(start2, vowelThreshold);
            if (validLeft > start1)
                result += validLeft - start1;
        }

        return result;
    }

    private bool isVowel(char c)
    {
        return vowels.Contains(c);
    }
}