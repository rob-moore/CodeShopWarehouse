using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CodeShopWarehouse.Entities;

namespace CodeShopWarehouse.Data
{
    public class OrdersRepo : IOrdersRepo
    {

        public IOrder GetOrderById(int id)
        {
            var target = FakeData.FakeOrders.Find(x => x.Id == id);
            return target;
        }

        public IOrder UpdateOrder(IOrder o)
        {
            var orderToUpdate = FakeData.FakeOrders.First(x => x.Id == o.Id);
            orderToUpdate.Processed = true;
            orderToUpdate.ProcessedDate = DateTimeOffset.Now;
            return orderToUpdate;

        }

        public IOrder CreateOrder(IOrder data)
        {
            var order = new Order()
            {
                Id = data.Id,
                OrderType = data.OrderType,
                Processed = false,
                ProductId = Guid.NewGuid().ToString(),
                ProductStock = data.ProductStock 
            };
            FakeData.FakeOrders.Add(order);

            return order;
        }

        public List<IOrder> GetUnProcessedOrders()
        {
            if (FakeData.FakeOrders.Count == 0) 
            {
                for (int i = 1; i < 20; i++)
                {
                    FakeData.FakeOrders.Add(PopulateDatabase(i));
                }

                return FakeData.FakeOrders;
            }
         
            return FakeData.FakeOrders;
        }

        private IOrder PopulateDatabase(int id)
        {
            return new Order()
            {
                Id = id,
                OrderType = OrderEnum.Add,
                Processed = false,
                ProductId = Guid.NewGuid().ToString(),
                ProductStock = 20
            };
        }

        public List<IOrder> GetOrdersByProductId(string productId)
        {
            var target = FakeData.FakeOrders.Where(x => x.ProductId == productId).ToList();
            return target;
        }
    }
}