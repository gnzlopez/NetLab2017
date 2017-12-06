
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

            do {
                Console.Clear();
            }while(menu.Start());

            
            Console.ReadLine();

        }
    }
}
