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
            if(producto == null)
            {
                return $"Error eligiendo producto";
            }
            return $"{producto.MostrarDetalles()}";
        }

        public void CargaCompletaProducto(int eleccion) //si eleccion es 0 se mete el archivo de inicio
        {
            char separator = ';';
            string path;
            if(eleccion == 0) {
                path = "..\\..\\..\\..\\Archivos\\example_vending_file_practical_work_i.csv"; //ruta del archivo
            }
            else
            {
                path = "..\\..\\..\\..\\Archivos\\archivo_vending.csv"; //ruta del archivo
            }

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

                        if (datos[0] == "1") 
                        {
                            MaterialesPreciosos mp = new MaterialesPreciosos(listaProductos.Count, datos[1], int.Parse(datos[2]), double.Parse(datos[3]), datos[4], datos[5], double.Parse(datos[6]));
                            listaProductos.Add(mp);
                        }
                        else if (datos[0] == "2")
                        {
                            ProductosAlimenticios pa = new ProductosAlimenticios(listaProductos.Count, datos[1], int.Parse(datos[2]), double.Parse(datos[3]), datos[4], datos[5]);
                            listaProductos.Add(pa);
                        }
                        else
                        {
                            bool datos1 = false;
                            bool datos2 = false;
                            if (datos[6] == "1")
                            {
                                datos1 = true;   
                            }
                            else if (datos[7] == "1")
                            {
                                datos2 = true;
                            }
                            ProductosElectronicos pe = new ProductosElectronicos(listaProductos.Count, datos[1], int.Parse(datos[2]), double.Parse(datos[3]), datos[4], datos[5], datos1, datos2);
                            listaProductos.Add(pe);
                        }
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