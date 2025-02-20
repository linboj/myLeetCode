using System.Text;

public class Solution
{
    public string GetHappyString(int n, int k)
    {
        int nNode = (int)Math.Pow(2, n - 1);
        if (k > nNode * 3) return "";
        k--;
        char[] letters = { 'a', 'b', 'c' };
        StringBuilder result = new();
        result.Append(letters[k / nNode]);
        while (result.Length != n)
        {
            k %= nNode;
            nNode /= 2;
            int sequecnce = k / nNode;
            switch (result[result.Length - 1])
            {
                case 'a':
                    result.Append(letters[sequecnce + 1]);
                    break;
                case 'b':
                    result.Append(sequecnce == 1 ? letters[2] : letters[0]);
                    break;
                case 'c':
                    result.Append(letters[sequecnce]);
                    break;
            }
        }
        return result.ToString();
    }
}