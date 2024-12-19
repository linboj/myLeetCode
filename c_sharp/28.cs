public class Solution {
    public int StrStr(string haystack, string needle) {
        if (haystack.Length < needle.Length) return -1;

        char firstChar = needle[0];

        for (int i = 0; i <= haystack.Length - needle.Length; i++)
        {
            if (haystack[i] == firstChar && i + needle.Length <= haystack.Length){
                bool isMatching = true;
                for (int j = 1; j < needle.Length; j++){
                    if (haystack[i+j] != needle[j]){
                        isMatching = false;
                        break;
                    }
                }

                if (isMatching) return i;
            }
        }

        return -1;
    }
}