using System;
using System.Collections;

namespace CodeShopWarehouse.Entities
{
    public class Order: IOrder
    {
        public int Id { get; set; }
        public bool Processed { get; set; }
        public string ProductId { get; set; }
        public int ProductStock { get; set; }
        public OrderEnum OrderType { get; set; }
        public DateTimeOffset? ProcessedDate { get; set; }
    }
}