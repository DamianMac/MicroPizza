using System;

namespace DeliveryService
{
    public interface IOrderDatabase
    {
        void Add(DeliverySlip deliverySlip);
        DeliverySlip Get(Guid id);
    }
}