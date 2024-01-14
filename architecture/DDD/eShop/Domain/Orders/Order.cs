using Domain.Customers;
using Domain.Products;
using System;
using System.Collections.Generic;

namespace Domain.Orders
{
    // We can store a reference of another entity using the foreign key
    internal class Order
    {
        private readonly HashSet<LineItem> _lineItems = new ();
        private Order()
        {

        }

        public OrderId Id { get; private set; }
        public CustomerId CustomerId { get; private  set; }

        // Factory method to create an order. This uses the private constructor
        public static Order Create(Customer customer)
        {
            var order = new Order()
            {
                Id = new OrderId(Guid.NewGuid()),
                CustomerId = customer.Id,
            };
            return order;
        }

        // Using strongly typed IDs we can remove dependencies on passing actual object rather we can pass strongly typed Ids.
        public void Add(ProductId productId, Money Price)
        {
            var lineItem = new LineItem(
                new LineItemId(Guid.NewGuid()), 
                Id, 
                productId, 
                Price);
            _lineItems.Add(lineItem);
        }
    }

    public class LineItem
    {
        // Now it is strongly typed so we cannot pass any wrong values here. 
        internal LineItem(LineItemId id, OrderId orderId, ProductId productId, Money price)
        {
            Id = id;
            OrderId = orderId;
            ProductId = productId;
            Price = price;
        }

        public LineItemId Id { get; private set; }
        public OrderId OrderId { get; set; }
        public ProductId ProductId { get; set; }

        // Money has meaning in our entire domain so we can move it to common place
        public Money Price { get; private set; }
    }
}
