namespace Assignment02
{
    internal static class ProductService
    {
        //using  Func<Product, bool> allows passing different search conditions ,without modifying the SearchProducts method.
        public static List<Product> SearchProducts(List<Product> products , Func<Product,bool> filter)
        {
            List<Product> result = new();
            for (int i = 0; i < products.Count; i++) 
            {
                if (products[i] != null && filter(products[i]))
                {
                    result.Add(products[i]);
                }
            }
            return result;
        }
    }
}
