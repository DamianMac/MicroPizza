using System;
using Nimbus.MessageContracts;

namespace DeliveryService.Messages
{
    public class OrderDeliveredEvent : IBusEvent
    {

        public Guid OrderId { get; set; }
    }
}