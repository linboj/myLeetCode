public class Solution {
    public int RomanToInt(string s) {
        int[] ints = new int[s.Length];

        for (int i = 0; i < s.Length; i++)
        {
            int v = 0;
            switch (s[i])
            {
                case 'I': v = 1; break;
                case 'V': v = 5; break;
                case 'X': v = 10; break;
                case 'L': v = 50; break;
                case 'C': v = 100; break;
                case 'D': v = 500; break;
                case 'M': v = 1000; break;
                default:
                    continue;
            }
            ints[i] = v;
        }
        int result = 0;
        int prev = 0;
        for (int i = ints.Length - 1; i >= 0; i--)
        {
            var current = ints[i];
            result += (prev > current) ? -current : current;
            prev = current;
        }
        return result;
    }
}