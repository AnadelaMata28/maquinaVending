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

        public void PagarEfectivo(double precioTotal)
        {
            MaquinaVending maquinaVending = new MaquinaVending();
            try
            {
                double dinero = 0;
                Console.WriteLine();
                Console.WriteLine($"Cantidad a pagar {precioTotal} euros");
                Console.WriteLine();

                do
                {
                    Console.WriteLine($"Has introducido {dinero} euros");
                    Console.Write("Introduzca la cantidad requerida en euros por favor: ");
                    dinero += double.Parse(Console.ReadLine());
                    Console.WriteLine();
                } while (dinero < precioTotal);

                DevolverDinero(precioTotal, dinero);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Opción inválida. Por favor, ingrese un número válido.");
            }

            Console.WriteLine();
            Console.WriteLine("Pulse una tecla...");
            Console.ReadKey();
            maquinaVending.Salir();
        }

        public void PagarTarjeta(double precioTotal)
        {
            MaquinaVending maquinaVending = new MaquinaVending();

            try
            {
                Console.WriteLine();
                Console.WriteLine($"Cantidad a pagar {precioTotal} euros");
                Console.Write("Número de tarjeta: ");
                int numeroTarjeta = int.Parse(Console.ReadLine());
                Console.Write("Fecha de caducidad: ");
                string fechaCaducidad = Console.ReadLine();
                Console.Write("Código de seguridad: ");
                int codigoSeguridad = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("Pagando....");
                Console.WriteLine();
                Console.WriteLine("Transacción realizada con éxito");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Opción inválida. Por favor, ingrese un número válido.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
            Console.WriteLine("Pulse una tecla...");
            Console.ReadKey();
            maquinaVending.Salir();
        }

        public void DevolverDinero(double precioTotal, double dinero)
        {
            double cambio = 0;

            if (dinero > precioTotal)
            {
                cambio = precioTotal - dinero;

                double centimos = -1 * (cambio * 100) % 100;
                double euros = -1 * (cambio - (centimos / 100));
                if (centimos == 0)
                {
                    Console.WriteLine($"Su vuelta: {euros} euros.");
                }
                else
                {
                    Console.WriteLine($"Su vuelta son {euros} euros y {centimos} centimos.");
                }
                Console.WriteLine();
                Console.WriteLine($"Pagado con éxito");
                Console.WriteLine();
            }
        }
    }
}