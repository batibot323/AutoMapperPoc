using Models;
using System;

namespace Services
{
    public class OrdersService : IOrdersService
    {
        public Order GetOrder()
        {
            return new Order
            {
                DateTayo = DateTime.Now,
                Id = 13,
                NameBabyBoi = "Bea",
                PriceAwitSakit = 101
            };
        }
    }
}
