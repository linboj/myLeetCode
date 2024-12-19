public class Solution {
    public string ReverseWords(string s) {
        /*
        s = s.Trim();
        var words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse();
        
        return string.Join(" ", words);
        */

        var words = s.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int left= 0, right = words.Length -1;
        while (left < right) {
            (words[left], words[right]) = (words[right].Trim(), words[left].Trim());
            left++;
            right--;
        }
        return string.Join(" ", words);
    }
}