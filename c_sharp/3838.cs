using System.Text;

public class Solution
{
    public string MapWordWeights(string[] words, int[] weights)
    {
        int n = words.Length;
        StringBuilder sb = new(n);

        foreach (var word in words)
        {
            int sum = 0;
            foreach (var c in word)
            {
                sum += weights[c - 'a'];
            }

            sum %= 26;
            sb.Append((char)(25 - sum + 'a'));
        }

        return sb.ToString();
    }
}