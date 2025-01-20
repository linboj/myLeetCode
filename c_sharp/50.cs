public class Solution
{
    public double MyPow(double x, int n)
    {
        if (n == 0) return 1;
        long longN = n;
        if (n < 0)
        {
            x = 1 / x;
            longN *= -1;
        }
        return CalculatePow(x, longN);
    }

    private double CalculatePow(double x, long n)
    {
        if (n == 1) return x;
        double halfPow = CalculatePow(x, n / 2);
        return n % 2 == 0 ? halfPow * halfPow : halfPow * halfPow * x;
    }
}