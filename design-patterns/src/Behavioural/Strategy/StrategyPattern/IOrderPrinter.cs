using System.Collections.Generic;

namespace StrategyPattern
{
    public interface IOrderPrinter
    {
        void Print(ICollection<Order> orders);
    }
}
