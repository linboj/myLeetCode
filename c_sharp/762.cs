public class Solution
{
    private HashSet<int> primeSet = new();
    public int CountPrimeSetBits(int left, int right)
    {
        int ans = 0;
        UpdatePrimeSet();
        for (int num = left; num <= right; num++)
        {
            int bit1 = Count1(num);
            if (primeSet.Contains(bit1))
                ans++;
        }
        return ans;
    }

    private int Count1(int num)
    {
        int cnt = 0;
        while (num > 0)
        {
            cnt += num % 2;
            num /= 2;
        }
        return cnt;
    }

    private void UpdatePrimeSet()
    {
        primeSet.Add(2);
        for (int i = 3; i < 32; i += 2)
        {
            bool isPrime = true;
            for (int j = 2; j < i; j++)
            {
                if (i % j == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime)
                primeSet.Add(i);
        }
    }
}