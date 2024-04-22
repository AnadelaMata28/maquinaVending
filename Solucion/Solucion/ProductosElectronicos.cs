using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion
{
    internal class ProductosElectronicos : Producto
    {
        public string TiposMateriales {  get; set; }

        public bool Pilas {  get; set; }

        public bool Precargado { get; set; }

        public ProductosElectronicos(int count)
        {
            Id = count + 1;
        }

        public ProductosElectronicos(string nombre, int unidades, double precioUnitario, string descripcion, string tiposMateriales, bool pilas, bool precargado)
            : base(nombre, unidades, precioUnitario, descripcion)
        {
            TiposMateriales = tiposMateriales;
            Pilas = pilas;
            Precargado = precargado;
        }
        public override string MostrarDetalles()
        {
            return base.MostrarDetalles() + $"\n\tTipos de materiales: {TiposMateriales}\n\tPilas: {Pilas.ToString()}\n\tPrecargado: {Precargado.ToString()}";
        }
        public override void SolicitarDetalles()
        {
            base.SolicitarDetalles();

            Console.Write("Tipos de materiales: ");
            TiposMateriales = Console.ReadLine();
            Console.Write("Pilas (1 - SI / 0 - NO): ");
            Pilas = bool.Parse(Console.ReadLine());
            Console.Write("Precargado (1 - SI / 0 - NO): ");
            Precargado = bool.Parse(Console.ReadLine());
        }
    }
}
