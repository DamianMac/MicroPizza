using System;
using System.Collections.Generic;

namespace MicroPizza.Shopping
{
    public class PizzaOrder
    {
        public PizzaOrder()
        {
            Id = Guid.NewGuid();
            LineItems = new List<string>();
            Status = OrderStatus.Pending;
        }

        public Guid Id { get; set; }

        public OrderStatus Status { get; set; }

        public List<string> LineItems { get; set; }
        public double Price { get; set; }

    }

    public enum OrderStatus
    {
        Pending, Paid, Complete
    }
}