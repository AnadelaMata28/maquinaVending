using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion {
    internal class MaquinaVending
    {

        List<Producto> listaProductos = new List<Producto>();

        public MaquinaVending() { }


        public void ComprarProducto()
        {
            double precioTotal = 0;
            Pagar pagar = null;
            Producto productoTemp = null;

            ProductosDisponibles();

            Console.WriteLine(InfoProducto());

            try
            {
                precioTotal += productoTemp.PrecioUnitario;

                int opcion = 0;
                Console.WriteLine("Desea comprar algún otro producto?");
                Console.Write("En caso de no querer, pulse 0. Si desea comprar más, pulse 1: ");
                opcion = int.Parse(Console.ReadLine());
                do
                {
                    switch (opcion)
                    {
                        case 0:
                            int option = 0;
                            do
                            {
                                Console.WriteLine("Método para pagar: ");
                                Console.WriteLine("1. Efectivo");
                                Console.WriteLine("2. Tarjeta");

                                switch (option)
                                {
                                    case 1:
                                        pagar.PagarEfectivo(precioTotal);
                                        break;
                                    case 2:
                                        pagar.PagarTarjeta(precioTotal);
                                        break;
                                }
                            } while (option != 2);

                            Salir();
                            break;
                        case 1:
                            Console.WriteLine("¿Desea cancelar la compra? (Si = 1 / No = 0)");
                            int respuesta = int.Parse(Console.ReadLine());
                            if (respuesta == 0)
                            {
                                ComprarProducto();
                            }

                            else if (respuesta == 1)
                            {
                                int option2 = 0;
                                do
                                {
                                    Console.WriteLine("Método para pagar: ");
                                    Console.WriteLine("1. Efectivo");
                                    Console.WriteLine("2. Tarjeta");

                                    switch (option2)
                                    {
                                        case 1:
                                            pagar.PagarEfectivo(precioTotal);
                                            break;
                                        case 2:
                                            pagar.PagarTarjeta(precioTotal);
                                            break;
                                    }
                                } while (option2 != 2);
                            }
                            Salir();
                            break;
                        default:
                            break;
                    }
                } while (opcion != 1);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Opción inválida. Por favor, ingrese un número válido.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }

        public string InfoProducto()
        {
            Producto producto = ElegirProducto(listaProductos);
            return $"{producto.MostrarDetalles()}";
        }

        public void CargaCompletaProducto()
        {
            char separator = ';';
            string path = "example_vending_file_practical_work_i.csv"; //ruta del archivo

            try //controlar excepciones
            {
                using (StreamReader archivo = File.OpenText(path)) //abrir el archivo
                {
                    string header = archivo.ReadLine(); 
                    string[] names = header.Split(separator);

                    string line;

                    while ((line = archivo.ReadLine()) != null)
                    {
                        string[] datos = line.Split(separator);
                        Producto nuevoProducto = new Producto(); //crear un nuevo producto para los datos leídos
                        nuevoProducto.Nombre = datos[0];  //asignamos el nombre del producto al primer elemento de array de datos
                        listaProductos.Add(nuevoProducto); //añadir producto a la lista
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("No se encuentra el archivo de usuarios: " + ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error de E/S" + ex.Message);
            }
        }

        public void CargaIndividualProducto()
        {
            Producto producto = new Producto();
            producto.AnadirProducto(listaProductos);
        }

        public void Salir()
        {
            Console.WriteLine("Muchas gracias por su compra!");
            Console.Clear();
        }

        public void ProductosDisponibles()
        {
            foreach (Producto producto in listaProductos)
            {
                Console.WriteLine(producto.MostrarDetalles());
            }
        }
        public Producto ElegirProducto(List<Producto> listaProductos)
        {
            try
            {
                Producto productoTemp = null;

                Console.WriteLine("Introduce el Id del producto que deseas: ");
                int id = int.Parse(Console.ReadLine());

                foreach (Producto producto in listaProductos)
                {
                    if (producto.Id == id)
                    {
                        productoTemp = producto;
                    }
                }

                return productoTemp;
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Opción inválida. Por favor, ingrese un número válido.");
                return null;
            }

        }
    }
}