using System.Collections.Generic;
using CodeShopWarehouse.Entities;

namespace CodeShopWarehouse.Business
{
    public interface IOrdersService
    {
        List<IOrder> GetUnprocessedOrders();
        IOrder GetById(int id);
        IOrder ProcessOrder(IOrder order);
        IOrder CreateOrder(IOrder order);
        List<IOrder> GetByProductId(string id);
    }
}