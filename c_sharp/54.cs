public class Solution
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        List<int> res = new List<int>();
        int cMin = 0, cMax = matrix[0].Length - 1, rMin = 0, rMax = matrix.Length - 1;

        while (cMin <= cMax && rMin <= rMax)
        {
            // row traversal
            for (int i = cMin; i <= cMax; i++)
            {
                res.Add(matrix[rMin][i]);
            }
            rMin++;

            if (rMin > rMax) break;

            // col traversal
            for (int i = rMin; i <= rMax; i++)
            {
                res.Add(matrix[i][cMax]);
            }
            cMax--;

            if (cMin > cMax) break;

            // reverse row traversal
            for (int i = cMax; i >= cMin; i--)
            {
                res.Add(matrix[rMax][i]);
            }
            rMax--;

            if (rMin > rMax) break;

            // reverse col traversal
            for (int i = rMax; i >= rMin; i--)
            {
                res.Add(matrix[i][cMin]);
            }
            cMin++;
        }

        return res;

    }
}