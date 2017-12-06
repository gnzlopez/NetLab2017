using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderController
    {
        Repository<Order> repository;

        public OrderController()
        {
            repository = new Repository<Order>();
        }

        //INGRESAR UNA ORDER Y DEVUELVE EL ID AUTOGENERADO DE LA MISMA
        public int AddOrder(OrderModel model)
        {
            var newOrder = Mapper(model);

            repository.Persist(newOrder);

            if (!repository.SaveChanges()) Console.WriteLine("Ha ocurrido un problema, intentelo nuevamente");

            return newOrder.OrderID;
        }

        //BORRAR UNA ORDER
        public void RemoveOrder(int orderId)
        {

            var deleteDetails = new Order_DetailController();
            deleteDetails.RemoveOrderDetail(orderId);

            var orderToRemove = repository
                .Set()
                .FirstOrDefault(c => c.OrderID == orderId);
            repository.Remove(orderToRemove);


        }

        //MODIFICAR UNA ORDER
        public void UpdateOrder(int orderId, OrderModel model)
        {
            var orderToUpdate = repository
                .Set()
                .FirstOrDefault(o => o.OrderID == orderId);

            orderToUpdate = Mapper(model);

            repository.Update(orderToUpdate);

            // repository.SaveChanges();
        }

        //TRAER UNA ORDER POR ID
        public Tuple<bool, OrderModel> GetById(int orderId)
        {

            var order = repository
                .Set()
                .FirstOrDefault(o => o.OrderID == orderId);

            if (order != null)
            {
                var orderModel = Mapper(order);
                return Tuple.Create(true, orderModel);
            }

            return Tuple.Create(false, new OrderModel());
        }




        //TRAER TODAS LAS ORDERS
        public IEnumerable<OrderModel> GetAll()
        {
            var allOrders = repository
                .Set()
                .AsEnumerable()
                .Select(c => Mapper(c));

            return allOrders;
        }


        //GUARDA LOS CAMBIOS
        public bool SaveChanges()
        {
            var test = repository.SaveChanges();
            return test;
        }


        /// <summary>
        /// Mapeo de Model a Entidad Order
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public Order Mapper(OrderModel m)
        {
            var o = new Order();
            o.OrderID = m.OrderID;
            o.CustomerID = m.CustomerID;
            o.EmployeeID = m.EmployeeID;
            o.OrderDate = m.OrderDate;
            o.RequiredDate = m.RequiredDate;
            o.ShippedDate = m.ShippedDate;
            o.ShipVia = m.ShipVia;
            o.Freight = m.Freight;
            o.ShipName = m.ShipName;
            o.ShipAddress = m.ShipAddress;
            o.ShipCity = m.ShipCity;
            o.ShipRegion = m.ShipRegion;
            o.ShipPostalCode = m.ShipPostalCode;
            o.ShipCountry = m.ShipCountry;
            o.Customer = m.Customer;
            o.Employee = m.Employee;
            o.Shipper = m.Shipper;

            return o;
        }

        /// <summary>
        /// Mapeo de Entidad Order a Model
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public OrderModel Mapper(Order m)
        {
            var o = new OrderModel();
            o.OrderID = m.OrderID;
            o.CustomerID = m.CustomerID;
            o.EmployeeID = m.EmployeeID;
            o.OrderDate = m.OrderDate;
            o.RequiredDate = m.RequiredDate;
            o.ShippedDate = m.ShippedDate;
            o.ShipVia = m.ShipVia;
            o.Freight = m.Freight;
            o.ShipName = m.ShipName;
            o.ShipAddress = m.ShipAddress;
            o.ShipCity = m.ShipCity;
            o.ShipRegion = m.ShipRegion;
            o.ShipPostalCode = m.ShipPostalCode;
            o.ShipCountry = m.ShipCountry;
            o.Customer = m.Customer;
            o.Employee = m.Employee;
            o.Shipper = m.Shipper;

            return o;
        }
    }
}

