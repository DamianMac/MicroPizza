using System.Threading.Tasks;
using DeliveryService.Messages;
using MicroPizza.Shopping;
using Nimbus.Handlers;

namespace MicroPizza.Handlers
{
    public class CompleteOrderHandler : IHandleMulticastEvent<OrderDeliveredEvent>
    {
        private readonly IShoppingCartRepository _repository;

        public CompleteOrderHandler(IShoppingCartRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(OrderDeliveredEvent busEvent)
        {

            var order = _repository.Get(busEvent.OrderId);

            order.Status = OrderStatus.Complete;
            


        }
    }
}