using System;
using System.Threading;
using System.Threading.Tasks;
using MicroPizza.Messages;
using Nimbus;
using Nimbus.Handlers;
using PaymentService.Messages;

namespace PaymentService.Handlers
{
    public class ProcessPaymentHandler : IHandleCommand<ProcessPaymentCommand>
    {
        private readonly IBus _bus;

        public ProcessPaymentHandler(IBus bus)
        {
            _bus = bus;
        }

        public async Task Handle(ProcessPaymentCommand busCommand)
        {

            Thread.Sleep(10000);

            var paymentSuccessfulEvent = new PaymentSuccessfulEvent {OrderId = busCommand.OrderId};
            _bus.Publish(paymentSuccessfulEvent);

        }
    }
}