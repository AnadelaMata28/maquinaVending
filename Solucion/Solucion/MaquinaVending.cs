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

        public void BuyProducts() {
            Console.WriteLine(ProductInfo(Id));

            int opcion = 0;
            Console.WriteLine("Desea comprar algún otro producto?");
            Console.Write("En caso de no querer, pulse 0. Si desea compras más, pulse 1: ");
            opcion = int.Parse(Console.ReadLine());
            do {
                switch (opcion) {
                    case 0:
                        Console.WriteLine(ProductInfo(Id));
                        Exit();
                        break;
                    case 1:
                        BuyProducts();
                        Console.WriteLine("¿Desea cancelar con la compra? (Si = 1 / No = 0)");
                        int respuesta = int.Parse(Console.ReadLine());
                        if (respuesta == 1)
                        {
                            Exit();
                        }
                        else (respuesta == 0) {
                            do
                            {
                                int option = 0;
                                Console.WriteLine("Método para pagar: ");
                                Console.WriteLine("1. Efectivo");
                                Console.WriteLine("2. Tarjeta");

                                switch (option)
                                {
                                    case 1:
                                        Pagar.PagarEfectivo();
                                        break;
                                    case 2:
                                        Pagar.PagarTarjeta();
                                        break;
                                }
                            } while (option != 2);
                        }
                        break;
                    default:
                        break;
                }
            } while (opcion != 1);
        }

        public string ProductInfo() {
            Producto productoTemp = null;
            productoTemp = ElegirProducto(listaProductos);
            return $"{productoTemp.MostrarDetalles()}";
        }

        public void FullProductLoading() {

        }

        public void Exit() {
            Console.WriteLine("Muchas gracias por su compra!");
            Console.Clear();
        }

        public void ToFile() {
            StreamWriter sw = new StreamWriter("productos.txt", true);
            sw.WriteLine($"{Id}; {Nombre}; {Unidades}; {PrecioUnitario}; {Descripcion}; {TipoMaterial}; {Peso}; {Pilas}; {Precargado}; {InformacionNutricional}");
            sw.Close();
        }
    }
}
     