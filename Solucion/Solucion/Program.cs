using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Solucion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string contraseña = 'admin';

            int opcion = 0;
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("|           Máquina Vending UFV           |");
            Console.WriteLine("|-----------------------------------------|"); 
            Console.WriteLine("|  Opciones:                              |");
            Console.WriteLine("|-----------------------------------------|");
            Console.WriteLine("| 1. Comprar productos                    |");
            Console.WriteLine("| 2. Mostrar la información del producto  |");
            Console.WriteLine("| 3. Carga individual del producto        |");
            Console.WriteLine("| 4. Carga completa de productos          |");
            Console.WriteLine("| 5. Salir                                |");
            Console.WriteLine("|-----------------------------------------|");
            Console.WriteLine("| Introduzca la opción que desee realizar |");
            Console.WriteLine("------------------------------------------");
            opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        BuyProducts(); // Comprar
                        break;
                    case 2:
                        ProductInfo(int Id); // Información
                        break;
                    case 3:
                        if (ContrasenaValida())
                        {
                            IndividualProductLoading();// Carga individua
                        }
                        else
                        {
                            Console.WriteLine("La contraseña es incorrecta");
                        }
                        break;
                    case 4:
                        if (ContrasenaValida())
                        {
                            FullProductLoading();// Carga completa
                        }
                        else
                        {
                            Console.WriteLine("La contraseña es incorrecta");
                        }
                        break;
                    case 5:
                        Exit(); // Exit
                        break;
                    default:
                        break;
                }
            } while (option != 5);
           

        }

        public bool ContrasenaValida()
        {
            bool valido = false; 
            Console.WriteLine("Introduzca la contraseña: ");
            string contraseñaIntroducida = Console.ReadLine();
            if (contraseñaIntroducida == contraseña)
            {
                valido = true; 
            }
            return valido; 
        }
}
