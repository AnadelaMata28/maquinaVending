using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion {
    internal class ProductosAlimenticios : Producto {
        public string InformacionNutricional { get; set; }

        public ProductosAlimenticios(int count) {
            Id = count + 1;
        }

        public ProductosAlimenticios(string nombre, int unidades, double precioUnitario, string descripcion, string informacionNutricional)
            : base(nombre, unidades, precioUnitario, descripcion) {
            InformacionNutricional = informacionNutricional;
        }

        public override string MostrarDetalles() {
            return base.MostrarDetalles() + $"\n\tInformación nutricional: {InformacionNutricional}";
        }

        public override void SolicitarDetalles(List<Producto> listaProductos) {
            base.SolicitarDetalles(listaProductos);

            Console.Write("Información nutricional: ");
            InformacionNutricional = Console.ReadLine();
        }
    }
}