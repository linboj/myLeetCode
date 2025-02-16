public class Solution
{
    public int[] ConstructDistancedSequence(int n)
    {
        int[] resultSequence = new int[2 * n - 1];
        bool[] isNumberUsed = new bool[n];
        FindDistancedSequence(0, resultSequence, isNumberUsed);
        return resultSequence;
    }

    private bool FindDistancedSequence(int currentIndex, int[] resultSequence, bool[] isNumberUsed)
    {
        if (currentIndex == resultSequence.Length) return true;

        if (resultSequence[currentIndex] != 0) return FindDistancedSequence(currentIndex + 1, resultSequence, isNumberUsed);

        for (int numToPlace = isNumberUsed.Length; numToPlace > 0; numToPlace--)
        {
            if (isNumberUsed[numToPlace - 1]) continue;
            isNumberUsed[numToPlace - 1] = true;
            resultSequence[currentIndex] = numToPlace;
            // 1 only used once
            if (numToPlace == 1)
            {
                if (FindDistancedSequence(currentIndex + 1, resultSequence, isNumberUsed)) return true;
            }
            else if (numToPlace + currentIndex < resultSequence.Length && resultSequence[currentIndex + numToPlace] == 0)
            {
                resultSequence[currentIndex + numToPlace] = numToPlace;
                if (FindDistancedSequence(currentIndex + 1, resultSequence, isNumberUsed)) return true;
                resultSequence[currentIndex + numToPlace] = 0;
            }
            isNumberUsed[numToPlace - 1] = false;
            resultSequence[currentIndex] = 0;
        }
        return false;
    }
}