namespace Domain.Products
{
    internal class Product
    {
        public ProductId Id { get; set; }

        public string Name { get; private set; } = string.Empty;

        public Money Price { get; private set; }

        public Sku Sku { get; private set; }

    }
}
