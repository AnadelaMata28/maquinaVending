using System;

namespace Solucion
{
    internal class Pagar
    {
       
         public string PagarEfectivo()
         {
             
             Console.WriteLine("Introduce la cantidad introducida: ");
             int dinero = int.Parse(Console.ReadLine());
         }

         public void PagarTarjeta()
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
