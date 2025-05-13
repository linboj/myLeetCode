public class Solution
{
    public int[] FindEvenNumbers(int[] digits)
    {
        List<int> ans = new();
        int[] counts = new int[10];

        foreach (var digit in digits)
        {
            counts[digit]++;
        }

        int[] used = new int[10];

        for (int i = 100; i < 1000; i += 2)
        {
            int digit1 = i / 100;
            int digit2 = i % 100 / 10;
            int digit3 = i % 10;

            used[digit1]++;
            used[digit2]++;
            used[digit3]++;

            if (counts[digit1] >= used[digit1] && counts[digit2] >= used[digit2] && counts[digit3] >= used[digit3])
                ans.Add(i);

            used[digit1] = 0;
            used[digit2] = 0;
            used[digit3] = 0;

        }

        return ans.ToArray();
    }
}