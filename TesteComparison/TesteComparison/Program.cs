using System;
using System.Collections.Generic;

namespace TesteComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Produto> lista = new List<Produto>();

            lista.Add(new Produto("TV", 900.00));
            lista.Add(new Produto("Notebook", 1200.00));
            lista.Add(new Produto("Tablet", 450.00));


            Comparison<Produto>  comp = (p1, p2) => p1.Nome.ToUpper().CompareTo(p2.Nome.ToUpper());

            lista.Sort(comp);


            foreach (Produto x in lista)
            {
                Console.WriteLine(x);
            }


        }

    }
}
