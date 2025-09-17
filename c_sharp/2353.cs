public class FoodRatings
{

    private Dictionary<string, int> foodRatingMap = new();
    private Dictionary<string, string> foodCuisineMap = new();
    private Dictionary<string, SortedSet<Tuple<string, int>>> cuisineFoodMap = new();
    public FoodRatings(string[] foods, string[] cuisines, int[] ratings)
    {
        int n = foods.Length;
        for (int i = 0; i < n; i++)
        {
            string food = foods[i];
            string cuisine = cuisines[i];
            int rating = ratings[i];
            foodRatingMap[food] = rating;
            foodCuisineMap[food] = cuisine;
            if (!cuisineFoodMap.ContainsKey(cuisine))
                cuisineFoodMap[cuisine] = new(
                    Comparer<Tuple<string, int>>.Create((a, b) =>
                    a.Item2.Equals(b.Item2) ?
                    a.Item1.CompareTo(b.Item1)
                    :
                    b.Item2.CompareTo(a.Item2)
                    ));
            cuisineFoodMap[cuisine].Add(new Tuple<string, int>(food, rating));
        }
    }

    public void ChangeRating(string food, int newRating)
    {
        var cuisine = foodCuisineMap[food];
        cuisineFoodMap[cuisine].Remove(new Tuple<string, int>(food, foodRatingMap[food]));
        foodRatingMap[food] = newRating;
        cuisineFoodMap[cuisine].Add(new Tuple<string, int>(food, newRating));
    }

    public string HighestRated(string cuisine)
    {
        return cuisineFoodMap[cuisine].Min.Item1;
    }
}

/**
 * Your FoodRatings object will be instantiated and called as such:
 * FoodRatings obj = new FoodRatings(foods, cuisines, ratings);
 * obj.ChangeRating(food,newRating);
 * string param_2 = obj.HighestRated(cuisine);
 */