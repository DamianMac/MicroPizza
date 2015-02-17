using System;
using System.Collections.Generic;

namespace DeliveryService
{
    public class DeliverySlip
    {
        public Guid Id { get; set; }
        public List<string> LineItems { get; set; }
        public string Customer { get; set; }

    }
}