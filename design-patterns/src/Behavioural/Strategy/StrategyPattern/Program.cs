using System;
using System.Collections.Generic;

namespace StrategyPattern
{
    class Program
    {
        private static LinkedList<Order> orders = new LinkedList<Order>();
        static void Main(string[] args)
        {
            createOrders();
            PrintService service = new PrintService(new DetailPrinter());
            service.printOrders(orders);
        }
        private static void createOrders()
        {
            Order o = new Order("100");
            o.addItem("Soda", 2);
            o.addItem("Chips", 10);
            orders.AddFirst(o);

            o = new Order("200");
            o.addItem("Cake", 20);
            o.addItem("Cookies", 5);
            orders.AddLast(o);

            o = new Order("300");
            o.addItem("Burger", 8);
            o.addItem("Fries", 5);
            orders.AddLast(o);
        }
    }
}
