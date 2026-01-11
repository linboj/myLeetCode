public class Solution
{
    public int MaximalRectangle(char[][] matrix)
    {
        int ans = 0;
        int n = matrix.Length, m = matrix[0].Length;
        int[] hist = new int[m];

        for (int r = 0; r < n; r++)
        {
            for (int c = 0; c < m; c++)
            {
                if (r == 0)
                {
                    if (matrix[r][c] == '1')
                        hist[c] = 1;
                }
                else
                {
                    if (matrix[r][c] == '1')
                        hist[c]++;
                    else
                        hist[c] = 0;
                }
            }

            Stack<int> stack = new();
            for (int c = 0; c <= m; c++)
            {
                int curH = c == m ? 0 : hist[c];
                while (stack.Count > 0 && curH < hist[stack.Peek()])
                {
                    int height = hist[stack.Pop()];
                    int width = stack.Count == 0 ? c : c - stack.Peek() - 1;
                    ans = Math.Max(ans, height * width);
                }
                stack.Push(c);
            }
        }

        return ans;
    }
}