namespace Skladiste
{
    internal class AppLauncher
    {
        public static void StartApp()
        {
            while (true)
            {
                Console.WriteLine("[X] za izlazak iz programa");
                Console.WriteLine("[1] Unos novog proizvoda");
                Console.WriteLine("[2] Pregled svih proizvoda");

                string? userInput = Console.ReadLine();
                switch (userInput?.ToLower())
                {
                    case "1":
                        ProductEntry();
                        break;
                    case "2":
                        JsonHandler.JsonReader();
                        break;
                    case "x":
                        Console.WriteLine("Exiting ...");
                        break;
                    default:
                        Console.WriteLine("This option doesn't exist");
                        break;
                }
                if (userInput?.ToLower() == "x") { break; }
            }

        }

        public static void ProductEntry()
        {
            Console.WriteLine("Unesite naziv: ");
            String naziv = Console.ReadLine();

            Console.WriteLine("Unesite opis: ");
            String opis = Console.ReadLine();

            Console.WriteLine("Unesite cijenu: ");
            Double cijena = double.Parse(Console.ReadLine());

            Console.WriteLine("Unesite broj primjeraka");
            int primjeraka = int.Parse(Console.ReadLine());

            Product product = new Product(naziv, opis, cijena, primjeraka);
            JsonHandler.JsonProductWriter(product);
        }
    }
}
