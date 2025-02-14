public class ProductOfNumbers
{

    private List<int> prefixProduct;
    private int currentProduct = 1;
    public ProductOfNumbers()
    {
        prefixProduct = new List<int>() { 1 };
    }

    public void Add(int num)
    {
        if (num == 0)
        {
            currentProduct = 1;
            prefixProduct = new List<int>() { 1 };
        }
        else
        {
            currentProduct *= num;
            prefixProduct.Add(currentProduct);
        }
    }

    public int GetProduct(int k)
    {
        int len = prefixProduct.Count - 1;
        if (k > len)
            return 0;
        else
            return prefixProduct[len] / prefixProduct[len - k];
    }
}

/**
 * Your ProductOfNumbers object will be instantiated and called as such:
 * ProductOfNumbers obj = new ProductOfNumbers();
 * obj.Add(num);
 * int param_2 = obj.GetProduct(k);
 */