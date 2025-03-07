public class Solution
{
    public int[] ClosestPrimes(int left, int right)
    {
        var primes = Sieve(right);
        int n = primes.Count;
        int[] ans = [-1, -1];
        int minDiff = int.MaxValue;
        int currentIdx = 0;
        while (currentIdx < n && primes[currentIdx] < left)
        {
            currentIdx++;
        }
        for (int i = currentIdx; i < n - 1; i++)
        {
            if ((primes[i + 1] - primes[i]) < minDiff)
            {
                ans[0] = primes[i];
                ans[1] = primes[i + 1];
                minDiff = primes[i + 1] - primes[i];
            }
        }
        return ans;
    }

    private List<int> Sieve(int n)
    {
        bool[] notPrime = new bool[n + 1];
        for (int current = 2; current * current <= n; current++)
        {
            if (!notPrime[current])
            {
                for (int i = current * current; i <= n; i += current)
                {
                    notPrime[i] = true;
                }
            }
        }
        List<int> result = new List<int>();
        for (int i = 2; i <= n; i++)
        {
            if (!notPrime[i]) result.Add(i);
        }
        return result;
    }
}

public class Solution2
{
    public int[] ClosestPrimes(int left, int right)
    {
        List<int> primes = new List<int>();

        for (int cur = left; cur <= right; cur++)
        {
            if (cur % 2 == 0 && cur > 2) continue;

            if (isPrime(cur))
            {
                if (primes.Count > 0 && cur <= primes[^1] + 2)
                {
                    return [primes[^1], cur];
                }
                primes.Add(cur);
            }
        }

        if (primes.Count < 2) return [-1, -1];

        int[] ans = [-1, -1];
        int minDiff = int.MaxValue;
        for (int index = 1; index < primes.Count; index++)
        {
            int diff =
                primes[index] - primes[index - 1];
            if (diff < minDiff)
            {
                minDiff = diff;
                ans[0] = primes[index - 1];
                ans[1] = primes[index];
            }
        }
        return ans;
    }

    private bool isPrime(int num){
        if (num == 1) return false;

        for (int divisor = 2; divisor <= (int)Math.Sqrt(num); divisor++){
            if (num % divisor == 0) {
                return false;
            }
        }
        return true;
    }
}