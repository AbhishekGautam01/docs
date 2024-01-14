namespace Domain.Products
{
    // Stock Keeping Unit
    public record Sku
    {
        private const int DefaultLength = 15;
        private Sku(string value) => Value = value;

        // init setter: As soon as value is set it cannot be changed. 
        public string Value { get; init; }

        public static Sku? Create(string value)
        {
            if(string.IsNullOrEmpty(value)) return null;
            if(value.Length != DefaultLength) return null;
            return new Sku(value);
        }
    }
}
