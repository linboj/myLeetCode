public class Solution {
    public int MySqrt(int x) {
        if (x == 0) return 0;
        int left = 1, right = x;
        while (left <= right) {
            int mid = (left + right) / 2;
            int sqrt = x / mid;

            if (sqrt == mid) return mid;
            else if (sqrt < mid) right = mid - 1;
            else left = mid + 1;
        }
        return right;
    }
}