public class Solution
{
    public long MinTime(int[] skill, int[] mana)
    {
        int n = skill.Length, m = mana.Length;
        long[] free = new long[n];

        for (int j = 0; j < m; j++)
        {
            long current = 0;
            for (int i = 0; i < n; i++)
            {
                current = Math.Max(current, free[i]) + skill[i] * mana[j];
            }

            free[n - 1] = current;
            for (int i = n - 2; i >= 0; i--)
            {
                free[i] = free[i + 1] - skill[i + 1] * mana[j];
            }
        }
        return free[n - 1];
    }
}

public class Solution2
{
    public long MinTime(int[] skill, int[] mana)
    {
        int n = skill.Length, m = mana.Length;
        long[] sumSkill = new long[n];
        for (int i = 1; i < n; i++)
            sumSkill[i] = sumSkill[i - 1] + skill[i];

        long tSum = (long)skill[0] * mana[0];

        for (int j = 1; j < m; j++)
        {
            long tMax = (long)skill[0] * mana[j];

            for (int i = 1; i < n; i++)
                tMax = Math.Max(tMax, sumSkill[i] * mana[j - 1] - sumSkill[i - 1] * mana[j]);

            tSum += tMax;
        }

        return tSum + sumSkill[n - 1] * mana[m - 1];
    }
}