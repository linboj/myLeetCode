public class Solution
{
    public bool ThreeConsecutiveOdds(int[] arr)
    {
        int count = 0;

        foreach (var num in arr)
        {
            if ((num & 1) == 0)
            {
                count = 0;
                continue;
            }
            count++;

            if (count == 3)
                return true;
        }

        return false;
    }
}