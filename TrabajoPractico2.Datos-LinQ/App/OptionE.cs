using Services;
using System;

namespace App
{
    public class OptionE
    {
        /// <summary>
        /// Inicia el menu correspondiente a la opcion E
        /// </summary>
        public void Start()
        {

            OrderController controller = new OrderController();
            int orderId;
            System.Console.WriteLine("Ingrese el ID de la orden que desea eliminar");

            do
            {
                int.TryParse(Console.ReadLine(), out orderId);
            } while (orderId == 0);

            var orderToRemove = controller.GetById(orderId);

            if (orderToRemove.ShipCountry == "Mexico" || orderToRemove.ShipCountry == "France")
            {
                Console.WriteLine($"No se puede eliminar la orden numero {orderToRemove.OrderID} por ser de {orderToRemove.ShipCountry}");
            }
            else
            {
                controller.RemoveOrder(orderId);
            }
        }
    }
}