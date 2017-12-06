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
            if (orderToRemove.Item1)
            {
                if (orderToRemove.Item2.ShipCountry == "Mexico" || orderToRemove.Item2.ShipCountry == "France")
                {
                    Console.WriteLine($"No se puede eliminar la orden numero {orderId} por ser de {orderToRemove.Item2.ShipCountry}");
                }
                else
                {
                    controller.RemoveOrder(orderId);
                    controller.SaveChanges();
                    Console.WriteLine($"Orden numero {orderId} eliminada correctamente");
                }
            }
            else
                Console.WriteLine("No existe ninguna orden con ese ID");
        }
    }
}