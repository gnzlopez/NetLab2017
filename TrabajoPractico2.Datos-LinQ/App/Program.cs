
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {

            Menu menu = new Menu();

            menu.Start();
            //OrderController oc = new OrderController();
            //OrderModel om = new OrderModel();
            //om.CustomerID = "ANTON";
            //om.EmployeeID = 1;


            //Order_DetailController odc = new Order_DetailController();
            //Order_DetailModel odm = new Order_DetailModel();

            //odm.OrderID = 12087;
            //odm.ProductID = 1;
            //odm.UnitPrice = 18;
            //odm.Quantity = 1;
            //odm.Discount = 0;

            //odc.AddOrderDetail(odm);

            
            Console.ReadLine();

        }
    }
}
