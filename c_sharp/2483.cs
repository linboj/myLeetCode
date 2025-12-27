public class Solution
{
    public int BestClosingTime(string customers)
    {
        int n = customers.Length;
        int minP = 0, curP = 0;
        int minT = 0;

        for (int i = 0; i < n; i++)
        {
            if (customers[i] == 'Y')
                curP--;
            else
                curP++;

            if (curP < minP)
            {
                minT = i + 1;
                minP = curP;
            }
        }
        return minT;
    }
}