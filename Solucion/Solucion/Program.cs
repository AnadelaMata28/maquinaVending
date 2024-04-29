using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Solucion {
    internal class Program {
        static void Main(string[] args) {
            MaquinaVending maquinaVending = new MaquinaVending();
            int opcion = 0;
            do {

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

                switch (opcion) {
                    case 1:
                        maquinaVending.BuyProducts(); // Comprar
                        break;
                    case 2:
                        maquinaVending.ProductosDisponibles();
                        maquinaVending.ProductInfo(); // Información
                        break;
                    case 3:
                        if (ContrasenaValida()) 
                        {
                            maquinaVending.IndividualProductLoading();// Carga individua
                        }
                        else {
                            Console.WriteLine("Lo siento, la contraseña es incorrecta. Introduzca otra vez o seleccione otra opción.");
                        }
                        break;
                    case 4:
                        if (ContrasenaValida()) {
                            maquinaVending.FullProductLoading();// Carga completa
                        }
                        else {
                            Console.WriteLine("Lo siento, la contraseña es incorrecta. Introduzca otra vez o seleccione otra opción.");
                        }
                        break;
                    case 5:
                        maquinaVending.Exit(); // Exit
                        break;
                    default:
                        break;
                }
            } while (opcion != 5);
        }

        public static bool ContrasenaValida() {
            string contrasena = "admin";
            bool valido = false;

            Console.WriteLine("Introduzca la contraseña: ");
            string contrasenaIntroducida = Console.ReadLine();

            if (contrasenaIntroducida == contrasena) {
                valido = true;
            }

            return valido;
        }
    }
}