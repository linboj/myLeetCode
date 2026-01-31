public class Solution
{
    public char NextGreatestLetter(char[] letters, char target)
    {
        int n = letters.Length;

        if (letters[n - 1] <= target) return letters[0];

        int l = 0, r = n - 1;
        while (l < r)
        {
            int mid = (l + r) / 2;
            char cur = letters[mid];

            if (cur <= target)
                l = mid + 1;
            else
                r = mid - 1;
        }
        return letters[l];
    }
}