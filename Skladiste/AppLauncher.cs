namespace Skladiste
{
    internal class AppLauncher
    {
        public static string NotFoundMsg = "Product with that ID is not found.";
        public static string NumErrorMsg = "Invalid number input.";
        public static void StartApp()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("[X] Exit the program");
                Console.WriteLine("[1] Add new product");
                Console.WriteLine("[2] List all products");
                Console.WriteLine("[3] Update product");
                Console.WriteLine("[4] Remove product");
                Console.WriteLine("[5] Show product");
                Console.WriteLine("[6] Show products which are not in stock");
                

                string? userInput = Console.ReadLine();
                Console.Clear();
                switch (userInput?.ToLower())
                {
                    case "x":
                        Console.WriteLine("Exiting ...");
                        break;
                    case "1":
                        CreateProduct();
                        break;
                    case "2":
                        JsonForProduct.JsonReader();
                        break;
                    case "3":
                        UpdateProduct();
                        break;
                    case "4":                        
                        DeleteProductById();
                        break;
                    case "5":
                        FindById();
                        break;
                    case "6":
                        JsonForProduct.ShowNotInStock();
                        break;
                    default:
                        Console.WriteLine("This option doesn't exist!");
                        break;
                }
                if (userInput?.ToLower() == "x") { break; }
            }
        }

        public static (string?, string?, string?, string?) ProductEntry()
        {
            Console.WriteLine("Enter the name: ");
            string? name = Console.ReadLine();

            Console.WriteLine("Enter the description: ");
            string? description = Console.ReadLine();

            Console.WriteLine("Enter the price: ");
            string? priceStr = Console.ReadLine();

            Console.WriteLine("Enter the amount: ");
            string? amountStr = Console.ReadLine();

            return (name, description, priceStr, amountStr);
        }
        public static Product? ReturnCreatedProduct()
        {
            var result = ProductEntry();
            string? name = result.Item1;
            string? description = result.Item2;
            string? priceStr = result.Item3;
            string? amountStr = result.Item4;

            try
            {
                double price = double.Parse(priceStr);
                int amount = int.Parse(amountStr);

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(priceStr) || string.IsNullOrEmpty(amountStr))
                {
                    Console.Clear();
                    Console.WriteLine("All fields must be filled!");
                    ReturnCreatedProduct();
                }
                else
                {
                    return new Product(name.Trim(), description.Trim(), price, amount);
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine(NumErrorMsg);
                ReturnCreatedProduct();
            }

            return null;
        }

        public static Product ReturnUpdatedProduct(Product product)
        {
            var result = ProductEntry();
            string? name = result.Item1;
            string? description = result.Item2;
            string? priceStr = result.Item3;
            string? amountStr = result.Item4;

            if (!string.IsNullOrEmpty(name))
            {
                product.Name = name;
            }
            if (!string.IsNullOrEmpty(description))
            {
                product.Description = description;
            }
            if(!string.IsNullOrEmpty(priceStr))
            {
                try {
                    double price = double.Parse(priceStr);
                    product.Price = price;
                }
                catch { Console.WriteLine(NumErrorMsg); }
            }
            if(!string.IsNullOrEmpty (amountStr))
            {
                try
                {
                    int amount = int.Parse(amountStr);
                    product.InStock = amount;
                }
                catch { Console.WriteLine(NumErrorMsg); }
            }

            return product;
        }

        public static void UpdateProduct()
        {
            Console.WriteLine("Enter product ID: ");
            string id = Console.ReadLine().Trim();
            Product foundProduct = JsonForProduct.FindById(id);

            if(id.ToLower() == "x") { return; }

            if (!string.IsNullOrEmpty(id))
            {
                if (foundProduct != null)
                {
                    Console.WriteLine("Press enter in field you do not want to update");
                    Product product = ReturnUpdatedProduct(foundProduct);
                    JsonForProduct.JsonUpdate(product);
                }
                else
                {
                    Console.WriteLine(NotFoundMsg);
                    UpdateProduct();
                }
            }
            else { UpdateProduct(); }
        }

        public static void CreateProduct()
        {
            Product? product = ReturnCreatedProduct();
            if(product != null)
            {
                JsonForProduct.JsonProductWriter(product);
                Console.WriteLine("Product added successfully");
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
                Console.WriteLine(NotFoundMsg);
            }
        }
    }
}
