using System;
using Nimbus.MessageContracts;

namespace PaymentService.Messages
{
    public class PaymentSuccessfulEvent : IBusEvent
    {

        public Guid OrderId { get; set; }

         
    }
}