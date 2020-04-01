namespace Prodotti_grafica
{
    public class Products
    {
        public Products(int id, int Quantity, int Price)
        {
            this.id = id;
            this.Quantity = Quantity;
            this.Price = Price;
        }
        public Products(int id, int Quantity, int Price, string Name)
        {
            this.id = id;
            this.Quantity = Quantity;
            this.Price = Price;
        }
        public Products() { }
        public int id { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        // public List<Description> Description { get; set; }
        public Description Description { get; set; }

    }
}
