namespace Skladiste
{
    internal class Product
    {
        private String _id = Guid.NewGuid().ToString("N");
        private String _name;
        private String _description;
        private Double _price;
        private int _inStock;

        public Product()
        {
            _name = "default";
            _description = "";
            _price = 0.0;
            _inStock = 0;
        }

        public Product(String _name, String _description, Double _price, int _inStock)
        {
            this._name = _name;
            this._description = _description;
            this._price = _price;
            this._inStock = _inStock;
        }

        public String Id { get { return _id; } }
        public String Name { get { return _name;} set { _name = value; } }
        public String Description { get { return _description; } set { _description = value; } }
        public Double Price { get { return _price; } set { _price = value; } }
        public int InStock { get { return _inStock; } set { _inStock = value; } }
    }
}
