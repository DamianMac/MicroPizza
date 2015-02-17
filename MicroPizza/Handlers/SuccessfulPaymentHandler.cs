using System.Threading.Tasks;
using MicroPizza.Shopping;
using Nimbus.Handlers;
using PaymentService.Messages;

namespace MicroPizza.Handlers
{
    public class SuccessfulPaymentHandler : IHandleMulticastEvent<PaymentSuccessfulEvent>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public SuccessfulPaymentHandler(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task Handle(PaymentSuccessfulEvent busEvent)
        {

            var order = _shoppingCartRepository.Get(busEvent.OrderId);

            order.Status = OrderStatus.Paid;


        }
    }
}