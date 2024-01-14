using System;

namespace Domain.Customers
{
    // Strongly typed, Structural Equality, Immutable
    public record CustomerId(Guid Value);
}
