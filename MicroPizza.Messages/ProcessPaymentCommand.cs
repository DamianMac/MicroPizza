using System;
using Nimbus.MessageContracts;

namespace MicroPizza.Messages
{
    public class ProcessPaymentCommand : IBusCommand
    {

        public Guid OrderId { get; set; }
        public double Amount { get; set; }
        public string CardName { get; set; }

         
    }
}