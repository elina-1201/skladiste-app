namespace Skladiste
{
    internal class AppLauncher
    {
        public static void StartApp()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("[X] Exit the program");
                Console.WriteLine("[1] Add new product");
                Console.WriteLine("[2] List all products");
                Console.WriteLine("[3] Remove product");
                Console.WriteLine("[4] Show product");
                Console.WriteLine("[5] Show products which are not in stock");
                

                string? userInput = Console.ReadLine();
                Console.Clear();
                switch (userInput?.ToLower())
                {
                    case "x":
                        Console.WriteLine("Exiting ...");
                        break;
                    case "1":
                        ProductEntry();
                        break;
                    case "2":
                        JsonForProduct.JsonReader();
                        break;
                    case "3":                        
                        DeleteProductById();
                        break;
                    case "4":
                        FindById();
                        break;
                    case "5":
                        JsonForProduct.ShowNotInStock();
                        break;
                    default:
                        Console.WriteLine("This option doesn't exist!");
                        break;
                }
                if (userInput?.ToLower() == "x") { break; }
            }
        }

        public static void ProductEntry()
        {
            Console.WriteLine("Enter the name: ");
            string? name = Console.ReadLine();

            Console.WriteLine("Enter the description: ");
            string? description = Console.ReadLine();

            Console.WriteLine("Enter the price: ");
            string? priceStr = Console.ReadLine();

            Console.WriteLine("Enter the amount: ");
            string? amountStr = Console.ReadLine();

            try
            {
                double price = double.Parse(priceStr);
                int amount = int.Parse(amountStr);

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(priceStr) || string.IsNullOrEmpty(amountStr))
                {
                    Console.Clear();
                    Console.WriteLine("All fields must be filled!");
                    ProductEntry();
                }
                else
                {
                    Product product = new Product(name, description, price, amount);
                    JsonForProduct.JsonProductWriter(product);
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Invalid number input.");
                ProductEntry();
            }
        }

        public static void DeleteProductById()
        {
            Console.WriteLine("Enter product ID: ");
            string id = Console.ReadLine().Trim();
            Console.WriteLine($"Are you sure you want to delete product with the id: {id} [Y/N]");
            string answer = Console.ReadLine().ToLower();

            if (answer == "y")
            {
                JsonForProduct.JsonDelete(id);
            }
            else { return; }
        }

        public static void FindById()
        {
            Console.WriteLine("Enter product ID: ");
            string id = Console.ReadLine().Trim();
            Product product = JsonForProduct.FindById(id);
            if( product != null )
            {
                Console.WriteLine(product.ToString());
            }
            else
            {
                Console.WriteLine("Product with that ID is not found.");
            }
        }
    }
}
