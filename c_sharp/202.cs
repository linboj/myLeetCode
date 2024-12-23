public class Solution {
    public bool IsHappy(int n) {
        if ( n < 10){
            return n == 1 || n == 7;
        }

        int sum = 0;
        while (n > 0){
            sum += (int)Math.Pow(n % 10, 2);
            n /= 10;
        }
        return IsHappy(sum);
    }
}