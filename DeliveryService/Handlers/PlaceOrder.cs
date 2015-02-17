using System.Threading;
using System.Threading.Tasks;
using DeliveryService.Messages;
using Nimbus;
using Nimbus.Handlers;
using Nimbus.MessageContracts;
using PaymentService.Messages;

namespace DeliveryService.Handlers
{
    public class PlaceOrder : IHandleMulticastEvent<PaymentSuccessfulEvent>
    {
        private readonly IOrderDatabase _database;
        private readonly IBus _bus;

        public PlaceOrder(IOrderDatabase database, IBus bus)
        {
            _database = database;
            _bus = bus;
        }

        public async Task Handle(PaymentSuccessfulEvent busEvent)
        {
            var delivery = _database.Get(busEvent.OrderId);

            Thread.Sleep(10000);

            var successEvent = new OrderDeliveredEvent {OrderId = busEvent.OrderId};


            _bus.Publish(successEvent);
        }
    }

    
}