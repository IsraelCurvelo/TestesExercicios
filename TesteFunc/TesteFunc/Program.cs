using System;
using System.Collections.Generic;
using System.Linq;

namespace TesteFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Produto> lista = new List<Produto>();

            lista.Add(new Produto("TV", 900.00));
            lista.Add(new Produto("Notebook", 4500.00));
            lista.Add(new Produto("HD", 40.00));
            lista.Add(new Produto("Mouse", 30.50));

            foreach(Produto x in lista)
            {
                Console.WriteLine(x);
            }

            List<string> novaLista = lista.Select(CaixaAlta).ToList();

            foreach(string x in novaLista)
            {
                Console.WriteLine(x);
            }


            Console.WriteLine();
            Func<Produto, string> func = CaixaAlta;
            List<string> novaLista2 = lista.Select(func).ToList();

            foreach (string x in novaLista2)
            {
                Console.WriteLine(x);
            }


        }

        static string CaixaAlta(Produto p)
        {
            return p.Nome.ToUpper();
        }
    }
}
