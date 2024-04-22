using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion
{
    internal class Pagar
    {
        public Pagar() { }

        public string PagarEfectivo(double precioTotal) //FALTA PONER MENSAJE
        {
            int dinero = 0;
            do
            {
                Console.WriteLine("Introduce la cantidad introducida: ");
                dinero = int.Parse(Console.ReadLine());
            } while (dinero < precioTotal);

            return $"mensaje";

        }

        public void PagarTarjeta(double precioTotal)
        {
            Console.WriteLine("Número de tarjeta: ");
            int numeroTarjeta = int.Parse(Console.ReadLine());
            Console.WriteLine("Fecha de caducidad: ");
            string fechaCaducidad = Console.ReadLine();
            Console.WriteLine("Código de seguridad: ");
            int codigoSeguridad = int.Parse(Console.ReadLine());
            Console.ReadKey();
            Console.WriteLine("Pagando....");

        }
    }
}
