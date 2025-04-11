public class Solution
{
    public long NumberOfPowerfulInt(long start, long finish, int limit, string s)
    {
        long startNum = getFirstPowerfulInt(start, limit, s);
        if (startNum > finish)
        {
            return 0;
        }

        long lastNum = getLastPowerfulInt(finish, limit, s);
        if (lastNum < startNum)
        {
            return 0;
        }
        long mod = (long)Math.Pow(10, s.Length);
        long startPrefix = startNum / mod, lastPrefix = lastNum / mod;
        long ans = 1;
        mod = 1;

        while (startPrefix < lastPrefix)
        {
            int startDigit = (int)(startPrefix % 10);
            int lastDigit = (int)(lastPrefix % 10);

            if (startDigit > limit)
                startPrefix += 10 - startDigit;

            if (startDigit > lastDigit)
            {
                ans += (lastDigit + (limit - startDigit) + 1) * mod;
                startPrefix += lastDigit + (10 - startDigit) + 1;
            }
            else if (startDigit < lastDigit)
            {
                ans += (lastDigit - startDigit) * mod;
                startPrefix += lastDigit - startDigit;
            }

            mod *= limit + 1;
            startPrefix /= 10;
            lastPrefix /= 10;
        }

        return ans;
    }

    private long getFirstPowerfulInt(long start, int limit, string s)
    {
        long sNum = long.Parse(s);
        long skipPart = (long)Math.Pow(10, s.Length);
        long mod = skipPart, baseMod = 1;
        long prefix = start / mod;
        if (prefix * mod + sNum < start)
        {
            prefix++;
        }

        mod = 1;
        while (prefix * 10 > mod)
        {
            int digit = (int)(prefix / mod % 10);
            if (digit > limit)
            {
                prefix += (10 - digit) * mod;
                baseMod = mod;
            }
            mod *= 10;
        }
        prefix = prefix / baseMod * baseMod;

        return prefix * skipPart + sNum;
    }

    private long getLastPowerfulInt(long finish, int limit, string s)
    {
        long sNum = long.Parse(s);
        long skipPart = (long)Math.Pow(10, s.Length);
        long mod = skipPart;
        long finishPrefix = finish / mod;
        bool switchToLimit = false;
        if (finishPrefix * mod + sNum > finish)
        {
            finishPrefix--;
        }

        mod = 1;
        while (finishPrefix > mod * 10)
        {
            mod *= 10;
        }

        while (mod > 0)
        {
            int digit = (int)(finishPrefix / mod % 10);
            if (switchToLimit)
            {
                finishPrefix -= (digit - limit) * mod;
            }
            else if (digit > limit)
            {
                finishPrefix -= (digit - limit) * mod;
                switchToLimit = true;
            }
            mod /= 10;
        }

        return finishPrefix * skipPart + sNum;
    }

}

public class Solution2
{
    // Combinatorial mathematics
    public long NumberOfPowerfulInt(long start, long finish, int limit, string s)
    {
        string startS = (start - 1).ToString();
        string finishS = finish.ToString();
        return Calculate(finishS, s, limit) - Calculate(startS, s, limit);
    }

    private long Calculate(string x, string s, int limit)
    {
        if (x.Length < s.Length)
            return 0;

        if (x.Length == s.Length)
            return string.Compare(x, s) >= 0 ? 1 : 0;

        string suffix = x.Substring(x.Length - s.Length);
        long count = 0;
        int prefixLen = x.Length - s.Length;

        for (int i = 0; i < prefixLen; i++)
        {
            int digit = x[i] - '0';
            if (limit < digit)
            {
                count += (long)Math.Pow(limit + 1, prefixLen - i);
                return count;
            }
            count += digit * (long)Math.Pow(limit + 1, prefixLen - 1 - i);
        }

        if (string.Compare(suffix, s) >= 0)
        {
            count++;
        }
        return count;
    }
}