using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class OptionA
    {

        /// <summary>
        /// Inicia el formulario para agregar una Order y envia a agregar el resultado
        /// </summary>
        public void Start()
        {
            OrderModel orderToAdd = new OrderModel();
            OrderController controller = new OrderController();


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

            Console.WriteLine("Ingrese la fecha de pedido (dd-mm-AAAA)");
            orderToAdd.OrderDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la fecha de llegada (dd-mm-AAAA)");
            orderToAdd.RequiredDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la fecha de envio (dd-mm-AAAA)");
            orderToAdd.ShippedDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el ID de la via de envio (1-2-3)");
            orderToAdd.ShipVia = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el costo del envio");
                orderToAdd.Freight = decimal.Parse(Console.ReadLine());

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
            var totalPrice = AddDetails(orderToAdd.OrderID);

            controller.SaveChanges();
            Console.WriteLine($"Orden ID: {orderToAdd.OrderID} con importe {totalPrice} se ha creado correctamente");
        }

        /// <summary>
        /// Realiza el formulario para agregar una OrderDetail y envia a agregar el resultaro
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public decimal AddDetails(int orderId)
        {
            var seguir = true;
            decimal total = 0;
            Order_DetailController detailController = new Order_DetailController();
            //ICollection<Order_DetailModel> orderDetailsList = new List<Order_DetailModel>();

            do
            {
                Order_DetailModel detailToAdd = new Order_DetailModel();

                detailToAdd.OrderID = orderId;
                do
                {
                    ProductController productController = new ProductController();
                    Console.WriteLine("Ingrese el nombre del producto");
                    var productName = Console.ReadLine();
                    var product = productController.GetByName(productName);

                    detailToAdd.ProductID = product.ProductID;
                    detailToAdd.UnitPrice = (decimal)product.UnitPrice;

                } while (detailToAdd.ProductID == 0);


                do
                {
                    Console.WriteLine("Ingrese la cantidad");
                    short x;
                    short.TryParse(Console.ReadLine(), out x);
                    detailToAdd.Quantity = x;
                } while (detailToAdd.Quantity == 0);

                do
                {
                    float x;
                    Console.WriteLine("Ingrese el descuento");
                    float.TryParse(Console.ReadLine(), out x);
                    detailToAdd.Discount = x;
                } while (detailToAdd.Discount < 0 || detailToAdd.Discount > 30);

                detailController.AddOrderDetail(detailToAdd);
               total = total + (detailToAdd.UnitPrice * detailToAdd.Quantity);
                Console.WriteLine("Detalle agregado. Desea agregar otro? (Y/N)");
                if (Console.ReadLine().ToLower() == "n") { seguir = false; }

            } while (seguir);


            return total;

        }
    }
}