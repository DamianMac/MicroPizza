using System.Threading.Tasks;
using MicroPizza.Messages;
using Nimbus.Handlers;

namespace DeliveryService.Handlers
{
    public class ListenForNewOrders : IHandleMulticastEvent<NewPizzaOrderEvent>
    {
        private readonly IOrderDatabase _orderDatabase;

        public ListenForNewOrders(IOrderDatabase orderDatabase)
        {
            _orderDatabase = orderDatabase;
        }

        public async Task Handle(NewPizzaOrderEvent busEvent)
        {
            _orderDatabase.Add(new DeliverySlip{Id = busEvent.OrderId, LineItems = busEvent.LineItems, Customer = busEvent.CustomerName});
        }
    }
}