public class Solution {
    public bool CanConstruct(string ransomNote, string magazine) {
        int[] magazineCount = new int[26];
        foreach (var ch in magazine)
        {
            magazineCount[ch - 'a'] += 1;
        }

        foreach (var ch in ransomNote)
        {
            if (magazineCount[ch - 'a'] == 0) return false;
            magazineCount[ch - 'a'] -= 1;
        }

        return true;
    }
}