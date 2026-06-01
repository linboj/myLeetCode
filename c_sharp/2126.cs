public class Solution
{
    public bool AsteroidsDestroyed(int mass, int[] asteroids)
    {
        long sum = mass;
        Array.Sort(asteroids);

        foreach (var asteroid in asteroids)
        {
            if (sum < asteroid)
                return false;

            sum += asteroid;
        }

        return true;
    }
}

public class Solution2
{
    public bool AsteroidsDestroyed(int mass, int[] asteroids)
    {
        int[] cnts = new int[100_001];
        foreach (var asteroid in asteroids)
        {
            cnts[asteroid]++;
        }

        long sum = mass;
        int checkN = 0;
        for (int i = 1; i < 100_001; i++)
        {
            if (sum < i) return false;

            sum += (long)cnts[i] * i;
            checkN += cnts[i];

            if (checkN >= asteroids.Length) break;
        }

        return true;
    }
}