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
        public string TipoMaterial { get; set; }

        public double Peso { get; set; }

        public MaterialesPreciosos() { }
        public MaterialesPreciosos(int count)
        {
            Id = count + 1;
        }

        public MaterialesPreciosos(int id, string nombre, int unidades, double precioUnitario, string descripcion, string tipoMaterial, double peso)
            : base(id, nombre, unidades, precioUnitario, descripcion)
        {
            TipoMaterial = tipoMaterial;
            Peso = peso;
        }
        public override string MostrarDetalles(bool eleccion)
        {
            string detalles = base.MostrarDetalles(eleccion);

            if (eleccion)
            {
                detalles += $"\n\tTipo de material: {TipoMaterial}\n\tPeso: {Peso}";
            }
            return detalles;
        }
        public override void SolicitarDetalles(List<Producto> listaProductos)
        {
            base.SolicitarDetalles(listaProductos);

            Console.Write("Tipo de material: ");
            TipoMaterial = Console.ReadLine();
            Console.Write("Peso (gramos): ");
            Peso = int.Parse(Console.ReadLine());
        }
    }
}
