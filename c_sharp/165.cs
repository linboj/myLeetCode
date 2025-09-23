public class Solution
{
    public int CompareVersion(string version1, string version2)
    {
        int n = version1.Length, m = version2.Length;
        int idx1 = 0, idx2 = 0;

        while (idx1 < n || idx2 < m)
        {
            int sum1 = 0, sum2 = 0;

            while (idx1 < n && version1[idx1] != '.')
            {
                sum1 *= 10;
                sum1 += version1[idx1++] - '0';
            }

            while (idx2 < m && version2[idx2] != '.')
            {
                sum2 *= 10;
                sum2 += version2[idx2++] - '0';
            }

            if (sum1 > sum2)
                return 1;
            else if (sum1 < sum2)
                return -1;

            idx1++;
            idx2++;
        }
        return 0;
    }
}