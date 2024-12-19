public class Solution {
    public int LengthOfLastWord(string s) {
        s = s.TrimEnd();
        var words = s.Split(' ');
        return words[^1].Length;
    }
}