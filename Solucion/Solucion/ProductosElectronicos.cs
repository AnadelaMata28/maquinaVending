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
            : base(string nombre, int unidades, double precioUnitario, string descripcion)
        {
            TiposMateriales = tiposMateriales;
            Pilas = pilas;
            Precargado = precargado;
        }
        public override string MostrarDetalles()
        {
            return base.MostrarDetalles() + $"\n\tTipos de materiales: {TiposMateriales}\n\tPilas: {Pilas.ToString()}\n\tPrecargado: {Precargado.ToString()}";
        }
    }
}
