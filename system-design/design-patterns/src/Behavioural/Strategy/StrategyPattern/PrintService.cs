using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern
{
    public class PrintService
    {
        private readonly IOrderPrinter _orderPrinter;
        public PrintService(IOrderPrinter orderPrinter)
        {
            _orderPrinter = orderPrinter;
        }

        public void printOrders(LinkedList<Order> orders)
        {
            _orderPrinter.Print(orders);
        }
    }
}
