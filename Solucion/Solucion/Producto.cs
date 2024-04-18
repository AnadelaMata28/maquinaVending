using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion
{
    internal class Producto
    {
        public string Nombre {  get; set; }
        public int Unidades { get; set; }
        public double PrecioUnitario { get; set; }
        public string Descripcion { get; set; }

        public Producto() { }
        public Producto(string nombre, int unidades, double precioUnitario, string descripcion)
        {
            Nombre = nombre;
            Unidades = unidades;
            PrecioUnitario = precioUnitario;
            Descripcion = descripcion;
        }
        public virtual string MostrarDetalles()
        {
            return $"Nombre: {Nombre}\n\tUnidades: {Unidades}\n\tPrecio unitario: {PrecioUnitario}\n\tDescripción: {Descripcion}"
        }
    }
}
