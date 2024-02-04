namespace Skladiste
{
    internal class Product
    {
        private string _id = Guid.NewGuid().ToString("N");
        private string _name;
        private string _description;
        private double _price;
        private int _inStock;

        public Product()
        {
            _name = "default_name";
            _description = "default_description";
            _price = 0.0;
            _inStock = 0;
        }

        public Product(string _name, string _description, double _price, int _inStock)
        {
            this._name = _name;
            this._description = _description;
            this._price = _price;
            this._inStock = _inStock;
        }

        public string Id { get { return _id; } set { _id = value; } }
        public string Name { get { return _name;} set { _name = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public double Price { get { return _price; } set { _price = value; } }
        public int InStock { get { return _inStock; } set { _inStock = value; } }

        public override string ToString()
        {
            return "ID: " + _id +
                "\nName: " + _name +
                "\nDescription: " + _description +
                "\nPrice: " + _price +
                "\nAmount: " + _inStock + "\n";
        }
    }
}
