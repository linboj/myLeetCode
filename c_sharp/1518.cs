public class Solution
{
    public int NumWaterBottles(int numBottles, int numExchange)
    {
        int ans = numBottles;

        while (numBottles >= numExchange)
        {
            int exchangeBottles = numBottles / numExchange;
            ans += exchangeBottles;
            numBottles = numBottles % numExchange + exchangeBottles;
        }
        return ans;
    }
}