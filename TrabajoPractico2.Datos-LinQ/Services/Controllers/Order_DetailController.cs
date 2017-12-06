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



        //
        /// <summary>
        /// AGREGA UN DETAIL
        /// </summary>
        /// <param name="model"></param>
        public bool AddOrderDetail(ICollection<Order_DetailModel> detailList)
        {

            foreach (var model in detailList)
            {
                var newOrderDetail = new Order_Detail
                {
                    OrderID = model.OrderID,
                    ProductID = model.ProductID,
                    UnitPrice = model.UnitPrice,
                    Quantity = model.Quantity,
                    Discount = model.Discount,
                    //Order = repository.Set().FirstOrDefault(c => c.OrderID == model.OrderID).Order
                    //Product =
                    //new Repository<Product>().Set().FirstOrDefault(c => c.ProductID == model.ProductID)
                };

                repository.Persist(newOrderDetail);

            }
           return repository.SaveChanges();
        }

        /// <summary>
        /// BORRA TODAS LAS DETAILS DE UNA MISMA ORDER
        /// </summary>
        /// <param name="orderId"></param>
        public void RemoveOrderDetail(int orderId)
        {
            var orderDetailToRemove = repository
                .Set()
                .Where(c => c.OrderID == orderId)
                .AsEnumerable();

            foreach (var item in orderDetailToRemove)
            {
                repository.Remove(item);
            }
            repository.SaveChanges();
            
        }


        /// <summary>
        /// DEVUELVE TODOS LOS DETAILS DE UNA MISMA ORDER
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public IEnumerable<Order_DetailModel> GetAllByOrderId(int orderId)
        {
            var orderDetailList = repository
                .Set()
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


        /// <summary>
        /// DEVUELVE EL PRECIO TOTAL POR ID DE ORDER
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public decimal GetTotalPrice(int orderId)
        {   try
            {
                var totalPrice = repository
                    .Set()
                    .Where(c => c.OrderID == orderId)
                    .Sum(c => c.UnitPrice * c.Quantity);

                return totalPrice;

            } catch (InvalidOperationException)
            {
                return 0;
            }
        }

        
    }
}
