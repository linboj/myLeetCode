public class Solution {
    public int NumTilePossibilities(string tiles) {
        Dictionary<int, int> counts = new ();
        foreach (var c in tiles)
        {
            int cValue = c - 'A';
            if (!counts.ContainsKey(cValue)) counts[cValue] = 0;
            counts[cValue]++;
        }
        return findSequence(counts);
    }

    private int findSequence(Dictionary<int, int> counts){
        int totalCounts = 0;
        var letters = counts.Keys;
        foreach (var letter in letters)
        {
            if (counts[letter]==0) continue;
            totalCounts++;
            counts[letter]--;
            totalCounts += findSequence(counts);
            counts[letter]++;
        }
        return totalCounts;
    }
}