public class Solution
{
    public IList<int> LexicalOrder(int n)
    {
        List<int> ans = new();
        int currentNum = 1;

        for (int i = 0; i < n; i++)
        {
            ans.Add(currentNum);

            if (currentNum * 10 <= n)
                currentNum *= 10;
            else
            {
                while (currentNum % 10 == 9 || currentNum >= n)
                {
                    currentNum /= 10;
                }
                currentNum++;
            }
        }
        return ans;
    }
}