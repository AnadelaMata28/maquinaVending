using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion
{
    internal class ProductosElectronicos : Producto
    {
        public string TiposMateriales { get; set; }

        public bool Pilas { get; set; }

        public bool Precargado { get; set; }

        public ProductosElectronicos() { }
        public ProductosElectronicos(int count)
        {
            Id = count + 1;
        }

        public ProductosElectronicos(int id, string nombre, int unidades, double precioUnitario, string descripcion, string tiposMateriales, bool pilas, bool precargado)
            : base(id, nombre, unidades, precioUnitario, descripcion)
        {
            TiposMateriales = tiposMateriales;
            Pilas = pilas;
            Precargado = precargado;
        }

        public override string MostrarDetalles(bool eleccion)
        {
            string detalles = base.MostrarDetalles(eleccion);

            if (eleccion)
            {
                detalles += $"\n\tTipos de materiales: {TiposMateriales}\n\tPilas: {Pilas.ToString()}\n\tPrecargado: {Precargado.ToString()}";
            }
            return detalles;
        }

        public override void SolicitarDetalles(List<Producto> listaProductos)
        {
            base.SolicitarDetalles(listaProductos);

            Console.Write("Tipos de materiales: ");
            TiposMateriales = Console.ReadLine();
            Console.Write("Pilas (true - SI / false - NO): ");
            Pilas = bool.Parse(Console.ReadLine());
            Console.Write("Precargado (true - SI / false - NO): ");
            Precargado = bool.Parse(Console.ReadLine());
        }
    }
}