public class Solution
{
    public int MaxDiff(int num)
    {
        string numStr = num.ToString();
        int n = numStr.Length;

        int idxMax = 0, idxMin = 0;

        while (idxMax < n && numStr[idxMax] == '9')
            idxMax++;

        while (idxMin < n && (numStr[idxMin] == numStr[0] || numStr[idxMin] == '0'))
            idxMin++;

        int minAbleValue = 0;
        if (idxMax == n)
            idxMax = 0;
        if (idxMin == n || numStr[0] != '1')
        {
            idxMin = 0;
            minAbleValue = 1;
        }

        int maxValue = 0, minValue = 0;
        for (int i = 0; i < n; i++)
        {
            maxValue *= 10;
            minValue *= 10;
            int currMax = numStr[i] == numStr[idxMax] ? 9 : numStr[i] - '0';
            int currMin = numStr[i] == numStr[idxMin] ? minAbleValue : numStr[i] - '0';
            maxValue += currMax;
            minValue += currMin;
        }

        return maxValue - minValue;
    }
}