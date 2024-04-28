using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucion {
    internal class Pagar {
        public Pagar() { }

        public string PagarEfectivo(double precioTotal) //FALTA PONER MENSAJE
        {
            try
            {
                double dinero = 0;

                Console.WriteLine($"Cantidad a pagar {precioTotal}");
                do
                {
                    Console.WriteLine("Introduzca la cantidad requerida en euros por favor: ");
                    dinero = double.Parse(Console.ReadLine());
                } while (dinero < precioTotal);

                DevolverDinero(precioTotal, dinero);
                return $"Pagado con éxito";
            }
            catch(FormatException) {
                return "Error: Opción inválida. Por favor, ingrese un número válido.";
            }
        }

        public void PagarTarjeta(double precioTotal) {
            try
            {
                Console.WriteLine($"Cantidad a pagar {precioTotal}");
                Console.WriteLine("Número de tarjeta: ");
                int numeroTarjeta = int.Parse(Console.ReadLine());
                Console.WriteLine("Fecha de caducidad: ");
                string fechaCaducidad = Console.ReadLine();
                Console.WriteLine("Código de seguridad: ");
                int codigoSeguridad = int.Parse(Console.ReadLine());
                Console.ReadKey();
                Console.WriteLine("Pagando....");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Opción inválida. Por favor, ingrese un número válido.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();

        }

        public void DevolverDinero(double precioTotal, double dinero)
        {
            double cambio = 0;

            if (dinero > precioTotal)
            {
                cambio = precioTotal - dinero;

                double centimos = (cambio*100)% 100;
                double euros = cambio - (centimos/100); 
                 Console.WriteLine($"Su vuelta son {centimos} centimos y {euros} euros.");

                Console.WriteLine($"Su vuelta son {cambio} euros.");
            }
        }
    }
}