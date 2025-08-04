public class Solution
{
    public int TotalFruit(int[] fruits)
    {
        int n = fruits.Length;
        Dictionary<int, int> freq = new();
        int ans = 0;
        int left = 0, right = 0;

        while (right < n)
        {
            if (!freq.ContainsKey(fruits[right]))
                freq[fruits[right]] = 0;
            freq[fruits[right]]++;

            while (freq.Count > 2)
            {
                freq[fruits[left]]--;
                if (freq[fruits[left]] <= 0)
                    freq.Remove(fruits[left]);
                left++;
            }
            int cum = right - left + 1;
            ans = Math.Max(ans, cum);
            right++;
        }
        return ans;
    }
}

public class Solution2
{
    public int TotalFruit(int[] fruits)
    {
        int n = fruits.Length;
        int fruitA = fruits[0];
        int fruitB = -1;
        int ans = 1;
        int singleCount = 1, doubleCount = 1;

        for (int i = 1; i < n; i++)
        {
            if (fruits[i] == fruitA)
            {
                singleCount++;
                doubleCount++;
            }
            else if (fruitB == -1 || fruits[i] == fruitB)
            {
                fruitB = fruitA;
                fruitA = fruits[i];
                singleCount = 1;
                doubleCount++;
            }
            else
            {
                ans = Math.Max(ans, doubleCount);
                fruitB = fruitA;
                fruitA = fruits[i];
                doubleCount = singleCount + 1;
                singleCount = 1;
            }
        }

        return Math.Max(ans, doubleCount);
    }
}