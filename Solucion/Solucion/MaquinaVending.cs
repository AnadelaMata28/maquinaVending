using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion
{
    internal class MaquinaVending
    {
        protected List<Producto> listaProductos;
        public MaquinaVending() { }
        public MaquinaVending(List<Producto> productos)
        {
            listaProductos = productos;
        }

        public void ComprarProducto()
        {
            int opcion = 0;
            double precioTotal = 0;
            Pagar pagar = new Pagar();
            Producto productoTemp = null;
            List<Producto> listaCompra = new List<Producto>();

            do
            {
                ProductosDisponibles();
                Console.WriteLine();
                Console.WriteLine("  --- Comprando productos ---  ");
                Console.WriteLine();

                productoTemp = ElegirProducto(listaProductos);

                Console.WriteLine(InfoProducto(productoTemp));

                precioTotal += productoTemp.PrecioUnitario;

                listaCompra.Add(productoTemp);

                if (productoTemp.Unidades == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Producto agotado");
                    precioTotal -= productoTemp.PrecioUnitario;
                    listaCompra.Remove(productoTemp);
                }

                else if (productoTemp.Unidades > 0)
                {
                    productoTemp.Unidades--;
                }

                Console.WriteLine();
                Console.WriteLine("Desea comprar algún otro producto?");
                Console.Write("En caso de no querer, pulse 0. Si desea comprar más, pulse 1: ");

                try
                {
                    opcion = int.Parse(Console.ReadLine());
                    if (opcion != 0 && opcion != 1)
                    {
                        throw new ArgumentException("Por favor ingrese un valor válido."); 
                    }
                }
                catch(ArgumentException e)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Error inesperado: {e.Message}"); 
                }
             
            } while (opcion == 1);

            Console.WriteLine("¿Desea cancelar la compra? (Si = 1 / No = 0)");
            int cancelar = int.Parse(Console.ReadLine());

            if (cancelar == 1)
            {
                foreach (Producto producto in listaCompra)
                {
                    producto.Unidades++;
                }
                Console.WriteLine("Has cancelado tu compra. Hasta la próxima!!");
                return;
            }


            Console.WriteLine("Método para pagar: ");
            Console.WriteLine("1. Efectivo");
            Console.WriteLine("2. Tarjeta");

            Console.WriteLine("Opción: ");
            int opcionPagar = int.Parse(Console.ReadLine());

            switch (opcionPagar)
            {
                case 1:
                    pagar.PagarEfectivo(precioTotal);
                    break;
                case 2:
                    pagar.PagarTarjeta(precioTotal);
                    break;
            }

            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }

        public string InfoProducto(Producto producto)
        {
            if (producto == null)
            {
                return $"Error eligiendo producto";
            }
            return $"{producto.MostrarDetalles(true)}";
        }

        public void CargaCompletaProducto(bool eleccion)
        {
            char separator = ';';
            string path;
            if (!eleccion)
            { //si eleccion es false se mete el archivo de inicio
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
                Console.WriteLine(producto.MostrarDetalles(false));
            }
        }
        public Producto ElegirProducto(List<Producto> listaProductos)
        {
            Producto productoTemp = null;

            try
            {
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