using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern
{
    public class SummaryPrinter : IOrderPrinter
    {
        public void Print(ICollection<Order> orders)
        {
            Console.WriteLine("**********Summary Report**********");
            var orderEnumerator = orders.GetEnumerator();
            double total = 0;
            while (orderEnumerator.MoveNext())
            {
                Order order = orderEnumerator.Current;
                Console.WriteLine($"{order.getId()} \t {order.getDate()} \t {order.getItems().Keys.Count} \t {order.getTotal()}");
                total += order.getTotal();
            }
            Console.WriteLine("************************************");
            Console.WriteLine($"Total: {total}");
        }
    }
}
