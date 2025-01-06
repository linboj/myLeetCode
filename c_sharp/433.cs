public class Solution
{
    public int MinMutation(string startGene, string endGene, string[] bank)
    {
        HashSet<string> banks = new(bank);
        if (!banks.Contains(endGene)) return -1;
        string options = "AGCT";
        Queue<(string, int)> queue = new();
        queue.Enqueue((startGene, 0));

        while (queue.Count > 0)
        {
            var (curGene, moves) = queue.Dequeue();

            if (curGene == endGene) return moves;
            char[] tmp = curGene.ToCharArray();
            
            for (int i = 0; i < curGene.Length; i++)
            {
                var cache = tmp[i];
                foreach (var option in options)
                {
                    if (tmp[i] == option) continue;
                    tmp[i] = option;
                    string mutatedGene = new(tmp);
                    if (banks.Contains(mutatedGene))
                    {
                        banks.Remove(mutatedGene);
                        queue.Enqueue((mutatedGene, moves + 1));
                    }
                }
                tmp[i] = cache;
            }
        }
        return -1;
    }
}