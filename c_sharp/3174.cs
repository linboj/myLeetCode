public class Solution {
    public string ClearDigits(string s) {
        StringBuilder result = new StringBuilder();
        foreach (var c in s)
        {
            if (char.IsDigit(c)){
                if (result.Length > 0){
                    result.Remove(result.Length - 1, 1);
                }
            }else{
                result.Append(c);
            }
        }
        return result.ToString();
    }
}