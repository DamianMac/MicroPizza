using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DeliveryService
{
    public class OrderDatabase : IOrderDatabase
    {
        public OrderDatabase()
        {
            _slips = new Dictionary<Guid, DeliverySlip>();
        }

        private Dictionary<Guid, DeliverySlip> _slips;

        public void Add(DeliverySlip deliverySlip)
        {
            _slips.Add(deliverySlip.Id, deliverySlip);
            
        }

        public DeliverySlip Get(Guid id)
        {
            return _slips[id];
        }
 

    }
}