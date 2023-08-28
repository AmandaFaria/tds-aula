namespace Products.API.Models
{
    public class ProductModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }

        public ProductModel(int? id, string? name, decimal price, int amount)
        {
            Id = id;
            Name = name;
            Price = price;
            Amount = amount;
        }
    }
}