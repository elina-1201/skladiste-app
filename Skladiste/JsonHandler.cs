using System.Text.Json;

namespace Skladiste
{
    internal class JsonHandler
    {
        public static void JsonProductWriter(Product product)
        {
            var fileName = "Products.json";
            List<Product>? productList = new List<Product>();

            if (File.Exists(fileName))
            {
                String existingJson = File.ReadAllText(fileName);
                productList = JsonSerializer.Deserialize<List<Product>>(existingJson);
            }

            productList?.Add(product);
            using var stream = File.Exists(fileName) ? File.OpenWrite(fileName) : File.Create(fileName);
            JsonSerializer.Serialize(stream, productList);
            stream.Dispose();
        }

        public static void JsonReader()
        {
            try
            {
                String existingJson = File.ReadAllText("Products.json");
                List<Product>? productList = JsonSerializer.Deserialize<List<Product>>(existingJson);
                foreach (Product pr in productList)
                {
                    Console.WriteLine();
                    Console.WriteLine(pr.Id);
                    Console.WriteLine(pr.Name);
                    Console.WriteLine(pr.Description);
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("There are no products yet. Please add products before taking that action");
            }
        }

    }
}
