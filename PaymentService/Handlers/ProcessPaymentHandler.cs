using System;
using System.Threading.Tasks;
using MicroPizza.Messages;
using Nimbus.Handlers;

namespace PaymentService.Handlers
{
    public class ProcessPaymentHandler : IHandleCommand<ProcessPaymentCommand>
    {
        public async Task Handle(ProcessPaymentCommand busCommand)
        {
            
            Console.WriteLine(busCommand.CardName);

        }
    }
}