public class Solution {
    public int RangeBitwiseAnd(int left, int right) {
        int count = 0;
        
        while (right != left) {
            count++;
            left >>= 1;
            right >>= 1;
        }
        return left << count; 
    }
}