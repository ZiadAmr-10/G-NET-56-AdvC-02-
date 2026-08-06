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
        // Action<Product> is used because we only need to perform an operation (printing)
        public static void PrintReport(List<Product> products,Action<Product> action)
        {
            foreach (var item in products)
            {
                action(item);
            }    
        }
        public static List<T> Transform<T>(List<Product> product, Func<Product,T> transform ) 
        {
            List<T> Result = new();
            foreach (var item in product)
            {
               Result.Add(transform(item));
            }
            return Result;
        }
        //// Predicate<Product> is used to filter products based on a condition  because it returns bool (true or false).
        public static List<Product> FilterProduct(List<Product> listProduct , Predicate<Product> filter)
        {
            List<Product> Result = new();
            foreach (var item in listProduct )
            {
                if(filter(item))
                {
                    Result.Add(item);
                }
            }
            return Result;
        }
    }
}
