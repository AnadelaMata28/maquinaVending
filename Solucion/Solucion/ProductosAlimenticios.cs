using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion
{
    internal class ProductosAlimenticios : Producto
    {
        public string InformacionNutricional {  get; set; }

        public ProductosAlimenticios(string nombre, int unidades, double precioUnitario, string descripcion, string informacionNutricional)
            : base(string nombre, int unidades, double precioUnitario, string descripcion)
        {
            InformacionNutricional = informacionNutricional;
        }
        public override string MostrarDetalles()
        {
            return base.MostrarDetalles() + $"\n\tInformación nutricional: {InformacionNutricional}";
        }
    }
}
