public class Solution {
    public int HammingWeight(int n) {
        int res = 0;
        uint baseN = 1;
        while (baseN <= n) {
            if ((baseN & n) != 0) res++;
            baseN <<= 1;
        }
        return res;
    }
}