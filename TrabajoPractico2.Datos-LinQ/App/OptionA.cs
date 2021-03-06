﻿using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class OptionA
    {
        OrderController controller = new OrderController();
        /// <summary>
        /// Inicia el formulario para agregar una Order y envia a agregar el resultado
        /// </summary>
        public void Start()
        {
            OrderModel orderToAdd = new OrderModel();
            


            do
            {
                Console.WriteLine("Ingrese ID del Cliente");
                orderToAdd.CustomerID = Console.ReadLine();

            } while (!(new CustomerController().Exist(orderToAdd.CustomerID)));


            do
            {
                var employeeController = new EmployeeController();

                Console.WriteLine("Ingrese el nombre del Empleado");
                var employeeFirstName = Console.ReadLine();

                Console.WriteLine("Ingrese el apellido del Empleado");
                var employeeLastName = Console.ReadLine();

                orderToAdd.EmployeeID = employeeController.IdByName(employeeFirstName, employeeLastName);

            } while (orderToAdd.EmployeeID == 0);

            DateTime date;
            do
            {

                Console.WriteLine("Ingrese la fecha de pedido (dd-mm-AAAA)");
                if (!DateTime.TryParse(Console.ReadLine(), out date))
                    continue;
                orderToAdd.OrderDate = date;

                Console.WriteLine("Ingrese la fecha de llegada (dd-mm-AAAA)");
                if (!DateTime.TryParse(Console.ReadLine(), out date)) continue;
                orderToAdd.RequiredDate = date;

                Console.WriteLine("Ingrese la fecha de envio (dd-mm-AAAA)");
                if (!DateTime.TryParse(Console.ReadLine(), out date)) continue;
                orderToAdd.ShippedDate = date;

            } while (date == new DateTime());

            do
            {
                var idShip = 0;
                Console.WriteLine("Ingrese el ID de la via de envio (1-2-3)");
                int.TryParse(Console.ReadLine(), out idShip);
                orderToAdd.ShipVia = idShip;
            } while (orderToAdd.ShipVia < 1 || orderToAdd.ShipVia > 3);

            do
            {
                decimal freight;
                Console.WriteLine("Ingrese el costo del envio");
                decimal.TryParse(Console.ReadLine(), out freight);
                orderToAdd.Freight = freight;
            } while (orderToAdd.Freight < 0.0m);


            Console.WriteLine("Ingrese el nombre del envio");
            orderToAdd.ShipName = Console.ReadLine();

            Console.WriteLine("Ingrese la direccion de envio");
            orderToAdd.ShipAddress = Console.ReadLine();

            Console.WriteLine("Ingrese la ciudad de envio");
            orderToAdd.ShipCity = Console.ReadLine();

            Console.WriteLine("Ingrese la region de envio");
            orderToAdd.ShipRegion = Console.ReadLine();

            Console.WriteLine("Ingrese el codigo postal");
            orderToAdd.ShipPostalCode = Console.ReadLine();

            Console.WriteLine("Ingrese el pais");
            orderToAdd.ShipCountry = Console.ReadLine();

            orderToAdd.OrderID = controller.AddOrder(orderToAdd);

            AddDetails(orderToAdd.OrderID);
            
        }

        /// <summary>
        /// Realiza el formulario para agregar una OrderDetail y envia a agregar el resultado
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public void AddDetails(int orderId)
        {
            var seguir = true;
            decimal total = 0;
            Order_DetailController detailController = new Order_DetailController();
            ICollection<Order_DetailModel> orderDetailsList = new List<Order_DetailModel>();

            do
            {
                Order_DetailModel detailToAdd = new Order_DetailModel();

                detailToAdd.OrderID = orderId;
                do
                {
                    ProductModel product ;
                    ProductController productController = new ProductController();
                    Console.WriteLine("Ingrese el nombre del producto");
                    var productName = Console.ReadLine();
                    if (productName != "")
                        product = productController.GetByName(productName);
                    else continue;

                    detailToAdd.ProductID = product.ProductID;
                    detailToAdd.UnitPrice = (decimal)product.UnitPrice;

                } while (detailToAdd.ProductID == 0);


                do
                {
                    Console.WriteLine("Ingrese la cantidad");
                    short x;
                    short.TryParse(Console.ReadLine(), out x);
                    detailToAdd.Quantity = x;
                } while (detailToAdd.Quantity <= 0);

                do
                {
                    float x;
                    Console.WriteLine("Ingrese el descuento(%)");
                    float.TryParse(Console.ReadLine(), out x);
                    detailToAdd.Discount = x/100;
                } while (detailToAdd.Discount < 0.0f || detailToAdd.Discount > 0.30f);

                orderDetailsList.Add(detailToAdd);
                total = total + (detailToAdd.UnitPrice * detailToAdd.Quantity * decimal.Parse(detailToAdd.Discount.ToString()));
                Console.WriteLine("Detalle agregado. Desea agregar otro? (Y/N)");
                if (Console.ReadLine().ToLower() == "n") { seguir = false; }

            } while (seguir);

            var b = detailController.AddOrderDetail(orderDetailsList);

            if (b)
                Console.WriteLine($"Orden ID: {orderId} con importe {total} se ha creado correctamente");
            else Console.WriteLine("Ha ocurido un problema y no se realizo ningun cambio. \n Intente nuevamente");

            Console.ReadKey();


        }
    }
}