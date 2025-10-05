public class Solution
{
    public int MaxBottlesDrunk(int numBottles, int numExchange)
    {
        int ans = numBottles;

        while (numBottles >= numExchange)
        {
            numBottles -= numExchange;
            numBottles++;
            numExchange++;
            ans++;
        }
        return ans;
    }
}

public class Solution2
{
    public int MaxBottlesDrunk(int numBottles, int numExchange)
    {
        // t * numExchange + t(t−1)/2 − (numBottles+t) ≤ 0.
        // t ^ 2 + (2 * numExchange - 3) * t - 2 * numBottles ≤ 0.
        int a = 1;
        int b = 2 * numExchange - 3;
        int c = -2 * numBottles;
        double delta = b * b - 4.0 * a * c;
        int t = (int)Math.Ceiling((Math.Sqrt(delta) - b) / (2.0 * a));
        return numBottles + t - 1;
    }
}