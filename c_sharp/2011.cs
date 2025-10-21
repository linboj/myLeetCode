public class Solution
{
    public int FinalValueAfterOperations(string[] operations)
    {
        int ans = 0;

        foreach (var item in operations)
        {
            if (item[0] == 'X')
            {
                if (item[^1] == '+')
                    ans++;
                else
                    ans--;
            }
            else
            {
                if (item[0] == '+')
                    ans++;
                else
                    ans--;
            }
        }
        return ans;
    }
}