public class Solution
{
    public IList<int> FindSubstring(string s, string[] words)
    {
        int nWord = words.Length, wordLen = words[0].Length;
        int substringLength = wordLen * nWord;
        List<int> result = new();

        if (s.Length == 0 || nWord == 0 || s.Length < substringLength) return result;

        Dictionary<string, int> wordCount = new Dictionary<string, int>();
        foreach (var word in words)
        {
            if (!wordCount.ContainsKey(word)) wordCount[word] = 0;
            wordCount[word]++;
        }

        for (int i = 0; i < wordLen; i++)
        {
            Dictionary<string, int> currentWordCount = new();
            int wordFound = 0;
            int left = i;

            for (int j = i; j <= s.Length - wordLen; j += wordLen)
            {
                string currentWord = s.Substring(j, wordLen);

                if (wordCount.ContainsKey(currentWord))
                {
                    if (!currentWordCount.ContainsKey(currentWord)) currentWordCount[currentWord] = 0;
                    currentWordCount[currentWord]++;
                    wordFound++;

                    while (currentWordCount[currentWord] > wordCount[currentWord]){
                        string leftWord = s.Substring(left, wordLen);
                        currentWordCount[leftWord]--;
                        wordFound--;
                        left += wordLen;
                    }

                    if (wordFound == nWord){
                        result.Add(left);
                        string leftWord = s.Substring(left, wordLen);
                        currentWordCount[leftWord]--;
                        wordFound--;
                        left += wordLen;
                    }
                }
                else
                {
                    currentWordCount.Clear();
                    wordFound = 0;
                    left = j + wordLen;
                }
            }
        }
        return result;
    }
}