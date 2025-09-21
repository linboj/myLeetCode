public class MovieRentingSystem
{
    private Dictionary<(int shop, int movie), int> priceMap;

    private Dictionary<int, SortedSet<(int price, int shop)>> available;

    private SortedSet<(int price, int shop, int movie)> rented;

    public MovieRentingSystem(int n, int[][] entries)
    {
        priceMap = new();
        available = new();
        rented = new(Comparer<(int price, int shop, int movie)>.Create((a, b) =>
            a.price != b.price ? a.price.CompareTo(b.price) :
                a.shop != b.shop ? a.shop.CompareTo(b.shop) :
                a.movie.CompareTo(b.movie)
        ));

        foreach (var entry in entries)
        {
            int shop = entry[0], movie = entry[1], price = entry[2];
            priceMap[(shop, movie)] = price;
            if (!available.ContainsKey(movie))
                available[movie] = new(Comparer<(int price, int shop)>.Create((a, b) =>
                    a.price != b.price ? a.price.CompareTo(b.price) : a.shop.CompareTo(b.shop)));
            available[movie].Add((price, shop));
        }
    }

    public IList<int> Search(int movie)
    {
        List<int> ans = new();
        if (!available.ContainsKey(movie))
            return ans;

        foreach (var (price, shop) in available[movie])
        {
            ans.Add(shop);
            if (ans.Count == 5)
                break;
        }
        return ans;
    }

    public void Rent(int shop, int movie)
    {
        int price = priceMap[(shop, movie)];
        available[movie].Remove((price, shop));
        rented.Add((price, shop, movie));
    }

    public void Drop(int shop, int movie)
    {
        int price = priceMap[(shop, movie)];
        rented.Remove((price, shop, movie));
        available[movie].Add((price, shop));
    }

    public IList<IList<int>> Report()
    {
        var res = new List<IList<int>>();
        foreach (var (price, shop, movie) in rented)
        {
            res.Add(new List<int> { shop, movie });
            if (res.Count == 5) break;
        }
        return res;
    }
}

/**
 * Your MovieRentingSystem object will be instantiated and called as such:
 * MovieRentingSystem obj = new MovieRentingSystem(n, entries);
 * IList<int> param_1 = obj.Search(movie);
 * obj.Rent(shop,movie);
 * obj.Drop(shop,movie);
 * IList<IList<int>> param_4 = obj.Report();
 */