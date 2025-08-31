public class Solution
{
    public long FlowerGame(int n, int m)
    {
        int oddM = (m + 1) / 2;
        int evenM = m / 2;
        int oddN = (n + 1) / 2;
        int evenN = n / 2;
        return (long)oddM * evenN + (long)evenM * oddN;
    }
}