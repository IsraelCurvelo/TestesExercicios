using System;
using System.Collections.Generic;

namespace TesteAction
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Produto> lista = new List<Produto>();

            lista.Add(new Produto("TV", 900.00));
            lista.Add(new Produto("Notebook", 4900.00));
            lista.Add(new Produto("Mouse", 23.45));
            lista.Add(new Produto("HD", 450.50));
            lista.Add(new Produto("Case", 12.50));



            lista.ForEach(AtualizarPrecos);
            foreach (Produto p in lista)
            {
                Console.WriteLine(p);
            }


            Console.WriteLine();
            Action<Produto> pa = AtualizarPrecos;
            lista.ForEach(pa);
            foreach (Produto p in lista)
            {
                Console.WriteLine(p);
            }


            Console.WriteLine(  );
            Action<Produto> p2 = (p )=> { p.Preco += p.Preco * 0.1; } ;
            lista.ForEach(p2);
            foreach (Produto p in lista)
            {
                Console.WriteLine(p);
            }


            Console.WriteLine();
            lista.ForEach((p) => { p.Preco += p.Preco * 0.1; });
            foreach (Produto p in lista)
            {
                Console.WriteLine(p);
            }

        }

        static void AtualizarPrecos(Produto p1)
        {
            p1.Preco += p1.Preco * 0.1;
        }
    }
}
