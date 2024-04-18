using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Solucion
{
    internal class MaterialesPreciosos : Producto
    {
        public string TipoMaterial {  get; set; }

        public double Peso {  get; set; }
            
        public MaterialesPreciosos(string nombre, int unidades, double precioUnitario, string descripcion, string tipoMaterial, double peso) 
            : base(string nombre, int unidades, double precioUnitario, string descripcion)
        {
            TipoMaterial = tipoMaterial;
            Peso = peso;
        }
        public override string MostrarDetalles()
        {
            return base.MostrarDetalles() + $"\n\tTipo de material: {TipoMaterial}\n\tPeso: {Peso}";
        }
    }
}
