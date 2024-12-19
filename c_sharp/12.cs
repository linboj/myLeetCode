using System.Text;

public class Solution {
    public string IntToRoman(int num) {
        Dictionary<int, string> map = new ();
        map.Add(1000, "M");
        map.Add(900, "CM");  
        map.Add(500, "D");      
        map.Add(400, "CD");
        map.Add(100, "C");
        map.Add(90, "XC");
        map.Add(50, "L");
        map.Add(40, "XL");
        map.Add(10, "X");
        map.Add(9, "IX");
        map.Add(5, "V");
        map.Add(4, "IV");
        map.Add(1, "I");

        var ans = new StringBuilder();

        foreach (var pair in map)
        {
            while (num >= pair.Key){
                ans.Append(pair.Value);
                num -= pair.Key;
            }
        }

        return ans.ToString();
    }
}