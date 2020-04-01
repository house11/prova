namespace Prodotti_grafica
{
    public class Description
    {
        public int id { get; set; > // id
        public int IdProducts { get; set; }
        public string Name { get; set; }

        public string Info { get; set; }

        public virtual Products Products { get; set; } //12
    }
}
