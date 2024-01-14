namespace Domain.Customers
{
    // Customer Entity
    internal class Customer
    {
        // identifier as it is an entity. This will be used to reference this entity from other entities or aggregate route
        public CustomerId Id { get; private set; }
        //Private setters as we dont want these properties to change directly from outside this class. we will expose some methods to do so. 
        public string Email { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
    }
}
