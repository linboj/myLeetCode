public class Solution
{
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        HashSet<string> wordSet = new(wordList);
        if (!wordSet.Contains(endWord)) return 0;

        HashSet<string> visited = new();
        Queue<string> queue = new();
        
        queue.Enqueue(beginWord);

        int currentPass = 0;
        while (queue.Count > 0)
        {
            currentPass++;
            int loopN = queue.Count;
            while (loopN > 0)
            {
                string currentWord = queue.Dequeue();
                var charArray = currentWord.ToCharArray();
                for (int i = 0; i < charArray.Length; i++)
                {
                    char orignalChar = charArray[i];
                    for (char c = 'a'; c <= 'z'; c++)
                    {
                        if (c == orignalChar) continue;
                        charArray[i] = c;
                        string transformWord = new string(charArray);

                        if (transformWord == endWord) return currentPass + 1;

                        if (wordSet.Contains(transformWord) && !visited.Contains(transformWord))
                        {
                            visited.Add(transformWord);
                            queue.Enqueue(transformWord);
                        }
                    }
                    charArray[i] = orignalChar;
                }
                loopN--;
            }
        }
        return 0;
    }
}