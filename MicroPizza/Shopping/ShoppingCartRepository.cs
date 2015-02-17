using System;
using System.Collections.Generic;

namespace MicroPizza.Shopping
{
    public interface IShoppingCartRepository
    {
        void AddOrder(PizzaOrder order);
        PizzaOrder Get(Guid id);
    }

    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private Dictionary<Guid, PizzaOrder> _orders; 
        public ShoppingCartRepository()
        {
            _orders = new Dictionary<Guid, PizzaOrder>();
        }

        public void AddOrder(PizzaOrder order)
        {
            _orders.Add(order.Id, order);
        }

        public PizzaOrder Get(Guid id)
        {
            return _orders[id];
        }

    }
}