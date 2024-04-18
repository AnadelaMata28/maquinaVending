using System;

namespace Solucion
{
    internal class Pagar
    {
        do {
             int option = 0;
        Console.WriteLine("Método para pagar: "); 
        Console.WriteLine("1. Efectivo"); 
        Console.WriteLine("2. Tarjeta"); 

        switch (option) {
            case 1: 
                PagarEfectivo(); 
            break; 
            case 2: 
               PagarTarejta();
            break; 
        } while (option != 2); 

}
}
