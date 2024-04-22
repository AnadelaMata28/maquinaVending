using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion {
    internal class MaquinaVending {
        public int Id { get; set; }
        List<Producto> listaProductos;

        public MaquinaVending() { }

        public MaquinaVending(int id) {
            Id = id;
        }

        public void BuyProducts() 
        {
            double precioTotal = 0;
            Pagar pagar = null;
            Producto productoTemp = null;

            ProductosDisponibles();

            Console.WriteLine(ProductInfo());

            precioTotal += productoTemp.PrecioUnitario;

            int opcion = 0;
            Console.WriteLine("Desea comprar algún otro producto?");
            Console.Write("En caso de no querer, pulse 0. Si desea compras más, pulse 1: ");
            opcion = int.Parse(Console.ReadLine());
            do {
                switch (opcion) {
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

                        Exit();
                        break;
                    case 1:
                        Console.WriteLine("¿Desea cancelar con la compra? (Si = 1 / No = 0)");
                        int respuesta = int.Parse(Console.ReadLine());
                        if (respuesta == 0)
                        {
                            BuyProducts();
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
                        Exit();

                        break;
                    default:
                        break;
                }
            } while (opcion != 1);
        }

        public string ProductInfo() 
        {
            Producto producto = ElegirProducto(listaProductos);

            return $"{producto.MostrarDetalles()}";
        }

        public void FullProductLoading() {
            Console.WriteLine();
        }

        public void Exit() {
            Console.WriteLine("Muchas gracias por su compra!");
            Console.Clear();
        }

        public void ProductosDisponibles()
        {
            foreach(Producto producto in listaProductos)
            {
                Console.WriteLine(producto.MostrarDetalles());
            }
        }
        public Producto ElegirProducto(List<Producto> listaProductos)
        {
            Producto productoTemp = null;

            Console.WriteLine("Introuce el Id del producto que deseas: ");
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

    }
}
     