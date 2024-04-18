using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;
            Console.WriteLine("Introduzca la opción que desee: ");
            Console.WriteLine("1. Comprar productos");
            Console.WriteLine("2. Mostrar la información del producto");
            Console.WriteLine("3. Carga individual del producto");
            Console.WriteLine("4. Carga completa de productos");
            Console.WriteLine("5. Salir");
            opcion = int.Parse(Console.ReadLine());

            switch(opcion) {
                case 1: // Comprar
                    break;
                case 2: // Información
                    break; 
                case 3: // Carga individual
                    break;
                case 4: // Carga completa
                    break;
                case 5: // Exit
                    break;
                default:
                    break;
            }
        }
    }
}
