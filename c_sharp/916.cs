public class Solution {
    public IList<string> WordSubsets(string[] words1, string[] words2) {
        List<string> result = new List<string>();
        var charMaxCount = Count("");

        foreach (var word in words2)
        {
            var currentCount = Count(word);
            for (int i = 0; i < 26; i++)
            {
                charMaxCount[i] = Math.Max(charMaxCount[i], currentCount[i]);
            }
        }

        foreach (var word in words1)
        {
            var currentCount = Count(word);
            result.Add(word);
            for (int i = 0; i < 26; i++)
            {
                if (currentCount[i] < charMaxCount[i]){
                    result.RemoveAt(result.Count - 1);
                    break;
                }
            }
        }
        return result;
    }

    private int[] Count(string word){
        int[] charCount = new int[26];
        foreach (var c in word)
        {
            charCount[c-'a'] += 1;
        }
        return charCount;
    }
}