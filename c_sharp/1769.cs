public class Solution
{
    public int[] MinOperations(string boxes)
    {
        int[] ans = new int[boxes.Length];

        int ballsToLeft = 0, movesToLeft = 0;
        int ballsToRight = 0, movesToRight = 0;

        for (int i = 0; i < boxes.Length; i++)
        {
            ans[i] += movesToLeft;
            if (boxes[i] == '1'){
                ballsToLeft++;
            }
            movesToLeft += ballsToLeft;

            int j = boxes.Length - i -1;
            ans[j] += movesToRight;
            if (boxes[j] == '1'){
                ballsToRight++;
            }
            movesToRight += ballsToRight;
        }
        return ans;
    }
}