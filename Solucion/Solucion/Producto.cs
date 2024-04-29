using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion
{
    internal class Producto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int Unidades { get; set; }

        public double PrecioUnitario { get; set; }

        public string Descripcion { get; set; }

        public Producto() { }

        public Producto(int id, string nombre, int unidades, double precioUnitario, string descripcion)
        {
            Id = id + 1;
            Nombre = nombre;
            Unidades = unidades;
            PrecioUnitario = precioUnitario;
            Descripcion = descripcion;
        }

        public virtual string MostrarDetalles(bool eleccion)
        {
            return $"\n\tId: {Id}\n\tNombre: {Nombre}\n\tUnidades: {Unidades}\n\tPrecio unitario: {PrecioUnitario}\n\tDescripción: {Descripcion}";
        }

        public void AnadirProducto(List<Producto> listaProductos)
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

                    if (listaProductos == null)
                    {
                        listaProductos = new List<Producto>();
                    }

                    switch (opcion)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("  --- Solicitando detalles ---  ");
                            Console.WriteLine();
                            Console.Write("Introduce el nombre del producto: ");
                            string nombre = Console.ReadLine();

                            Producto productoTemp = ExisteProducto(listaProductos, nombre);

                            if (productoTemp != null)
                            {
                                AnadirUnidades(productoTemp);
                            }
                            else
                            {
                                MaterialesPreciosos mp = new MaterialesPreciosos(listaProductos.Count);
                                mp.SolicitarDetalles(listaProductos);
                                mp.Nombre = nombre;
                                listaProductos.Add(mp);
                            }
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("  --- Solicitando detalles ---  ");
                            Console.WriteLine();
                            Console.Write("Introduce el nombre del producto: ");
                            string nombre1 = Console.ReadLine();

                            Producto productoTemp1 = ExisteProducto(listaProductos, nombre1);
                            if (productoTemp1 != null)
                            {
                                AnadirUnidades(productoTemp1);
                            }
                            else
                            {
                                ProductosAlimenticios pa = new ProductosAlimenticios(listaProductos.Count);
                                pa.SolicitarDetalles(listaProductos);
                                pa.Nombre = nombre1;
                                listaProductos.Add(pa);
                            }
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("  --- Solicitando detalles ---  ");
                            Console.WriteLine();
                            Console.Write("Introduce el nombre del producto: ");
                            string nombre2 = Console.ReadLine();

                            Producto productoTemp2 = ExisteProducto(listaProductos, nombre2);
                            if (productoTemp2 != null)
                            {
                                AnadirUnidades(productoTemp2);
                            }
                            else
                            {
                                ProductosElectronicos pe = new ProductosElectronicos(listaProductos.Count);
                                pe.SolicitarDetalles(listaProductos);
                                pe.Nombre = nombre2;
                                listaProductos.Add(pe);
                            }
                            break; ;
                        case 4: //Salir
                            Console.WriteLine("Saliendo...");
                            break;
                        default:
                            Console.WriteLine("Opción no válida");
                            break;
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

            } while (opcion != 4);
        }

        public virtual void SolicitarDetalles(List<Producto> listaProductos)
        {
            Console.Write("Unidades: ");
            Unidades = int.Parse(Console.ReadLine());
            Console.Write("Precio unitario (en euros): ");
            PrecioUnitario = int.Parse(Console.ReadLine());
            Console.Write("Descripción: ");
            Descripcion = Console.ReadLine();
        }
        public Producto ExisteProducto(List<Producto> listaProductos, string nombre)
        {
            Producto productoTemp = null;

            if (listaProductos != null)
            {

                foreach (Producto producto in listaProductos)
                {
                    if (producto.Nombre == nombre)
                    {
                        productoTemp = producto;
                        return productoTemp = producto;
                    }
                }
            }

            return null;
        }
        public void AnadirUnidades(Producto producto)
        {
            try
            {
                Console.WriteLine("Este producto ya existe.");
                Console.Write("Introduzca las unidades que quieres añadir (si introduces 0 las unidades del producto serán 0): ");
                int unidades = int.Parse(Console.ReadLine());

                if (unidades <  0)
                {
                    throw new ArgumentException("Error: las unidades no pueden ser negativo");
                }
                if (unidades != 0)
                {
                    producto.Unidades += unidades;
                }
                else
                {
                    producto.Unidades = 0;
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Error: Ingresa un número válido para las unidades.");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Error inesperado: {e.Message}"); 
            }

        }
    }
}
