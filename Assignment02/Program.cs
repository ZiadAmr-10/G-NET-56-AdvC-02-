namespace Assignment02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductCatalog list = new();         
            Console.WriteLine("=========Electronics==========");
            //// Func<Product, bool> is used to pass a filtering condition that returns true or false in method.
            Func<Product, bool> filter = p => p.Category == "Electronics";
            List<Product> ElectronicProducts = ProductService.SearchProducts(list.Catalog,filter);
            foreach (var product in ElectronicProducts )
            {
                Console.WriteLine(product);
            }
            // Passing the lambda expression directly in the method -> creates the Func delegate inline.
            Console.WriteLine("=========Under50==========");
            List<Product> ProductsUnder50 = ProductService.SearchProducts(list.Catalog,p => p.Price < 50);
            foreach (var product in ProductsUnder50)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine("=========InStock=========");
            List<Product> inStock = ProductService.SearchProducts(list.Catalog, p => p.Stock > 0);
            foreach ( var product in inStock )
            {
                Console.WriteLine(product);
            }
            Console.WriteLine("=========Clothing Under 100=========");
            List<Product> ClothingUnder100 = ProductService.SearchProducts(list.Catalog, p => p.Category == "Clothing" && p.Price < 100);
            foreach ( var product in ClothingUnder100)
            {
                Console.WriteLine(product);     
            }
            Console.WriteLine("==========Print Short Report==========");
            ProductService.PrintReport(list.Catalog, p => Console.WriteLine($"{p.Name} - ${p.Price}"));
            Console.WriteLine("==========Print Detaild Report==========");
            ProductService.PrintReport(list.Catalog, p => Console.WriteLine($"[{p.Category}] {p.Name} | Price:${p.Price}|Stock:{p.Stock}"));
            Console.WriteLine("===========SummaryList==========");
            List<string> stringTransform = ProductService.Transform(list.Catalog, p => $"{p.Name} (${p.Price})");
            foreach ( var product in stringTransform)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine("==========Price Labels==========");
            List<string> priceLabels = ProductService.Transform(list.Catalog, p => p.Price > 100 ? $"{p.Name}| Expensive" : $"{p.Name}|Affordable");
            foreach ( var product in priceLabels)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine("==========LOW STOCK ALERT==========");
            List<Product> ListProduct = ProductService.FilterProduct(list.Catalog, p => p.Stock < 20);
            foreach ( var product in ListProduct)
            {
                Console.WriteLine($"[LOW STOCK] {product.Name}: only {product.Stock} left!");
            }
        }
    }

}