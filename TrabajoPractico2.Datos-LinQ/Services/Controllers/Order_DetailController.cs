using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
   public  class Order_DetailController
    {
        Repository<Order_Detail> repository;

        public Order_DetailController()
        {
            repository = new Repository<Order_Detail>();
        }

        //AGREGA UN DETAIL
        public void AddOrderDetail(Order_DetailModel model)
        {
            var newOrderDetail = new Order_Detail
            {
                OrderID = model.OrderID,
                ProductID = model.ProductID,
                UnitPrice = model.UnitPrice,
                Quantity = model.Quantity,
                Discount = model.Discount,
                Order = repository.Set().FirstOrDefault(c => c.OrderID == model.OrderID).Order
                //Product =
                //new Repository<Product>().Set().FirstOrDefault(c => c.ProductID == model.ProductID)
            };

            repository.Persist(newOrderDetail);

            repository.SaveChanges();
        }

        //BORRA TODAS LAS DETAILS DE UNA MISMA ORDER
        public void RemoveOrderDetail(int orderId)
        {
            var orderDetailToRemove = repository
                .Set(/*new Order_Detail()*/)
                .Where(c => c.OrderID == orderId)
                .ToList();

            foreach (var item in orderDetailToRemove)
            {
                repository.Remove(item);
            }
            

            repository.SaveChanges();
        }
        

        //DEVUELVO TODOS LOS DETAILS DE UNA MISMA ORDER
        public IEnumerable<Order_DetailModel> GetAllByOrderId(int orderId)
        {
            var orderDetailList = repository
                .Set(/*new Order_Detail()*/)
                .Where(c => c.OrderID == orderId)
                .Select(c => new Order_DetailModel
                {
                    OrderID = c.OrderID,
                    ProductID = c.ProductID,
                    UnitPrice = c.UnitPrice,
                    Quantity = c.Quantity,
                    Discount = c.Discount
                })
                .AsEnumerable();

            return orderDetailList;
        }

        //

    }
}
