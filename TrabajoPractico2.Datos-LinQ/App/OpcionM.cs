using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class OpcionM
    {
        /// <summary>
        /// Inicia el MENU correspondiente a la opcion M
        /// </summary>
        public void Start()
        {
            OrderController controller = new OrderController();
            int orderId;
            System.Console.WriteLine("Ingrese el ID de la orden que desea modificar");

            do
            {
                int.TryParse(Console.ReadLine(), out orderId);
            } while (orderId == 0);

            var orderToModify = controller.GetById(orderId);

            if (orderToModify.Item1)
            {
                var orderModified = ModifyOrder(orderToModify.Item2);
                controller.UpdateOrder(orderModified);
                controller.SaveChanges();
            }
            else
            {
                Console.WriteLine("No existe ninguna orden con ese ID");
            }
        }

        private OrderModel ModifyOrder(OrderModel orderToModify)
        {
            int op;
            bool keepOn;
            Console.WriteLine($"Que campo desea mofificar?\n" +
                $"2. CustomerID = {orderToModify.CustomerID}\n" +
                $"3. EmployeeID = {orderToModify.EmployeeID}\n" +
                $"4. OrderDate = {orderToModify.OrderDate}\n" +
                $"5. RequiredDate = {orderToModify.RequiredDate}\n" +
                $"6. ShippedDate = {orderToModify.ShippedDate}\n" +
                $"7. ShipVia = {orderToModify.ShipVia}\n" +
                $"8. Freight = {orderToModify.Freight}\n" //+
                //$"9. ShipName = {orderToModify.ShipName}\n" +
                //$"10.ShipAddress = {orderToModify.ShipAddress}\n" +
                //$"11.ShipCity = {orderToModify.ShipCity}\n" +
                //$"12.ShipRegion = {orderToModify.ShipRegion}\n" +
                //$"13.ShipPostalCode = {orderToModify.ShipPostalCode}\n" +
                //$"14.ShipCountry = {orderToModify.ShipCountry}\n"
                );
            do
            {
                Console.WriteLine("Ingrese el numera de la opcion que desee modificar");
                int.TryParse(Console.ReadLine(), out op);
            } while (op == 0 || op > 14);

            Console.WriteLine("Ingrese el nuevo valor");
            var newVal = Console.ReadLine();

            switch (op)
            {
                case :
                    break;
                case :
                    break;
                case :
                    break;
                case :
                    break;
                case :
                    break;
                case :
                    break;
                case :
                    break;
                case :
                    break;
            }
        }
    }
}
