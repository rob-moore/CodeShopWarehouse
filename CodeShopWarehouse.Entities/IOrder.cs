using System;

namespace CodeShopWarehouse.Entities
{
    public interface IOrder
    {
        int Id { get; set; }
        bool Processed { get; set; }
        string ProductId { get; set; }
        int ProductStock { get; set; }
        OrderEnum OrderType { get; set; }
        DateTimeOffset? ProcessedDate { get; set; }
    }
}