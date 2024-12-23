public class Solution {
    public bool IsIsomorphic(string s, string t) {
        int[] sTable = new int[128], tTable = new int[128];

        for (int i = 0; i < s.Length; i++)
        {
            int sCode = s[i];
            int tCode = t[i];
            if (sTable[sCode] != tTable[tCode] ){
                return false;
            }
            sTable[sCode] = tTable[tCode] = sCode;
        } 
        return true;      
    }
}