using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion {
    internal class Producto {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int Unidades { get; set; }

        public double PrecioUnitario { get; set; }

        public string Descripcion { get; set; }

        public Producto() { }

        public Producto(string nombre, int unidades, double precioUnitario, string descripcion) {
            Nombre = nombre;
            Unidades = unidades;
            PrecioUnitario = precioUnitario;
            Descripcion = descripcion;
        }

        public virtual string MostrarDetalles() {
            return $"\n\tId: {Id}\n\tNombre: {Nombre}\n\tUnidades: {Unidades}\n\tPrecio unitario: {PrecioUnitario}\n\tDescripción: {Descripcion}";
        }

        public void AddProducto(List<Producto> listaProductos) {
            int opcion = 0;
            do {
                Console.Clear();

                Console.WriteLine("Introduce el tipo de producto que deseas añadir: ");

                Console.WriteLine("1. Materiales preciosos");
                Console.WriteLine("2. Productos alimenticios");
                Console.WriteLine("3. Productos electrónicos");
                Console.WriteLine("4. Salir");

                Console.Write("Opción: ");
                try {
                    opcion = int.Parse(Console.ReadLine());
                    Console.Clear();

                    if (listaProductos == null)
                    {
                        listaProductos = new List<Producto>();
                    }

                    switch (opcion) {
                    case 1:
                        MaterialesPreciosos mp = new MaterialesPreciosos(listaProductos.Count);
                        mp.SolicitarDetalles(listaProductos);
                        listaProductos.Add(mp);
                        break;
                    case 2:
                        ProductosAlimenticios pa = new ProductosAlimenticios(listaProductos.Count);
                        pa.SolicitarDetalles(listaProductos);
                        listaProductos.Add(pa);
                        break;
                    case 3:
                        ProductosElectronicos pe = new ProductosElectronicos(listaProductos.Count);
                        pe.SolicitarDetalles(listaProductos);
                        listaProductos.Add(pe);
                        break; ;
                    case 4: //Salir
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                    }
                }
                catch (FormatException) {
                    Console.WriteLine("Error: Opción inválida. Por favor, ingrese un número válido.");
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Presiona una tecla para continuar...");
                Console.ReadKey();

            } while (opcion != 4);
        }

        public virtual void SolicitarDetalles(List<Producto> listaProductos) {
            Console.Clear();
            Console.WriteLine("  --- Solicitando detalles ---  ");
            Console.WriteLine();

            Console.Write("Introduce el nombre del producto: ");
            string nombre = Console.ReadLine();
            if(!ExisteProducto(listaProductos, nombre))
            {
                Nombre = nombre;
                Console.Write("Unidades: ");
                Unidades = int.Parse(Console.ReadLine());
                Console.Write("Precio unitario (en euros): ");
                PrecioUnitario = int.Parse(Console.ReadLine());
                Console.Write("Descripción: ");
                Descripcion = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Este producto ya existe.");
                Console.Write("Introduzca las unidades que quieres añadir: ");
                Unidades += int.Parse(Console.ReadLine());

                return;
            }
            
        }
        public bool ExisteProducto(List <Producto> listaProductos, string nombre)
        {
            bool existe = false;
            Producto productoTemp = null;

            if (listaProductos != null) {

                foreach (Producto producto in listaProductos)
                {
                    if (producto.Nombre == nombre)
                    {
                        productoTemp = producto;
                        existe = true;
                    }
                }
            }

            return existe;
        }
    }
}