public class Solution
{
    public int DifferenceOfSums(int n, int m)
    {
        int totalSum = (1 + n) * n / 2;
        int q = n / m;
        totalSum -= (m + m * q) * q / 2 * 2;
        return totalSum;
    }
}