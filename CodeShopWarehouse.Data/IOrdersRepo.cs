using System.Collections.Generic;
using CodeShopWarehouse.Entities;

namespace CodeShopWarehouse.Data
 {
     public interface IOrdersRepo 
     {
         IOrder GetOrderById(int id);
         IOrder UpdateOrder(IOrder o);
         IOrder CreateOrder(IOrder data);
         List<IOrder> GetUnProcessedOrders();
     }
 }