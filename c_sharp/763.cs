public class Solution
{
    public IList<int> PartitionLabels(string s)
    {
        int n = s.Length;
        int[] lastIndices = new int[26];
        List<int> result = new();

        for (int i = 0; i < n; i++)
        {
            lastIndices[s[i] - 'a'] = i;
        }

        int size = 0, right = lastIndices[s[0] - 'a'];

        for (int i = 0; i < n; i++)
        {
            right = Math.Max(right, lastIndices[s[i] - 'a']);
            size++;

            if (i == right)
            {
                result.Add(size);
                size = 0;
            }
        }
        return result;
    }
}