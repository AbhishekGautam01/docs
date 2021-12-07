using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern
{
    public class DetailPrinter : IOrderPrinter
    {

        public void Print(ICollection<Order> orders)
    {
        Console.WriteLine("************* Detail Report ***********");
        IEnumerator<Order> iter = orders.GetEnumerator();
        double total = 0;
        while(iter.MoveNext())
        {
            double orderTotal = 0;
            Order order = iter.Current;
            Console.WriteLine(order.getId() + " \t" + order.getDate());
            foreach (KeyValuePair<String, Double> entry in  order.getItems())
            {
                Console.WriteLine("\t\t" + entry.Key + "\t" + entry.Value);
                orderTotal += entry.Value;
            }
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("\t\t Total  " + orderTotal);
            Console.WriteLine("----------------------------------------");
            total += orderTotal;
        }
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("\tGrand Total " + total);
    }
}
}
