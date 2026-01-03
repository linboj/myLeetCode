public class Solution
{
    private const int MOD = 1000000007;
    public int NumOfWays(int n)
    {
        long typeA = 6; // three different grid color
        long typeB = 6; // first grid color same as third grid color

        for (int i = 0; i < n - 1; i++)
        {
            long nTypeA = (2 * typeA + 2 * typeB) % MOD; // 
            long nTypeB = (2 * typeA + 3 * typeB) % MOD;
            typeA = nTypeA;
            typeB = nTypeB;
        }
        return (int)((typeA + typeB) % MOD);
    }
}