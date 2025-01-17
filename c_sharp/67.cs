public class Solution
{
    public string AddBinary(string a, string b)
    {
        List<char> result = new();
        int i = a.Length - 1, j = b.Length - 1, carry = 0;
        while (i >= 0 || j >= 0 || carry > 0)
        {
            int sum = carry;
            if (i>=0){
                sum += a[i] - '0';
                i--;
            }
            if (j>=0){
                sum += b[j] - '0';
                j--;
            }
            carry = sum / 2;
            char c = (char)(sum % 2 + '0');
            result.Add(c);
        }
        result.Reverse();
        return new string(result.ToArray());
    }
}