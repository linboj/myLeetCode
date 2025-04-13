public class Solution
{
    public long CountGoodIntegers(int n, int k)
    {
        HashSet<string> dict = new();
        int baseValue = (int)Math.Pow(10, (n - 1) / 2);
        int skip = n & 1;

        for (int val = baseValue; val < baseValue * 10; val++)
        {
            string valS = val.ToString();
            valS += new string(valS.Reverse().ToArray()).Substring(skip);
            long palindromicInt = long.Parse(valS);

            if (palindromicInt % k == 0)
            {
                var chars = valS.ToCharArray();
                Array.Sort(chars);
                dict.Add(new string(chars));
            }
        }

        long[] factorial = new long[n + 1];
        factorial[0] = 1;
        for (int i = 1; i <= n; i++)
        {
            factorial[i] = factorial[i - 1] * i;
        }

        long ans = 0;
        foreach (var key in dict)
        {
            int[] counts = new int[10];
            foreach (var c in key)
            {
                counts[c - '0']++;
            }

            long total = (n - counts[0]) * factorial[n - 1];
            foreach (var c in counts)
            {
                total /= factorial[c];
            }

            ans += total;
        }

        return ans;
    }
}