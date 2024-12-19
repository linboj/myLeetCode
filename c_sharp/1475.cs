public class Solution
{
    public int[] FinalPrices(int[] prices)
    {
        int[] answer = new int[prices.Length];
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < prices.Length; i++)
        {
            while (stack.Count > 0 && prices[stack.Peek()] >= prices[i] ){
                int popIdx = stack.Pop();
                answer[popIdx] = prices[popIdx] - prices[i];
            }
            
            stack.Push(i);
        }

        while (stack.Count > 0){
            int popIdx = stack.Pop();
            answer[popIdx] = prices[popIdx];
        }

        return answer;
    }
}