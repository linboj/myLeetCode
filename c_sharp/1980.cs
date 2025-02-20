public class Solution
{
    public string FindDifferentBinaryString(string[] nums)
    {
        StringBuilder ans = new();

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i][i] == '0')
            {
                ans.Append('1');
            }
            else
            {
                ans.Append('0');
            }
        }

        return ans.ToString();
    }
}