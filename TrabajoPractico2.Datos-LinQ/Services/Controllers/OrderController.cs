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

        /// <summary>
        ///  INGRESAR UNA ORDER Y DEVUELVE EL ID AUTOGENERADO DE LA MISMA
        /// </summary>
       public int AddOrder(OrderModel model)
        {
            var newOrder = Mapper(new Order(), model);

            repository.Persist(newOrder);

            if (!repository.SaveChanges()) Console.WriteLine("Ha ocurrido un problema, intentelo nuevamente");

            return newOrder.OrderID;
        }

        //
        /// <summary>
        /// BORRAR UNA ORDER MEDIANTE SU ID
        /// </summary>
        /// <param name="orderId"></param>
        public void RemoveOrder(int orderId)
        {

            var deleteDetails = new Order_DetailController();
            deleteDetails.RemoveOrderDetail(orderId);

            var orderToRemove = repository
                .Set()
                .FirstOrDefault(c => c.OrderID == orderId);
            repository.Remove(orderToRemove);


        }

        //
        /// <summary>
        /// MODIFICAR UNA ORDER
        /// </summary>
        /// <param name="model"></param>
        public void UpdateOrder(OrderModel model)
        {
            var orderToUpdate = repository
                .Set()
                .FirstOrDefault(o => o.OrderID == model.OrderID);

            Mapper(orderToUpdate, model);

            repository.Update(orderToUpdate);
            repository.SaveChanges();
        }

        /// <summary>
        /// BUSCA UNA ORDER POR SU ID Y DEVUELVE COMO PRIMER ITEM SI EXISTE Y COMO SEGUNDO SU MODEL
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
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




        /// <summary>
        /// TRAE TODAS LAS ORDERS
        /// </summary>
        /// <returns></returns>
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
        public Order Mapper(Order o, OrderModel m)
        {
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

