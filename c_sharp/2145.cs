public class Solution
{
    public int NumberOfArrays(int[] differences, int lower, int upper)
    {
        int max = 0, min = 0, current = 0;
        int range = upper - lower;

        foreach (var diff in differences)
        {
            current += diff;
            max = Math.Max(max, current);
            min = Math.Min(min, current);

            if (max - min > range)
                return 0;
        }

        return range + 1 - (max - min);
    }
}