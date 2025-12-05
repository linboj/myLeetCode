public class Solution
{
    public int CountCollisions(string directions)
    {
        int ans = 0;
        int flag = -1;

        foreach (var c in directions)
        {
            if (c == 'L')
            {
                if (flag >= 0)
                {
                    ans += flag + 1;
                    flag = 0;
                }
            }
            else if (c == 'S')
            {
                if (flag > 0)
                {
                    ans += flag;
                }
                flag = 0;
            }
            else
            {
                if (flag >= 0)
                    flag++;
                else
                    flag = 1;
            }
        }

        return ans;
    }
}

public class Solution2
{
    public int CountCollisions(string directions)
    {
        int ans = 0;
        int n = directions.Length;
        int l = 0, r = n - 1;

        while (l < n && directions[l] == 'L')
            l++;

        while (r >= l && directions[r] == 'R')
            r--;

        for (int i = l; i <= r; i++)
        {
            if (directions[i] != 'S')
                ans++;
        }
        return ans;
    }
}