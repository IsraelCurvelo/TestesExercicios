using System;
using System.Collections.Generic;
using System.Text;

namespace TesteDelegate
{
    class Calculo
    {
        public static double Max (double n1,double n2)
        {
            return (n1 > n2) ? n1 : n2;
        }

        public static double Soma(double n1, double n2)
        {
            return n1 + n2;

        }

        public static double Quadrado(double n1)
        {
            return n1*n1;
        }
    }
}
