using System;
using System.Collections.Generic;
using Nimbus.MessageContracts;

namespace MicroPizza.Messages
{
    public class NewPizzaOrderEvent : IBusEvent
    {

        public Guid OrderId { get; set; }
        public string CustomerName { get; set; }
        public List<String> LineItems { get; set; }


        
    }
}