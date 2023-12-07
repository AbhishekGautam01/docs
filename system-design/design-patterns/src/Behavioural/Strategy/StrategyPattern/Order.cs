using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern
{
    public class Order
    {

        private string id;

        private DateTime date;

        private Dictionary<string, double> items = new Dictionary<string, double>();

        private double total;

        public Order(string id)
        {
            this.id = id;
            date = DateTime.UtcNow;
        }

        public string getId()
        {
            return id;
        }

        public DateTime getDate()
        {
            return date;
        }

        public Dictionary<string, double> getItems()
        {
            return items;
        }

        public void addItem(string name, double price)
        {
            items.Add(name, price);
            total += price;
        }

        public double getTotal()
        {
            return total;
        }

        public void setTotal(double total)
        {
            this.total = total;
        }
    }
}
