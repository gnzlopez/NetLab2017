using Services;
using System;

namespace App
{
    public class OptionV
    {
        public void Start()
        {
            string op;
            do
            {
                Console.WriteLine("Que lista desea ver?\n" +
                    "A. Todas las orders\n" +
                    "B. El mayor cliente y el mayor producto por pais");
                op = Console.ReadLine().ToLower(); ;
            } while (op != "a" && op != "b");

            if (op == "a") ListAll(); else MaxForCountry();
        }

        private void MaxForCountry()
        {
            var orderControl = new OrderController();
            var customerControl = new CustomerController();
            var test = orderControl.MaxForCountry();

            foreach (var item in test)
            {
                Console.WriteLine($"Pais: {item.ShipCountry} Mayor cliente: {customerControl.GetName(item.CustomerID)}");
            }
            Console.ReadKey();
        }

        private void ListAll()
        {
            var orderList = new OrderController().GetAll();
            var orderDetailControl = new Order_DetailController();
            var customerControl = new CustomerController();

            Console.WriteLine("---------TODAS LAS ORDENES-------");
            foreach (var item in orderList)
            {
                Console.WriteLine($"Orden ID: {item.OrderID} " +
                    $" Cliente: {customerControl.GetName(item.CustomerID)} " +
                    $" Monto total: {orderDetailControl.GetTotalPrice(item.OrderID)}");
            }

            Console.ReadKey();
        }
    }
}