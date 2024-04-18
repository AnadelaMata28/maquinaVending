using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion
{
    internal class Producto
    {
        public int Id { get; set; }

        public string Nombre {  get; set; }

        public int Unidades { get; set; }

        public double PrecioUnitario { get; set; }

        public string Descripcion { get; set; }

        public Producto() { }

        public Producto(string nombre, int unidades, double precioUnitario, string descripcion)
        {
            Nombre = nombre;
            Unidades = unidades;
            PrecioUnitario = precioUnitario;
            Descripcion = descripcion;
        }

        public virtual string MostrarDetalles()
        {
            return $"Nombre: {Nombre}\n\tUnidades: {Unidades}\n\tPrecio unitario: {PrecioUnitario}\n\tDescripción: {Descripcion}";
        }

        public Producto ElegirProducto(List <Producto> listaProductos)
        {
            Producto productoTemp = null;

            Console.WriteLine("Introuce el Id del producto que deseas: ");
            int id = int.Parse(Console.ReadLine());

            foreach(Producto producto in listaProductos)
            {
                if(producto.Id == id)
                {
                    productoTemp = producto;
                }
            }

            return productoTemp;
        }

        public void AddProducto(List <Producto> listaProductos)
        {
            int opcion = 0;
            do
            {
                Console.Clear();

                Console.WriteLine("Introduce el tipo de producto que deseas añadir: ");

                Console.WriteLine("1. Materiales preciosos");
                Console.WriteLine("2. Productos alimenticios");
                Console.WriteLine("3. Productos electrónicos");
                Console.WriteLine("4. Salir");

                Console.Write("Opción: ");
                try
                {
                    opcion = int.Parse(Console.ReadLine());
                    Console.Clear();

                    bool existe = false;
                    Producto productoTemp = null;

                    Console.WriteLine("Introduce el nombre del producto: ");
                    string nombre = Console.ReadLine();

                    foreach (Producto producto in listaProductos)
                    {
                        if (producto.Nombre == nombre)
                        {
                            productoTemp = producto;
                            existe = true;
                        }
                    }
                    if (!existe)
                    {
                        Console.WriteLine("Introduce las unidades del producto: ");
                        string unidades = Console.ReadLine();
                        Console.WriteLine("Introduce el precio del producto: ");
                        string precioUnitario = Console.ReadLine();
                        Console.WriteLine("Introduce la descripción del producto: ");
                        string descripción = Console.ReadLine();

                        switch (opcion)
                        {
                            case 1:
                                Console.WriteLine("Introduce el tipo de material del producto: ");
                                string tipoMaterial = Console.ReadLine();
                                Console.WriteLine("Introduce el peso del producto: ");
                                string peso = Console.ReadLine();

                                MaterialesPreciosos producto = new MaterialesPreciosos(listaProductos.Count, nombre, unidades, precioUnitario, descripción, tipoMaterial, peso);
                                break;
                            case 2:
                                Console.WriteLine("Introduce la información nutricional del producto: ");
                                string infoNutricional = Console.ReadLine();

                                ProductosAlimenticios producto = new ProductosAlimenticios(listaProductos.Count, nombre, unidades, precioUnitario, descripción, infoNutricional);
                                break;
                            case 3:
                                Console.WriteLine("Introduce los tipos de materiales del producto: ");
                                string tiposMateriales = Console.ReadLine();
                                Console.WriteLine("Introduce si el producto tiene pilas (SI-1 / NO-0): ");
                                bool pilas = bool.Parse(Console.ReadLine());
                                Console.WriteLine("Introduce si el producto está precargado (SI-1 / NO-0): ");
                                bool precargado = bool.Parse(Console.ReadLine());

                                ProductosElectronicos producto = new ProductosElectronicos(listaProductos.Count, nombre, unidades, precioUnitario, descripción, tiposMateriales, pilas, precargado);
                                break; ;
                            case 4: //Salir
                                Console.WriteLine("Saliendo...");
                                break;
                            default:
                                Console.WriteLine("Opción no válida");
                                break;
                        }
                    }
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

            } while (opcion != 4);
            Console.ReadKey ();
        }
    }
}
