using System;
using System.Collections.Generic;
using System.Text;

namespace TesteDelegate
{
    class MostrarCalculo
    {
        // metodos void para usar Multicast delegate

        public static void MostrarMax(double x, double y)
        {
            double max = (x > y) ? x : y;
            Console.WriteLine(max);
        }

        public static void MostrarSoma(double x, double y)
        {
            Console.WriteLine(x+y);
        }
    }
}
