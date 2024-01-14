namespace Domain.Products
{
    // Records have structural equality by default. Hence these are suitable for ValueObjects
    // Records are immutable by design.
    // This is a Value object
    // Below is demonstration of primary constructor feature 
    public record Money(string Currency, decimal Amount);
}
