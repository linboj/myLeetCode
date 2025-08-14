public class Solution
{
    public string LargestGoodInteger(string num)
    {
        int n = num.Length;
        string ans = "";

        for (int i = 1; i < n - 1; i++)
        {
            if (num[i - 1] == num[i] && num[i] == num[i + 1])
            {
                if (ans.Length == 0 || num[i - 1] > ans[0])
                {
                    ans = num.Substring(i - 1, 3);
                }
            }
            else if (num[i] != num[i + 1])
            {
                i++;
            }
        }

        return ans;
    }
}