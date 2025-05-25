public class Solution
{
    public IList<int> FindWordsContaining(string[] words, char x)
    {
        List<int> ans = new List<int>();

        for (int i = 0; i < words.Length; i++)
        {
            foreach (var c in words[i])
            {
                if (c == x)
                {
                    ans.Add(i);
                    break;
                }
            }
        }

        return ans;
    }
}