using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class Menu
    {
        public bool Start() {
            Console.WriteLine("Ingrese una opcion " +
                "\n A - Agregar " +
                "\n E - Eliminar " +
                "\n M - Modificar " +
                "\n V - Ver " +
                "\n F - Fin");

            var option = Console.ReadLine().ToLower();
            switch (option)
            {
                case "a":
                    var optionA = new OptionA();
                    optionA.Start();
                    break;
                case "e":
                    var optionE = new OptionE();
                    optionE.Start();
                    break;
                case "m":
                    var optionM = new OpcionM();
                    optionM.Start();
                    break;
                case "v":
                    var optionV = new OptionV();
                    optionV.Start();
                    break;
                case "f":
                    Console.WriteLine("Fin. Hasta luego");
                    return false;
                default:
                    Console.WriteLine("Opcion no valida");
                    Console.ReadKey();
                    break;
            }

            return true;
        }
         
        
    }
}
