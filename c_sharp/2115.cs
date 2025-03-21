public class Solution
{
    // DFS
    public IList<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies)
    {
        List<string> result = new();
        bool[] visited = new bool[recipes.Length];
        Dictionary<string, int> recipesMap = new();
        Dictionary<string, bool> canMake = new();

        foreach (string supply in supplies)
            canMake[supply] = true;

        for (int i = 0; i < recipes.Length; i++)
            recipesMap[recipes[i]] = i;
        
        foreach (string recipe in recipes){
            CheckRecipe(recipe, recipesMap, canMake, visited, ingredients);

            if (canMake[recipe]) result.Add(recipe);
        }
        return result;
    }

    private void CheckRecipe(string recipe, Dictionary<string, int> recipesMap, Dictionary<string, bool> canMake, bool[] visited, IList<IList<string>> ingredients)
    {
        if (canMake.ContainsKey(recipe) && canMake[recipe]) return;

        if (!recipesMap.ContainsKey(recipe) || visited[recipesMap[recipe]])
        {
            canMake[recipe] = false;
            return;
        }

        visited[recipesMap[recipe]] = true;

        var needIngredient = ingredients[recipesMap[recipe]];

        foreach (var ingredient in needIngredient)
        {
            CheckRecipe(ingredient, recipesMap, canMake, visited, ingredients);

            if (!canMake[ingredient])
            {
                canMake[recipe] = false;
                return;
            }
        }
        canMake[recipe] = true;
    }
}

public class Solution2
{
    // topological sort
    public IList<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies)
    {
        List<string> result = new();
        HashSet<string> availableSupplies = new (supplies);
        Dictionary<string, int> recipesMap = new();
        Dictionary<string, List<string>> dependencyGraph = new();
        int[] inDegree = new int[recipes.Length];

        for (int i = 0; i < recipes.Length; i++)
            recipesMap[recipes[i]] = i;

        for (int recipeIdx = 0; recipeIdx < recipes.Length; recipeIdx++){
            foreach (var ingredient in ingredients[recipeIdx])
            {
                if (!availableSupplies.Contains(ingredient)){
                    if (!dependencyGraph.ContainsKey(ingredient))
                        dependencyGraph[ingredient] = new List<string>();
                    dependencyGraph[ingredient].Add(recipes[recipeIdx]);
                    inDegree[recipeIdx]++; 
                }
            }
        }

        Queue<int> queue = new ();
        for (int i = 0; i < inDegree.Length; i++)
        {
            if (inDegree[i] == 0)
                queue.Enqueue(i);
        }

        while (queue.Count > 0){
            int recipeIdx = queue.Dequeue();
            var recipe = recipes[recipeIdx];
            result.Add(recipe);

            if (!dependencyGraph.ContainsKey(recipe)) continue;

            foreach (var dependencyRecipe in dependencyGraph[recipe])
            {
                if (--inDegree[recipesMap[dependencyRecipe]] == 0){
                    queue.Enqueue(recipesMap[dependencyRecipe]);
                }
            }
        }
        
        return result;
    }
}