using System;
using System.IO; 
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Solucion {
    internal class Program {
        static void Main(string[] args) {
            MaquinaVending maquinaVending = new MaquinaVending();
            maquinaVending.CargaCompletaProducto(0);
            /*char separator = ';';
            string archivoInicial = "example_vending_file_practical_work_i.csv";
            if (File.Exists(archivoInicial))
            {
                try
                {
                    string[] lineas = File.ReadAllLines(archivoInicial); //Leer las lineas del archivo

                    foreach (string line in lineas)
                    {

                        string[] datos = line.Split(separator);
                        string id = datos[0];
                        string nombre = datos[1];
                        int unidades = int.Parse(datos[2]);
                        double precioUnitario = double.Parse(datos[3]);
                        string descripcion = datos[4];

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al leer el archivo: {ex.Message}");   
                }
            }
            else
            {
                Console.WriteLine("El archivo no existe"); 
            }*/

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

                /*try
                {*/
                    opcion = int.Parse(Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:
                            maquinaVending.ComprarProducto(); // Comprar
                            break;
                        case 2:
                            maquinaVending.ProductosDisponibles();
                            maquinaVending.InfoProducto(); // Información
                            break;
                        case 3:
                            if (ContrasenaValida()) //HAY QUE HACER EL MÉTODO
                            {
                                maquinaVending.CargaIndividualProducto();// Carga individua
                            }
                            else
                            {
                                Console.WriteLine("Lo siento, la contraseña es incorrecta. Introduzca otra vez o seleccione otra opción.");
                            }
                            break;
                        case 4:
                            if (ContrasenaValida())
                            {
                                maquinaVending.CargaCompletaProducto(1);// Carga completa
                            }
                            else
                            {
                                Console.WriteLine("Lo siento, la contraseña es incorrecta. Introduzca otra vez o seleccione otra opción.");
                            }
                            break;
                        case 5:
                            maquinaVending.Salir(); // Exit
                            break;
                        default:
                            break;
                    }
               // }
                /*catch (FormatException)
                {
                    Console.WriteLine("Error: Opción inválida. Por favor, ingrese un número válido.");
                }*/
                /*catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }*/
                Console.WriteLine("Presiona una tecla para continuar...");
                Console.ReadKey();
                Console.Clear(); 

            } while (opcion != 5);
        }

        public static bool ContrasenaValida() {
            try
            {
                string contrasena = "admin";
                bool valido = false;

                Console.WriteLine("Introduzca la contraseña: ");
                string contrasenaIntroducida = Console.ReadLine();

                if (contrasenaIntroducida == contrasena)
                {
                    valido = true;
                }

                return valido;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                return false; 
            }
        }
    }
}