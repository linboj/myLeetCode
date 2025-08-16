using System.Text;

public class Solution
{
    public int Maximum69Number(int num)
    {
        StringBuilder sb = new StringBuilder(num.ToString());

        for (int i = 0; i < sb.Length; i++)
        {
            if (sb[i] != '9')
            {
                sb[i] = '9';
                break;
            }
        }

        return int.Parse(sb.ToString());
    }
}

public class Solution2
{
    public int Maximum69Number(int num)
    {
        char[] numStr = num.ToString().ToCharArray();

        for (int i = 0; i < numStr.Length; i++)
        {
            if (numStr[i] != '9')
            {
                numStr[i] = '9';
                break;
            }
        }

        return int.Parse(new string(numStr));
    }
}