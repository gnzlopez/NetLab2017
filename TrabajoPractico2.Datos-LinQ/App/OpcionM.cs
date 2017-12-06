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
                if (controller.SaveChanges()) Console.WriteLine("Se modifico correctamente");
                else Console.WriteLine("Ha ocurrido algun problema. Vuelva a intentarlo.");
            }
            else
            {
                Console.WriteLine("No existe ninguna orden con ese ID");
            }
        }

        private OrderModel ModifyOrder(OrderModel orderToModify)
        {
            int op;
            bool keepOn = true;
            do
            {
                Console.WriteLine(
                    $"OrderID: {orderToModify.OrderID} " +
                    $"CustomerID = {orderToModify.CustomerID}" +
                    $". EmployeeID = {orderToModify.EmployeeID}\n" +
                    $"Que campo desea mofificar?\n" +
                    $"1. OrderDate = {orderToModify.OrderDate}\n" +
                    $"2. RequiredDate = {orderToModify.RequiredDate}\n" +
                    $"3. ShippedDate = {orderToModify.ShippedDate}\n" +
                    $"4. ShipVia = {orderToModify.ShipVia}\n" +
                    $"5. Freight = {orderToModify.Freight}\n" //+
                                                              //$"6. ShipName = {orderToModify.ShipName}\n" +
                                                              //$"7.ShipAddress = {orderToModify.ShipAddress}\n" +
                                                              //$"8.ShipCity = {orderToModify.ShipCity}\n" +
                                                              //$"9.ShipRegion = {orderToModify.ShipRegion}\n" +
                                                              //$"10.ShipPostalCode = {orderToModify.ShipPostalCode}\n" +
                                                              //$"11.ShipCountry = {orderToModify.ShipCountry}\n"
                    );
                do
                {
                    Console.WriteLine("Ingrese el numera de la opcion que desee modificar");
                    int.TryParse(Console.ReadLine(), out op);
                } while (op == 0 || op > 13);

                Console.WriteLine("Ingrese el nuevo valor");
                var newVal = Console.ReadLine();

                switch (op)
                {
                    case 1:
                        DateTime date;
                        if (!DateTime.TryParse(newVal, out date))
                        {
                            Console.WriteLine("No es una fecha valida. Vuelva a intentarlo");
                            break;
                        }
                        orderToModify.OrderDate = date;
                        Console.WriteLine("Valor actualizado");
                        break;
                    case 2:
                        if (!DateTime.TryParse(newVal, out date))
                        {
                            Console.WriteLine("No es una fecha valida. Vuelva a intentarlo");
                            break;
                        }
                        orderToModify.RequiredDate = date;
                        Console.WriteLine("Valor actualizado");
                        break;
                    case 3:
                        if (!DateTime.TryParse(newVal, out date))
                        {
                            Console.WriteLine("No es una fecha valida. Vuelva a intentarlo");
                            break;
                        }
                        orderToModify.ShippedDate = date;
                        Console.WriteLine("Valor actualizado");
                        break;
                    case 4:
                        int via;
                        int.TryParse(newVal, out via);

                        if (via < 1 || via > 3)
                        {
                            Console.WriteLine("No es un valor valido. Intente nuevamente");
                            break;
                        }
                        orderToModify.ShipVia = via;
                        Console.WriteLine("Valor actualizado");
                        break;
                    case 5:
                        decimal freight;
                        decimal.TryParse(newVal, out freight);

                        if (freight > 0.0m)
                        {
                            Console.WriteLine("No es un valor valido. Intente nuevamente");
                            break;
                        }
                        orderToModify.Freight = freight;
                        Console.WriteLine("Valor actualizado");
                        break;
                        //case 6:
                        //    break;
                        //case 7:
                        //    break;
                        //case 8:
                        //    break;
                }
                string resp;
                do
                {
                    Console.WriteLine("Desea seguir haciendo cambios? S/N");
                    resp = Console.ReadLine().ToLower();
                } while (resp != "n" && resp != "s");
                 keepOn = resp == "n" ? false : true;
                Console.Clear();
            } while (keepOn);
            return orderToModify;
        }
    }
}
