using System;

namespace TesteDelegate
{
    delegate double OperacaoDelegate(double n1, double n2);
    delegate void OperacaodelegateVoid(double x, double y);
    class Program
    {
        static void Main(string[] args)
        {
            //delegate
            double a = 10, b = 20;

            OperacaoDelegate del = Calculo.Soma;
            double result = del(a, b);
            Console.WriteLine(result);
            // sintaxe alternativa
            OperacaoDelegate del2 = new OperacaoDelegate( Calculo.Max); 
            result = del2.Invoke(a, b);
            Console.WriteLine(result);

            Console.WriteLine(  );
            //Multicast delegate

            OperacaodelegateVoid delvoid = MostrarCalculo.MostrarSoma;
            delvoid += MostrarCalculo.MostrarMax;

            delvoid(a, b);

        }
    }
}
