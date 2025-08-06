public class Solution
{
    public int NumOfUnplacedFruits(int[] fruits, int[] baskets)
    {
        int n = fruits.Length;
        int ans = 0;

        foreach (var fruit in fruits)
        {
            int found = 1;
            for (int i = 0; i < n; i++)
            {
                if (fruit <= baskets[i])
                {
                    baskets[i] = 0;
                    found--;
                    break;
                }
            }
            ans += found;
        }
        return ans;
    }
}