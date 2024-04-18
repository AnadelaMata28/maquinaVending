﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion {
    internal class MaquinaVending {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int UnidadesDisponibles { get; set; }
        public int Precio { get; set; }
        List<Producto> listaProductos;

        public MaquinaVending() { }

        public MaquinaVending(int id, string nombre, int unidadesDisponibles, int precio) {
            Id = id;
            Nombre = nombre;
            UnidadesDisponibles = unidadesDisponibles;
            Precio = precio;
        }

        public void BuyProducts() {
            Console.WriteLine("Introduzca el ID del producto que desee comprar: ");
            Id = int.Parse(Console.ReadLine());
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
                        Console.WriteLine("Introduzca el ID del producto que desee comprar: ");
                        Id = int.Parse(Console.ReadLine());
                        Console.WriteLine(ProductInfo(Id));
                        break;
                    default:
                        break;
                }
            } while (opcion != 1);
        }
        
        public void ProductInfo() {
            Producto productoTemp = null;
            productoTemp = ElegirProducto();

        }

        public void IndividualProductLoading() {

        }

        public void FullProductLoading() {

        }

        public void Exit() {
            Console.WriteLine("Muchas gracias por su compra!");
        }
    }
}
     