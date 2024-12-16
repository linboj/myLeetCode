public class Solution
{
    public int HIndex(int[] citations) {

        // use sort
        /*
        Array.Sort(citations, (a, b) => b.CompareTo(a));

        for (int i = 0; i < citations.Length; i++)
        {
            if (citations[i] < i+1){
                return i;
            }
        }

        return citations.Length;
        */

        // use count sorting
        int len = citations.Length;
        int[] counts = new int[len+1];
        foreach (var val in citations)
        {
            if (val > len) counts[len]++;
            else counts[val]++;
        }
        int sum = 0;
        for (int i = len; i > -1; i--)
        {
            sum += counts[i];
            if (sum >= i) return i;
        }
        return 0;
    }
}