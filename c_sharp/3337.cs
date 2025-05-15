public class Solution
{
    private const int MOD = 1000000007;
    private const int nChar = 26;
    public int LengthAfterTransformations(string s, int t, IList<int> nums)
    {
        Matrix transformMat = new Matrix();

        for (int i = 0; i < nChar; i++)
        {
            for (int j = 1; j <= nums[i]; j++)
            {
                transformMat.a[(i + j) % nChar][i] = 1;
            }
        }

        Matrix multipleTransform = quickMul(transformMat, t);
        int[] counts = new int[nChar];
        foreach (int c in s)
        {
            counts[c - 'a']++;
        }

        int ans = 0;
        for (int i = 0; i < nChar; i++)
        {
            for (int j = 0; j < nChar; j++)
            {
                ans = (int)((ans + (long)multipleTransform.a[i][j] * counts[j]) % MOD);
            }
        }
        return ans;
    }

    private class Matrix
    {
        public int[][] a = new int[nChar][];

        public Matrix()
        {
            for (int i = 0; i < nChar; i++)
            {
                a[i] = new int[nChar];
            }
        }

        public Matrix(Matrix from)
        {
            for (int i = 0; i < nChar; i++)
            {
                a[i] = new int[nChar];
                for (int j = 0; j < nChar; j++)
                {
                    a[i][j] = from.a[i][j];
                }
            }
        }

        public Matrix Mul(Matrix other)
        {
            Matrix result = new Matrix();
            for (int i = 0; i < nChar; i++)
            {
                for (int j = 0; j < nChar; j++)
                {
                    for (int k = 0; k < nChar; k++)
                    {
                        result.a[i][j] = (int)((result.a[i][j] + (long)a[i][k] * other.a[k][j]) % MOD);
                    }
                }
            }
            return result;
        }
    }

    private Matrix identityMat()
    {
        Matrix m = new Matrix();
        for (int i = 0; i < nChar; i++)
        {
            m.a[i][i] = 1;
        }
        return m;
    }

    private Matrix quickMul(Matrix m, int t)
    {
        Matrix ans = identityMat();
        Matrix current = new Matrix(m);
        while (t > 0)
        {
            if ((t & 1) == 1)
            {
                ans = ans.Mul(current);
            }
            current = current.Mul(current);
            t /= 2;
        }
        return ans;
    }
}