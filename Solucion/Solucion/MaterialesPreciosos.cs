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
        public MaterialesPreciosos(string tipoMaterial, double peso) : base
    }
}
