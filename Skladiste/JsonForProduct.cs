using System.Text.Json;

namespace Skladiste
{
    internal class JsonForProduct
    {
        public static string FileName = "Products.json";
        public static List<Product> Products = GetProductList();

        public static List<Product> GetProductList()
        {
            List<Product>? productList = new List<Product>();
            try
            {
                string JsonFile = File.ReadAllText(FileName);
                productList = JsonSerializer.Deserialize<List<Product>>(JsonFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine("There are no products yet. Please add products before taking that action.");
            }

            return productList;
        }

        public static void JsonProductWriter(Product product)
        {
            List<Product>? productList = new List<Product>();

            if (File.Exists(FileName))
            {
                string existingJson = File.ReadAllText(FileName);
                productList = JsonSerializer.Deserialize<List<Product>>(existingJson);
            }

            productList?.Add(product);

            using var stream = File.Exists(FileName) ? File.OpenWrite(FileName) : File.Create(FileName);
            JsonSerializer.Serialize(stream, productList);
            stream.Dispose();
            Products = GetProductList();
        }

        public static void JsonReader()
        {
            int i = 1;
            foreach (Product product in Products)
            {
                Console.WriteLine("\n" + i++);
                Console.WriteLine(product.ToString());
            }
        }

        public static Product FindById(string id)
        {
            Product foundProduct = null;
            foreach(Product product in Products)
            {
                if(product.Id == id)
                {
                    foundProduct = product;
                }
            }
            return foundProduct;
        }

        public static void JsonDelete(string id)
        {
            Product product = FindById(id);
            if(product != null) {
                Products.Remove(product);
                string updatedJson = JsonSerializer.Serialize(Products);

                File.WriteAllTextAsync(FileName, updatedJson);
                Console.WriteLine($"Product with ID: {id} is successfully deleted.");
            }
           else { Console.WriteLine("Product with that ID is not found."); }
        }

        public static void ShowNotInStock()
        {
            bool indicator = false;
            foreach(Product product in Products)
            {
                if(product.InStock == 0)
                {
                    indicator = true;
                    Console.WriteLine(product.ToString());
                }
            }

            if(!indicator)
            {
                Console.WriteLine("No products are out of stock.");
            }
        }
    }
}
