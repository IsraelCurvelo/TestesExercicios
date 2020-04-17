using System;
using System.Collections.Generic;

namespace TestePredicate
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Produto> lista = new List<Produto>();

            lista.Add(new Produto("Tv", 900.00));
            lista.Add(new Produto("Celular", 689.66));
            lista.Add(new Produto("Capa", 56.88));
            lista.Add(new Produto("Notebook", 4500.00));
            lista.Add(new Produto("Mouse", 87.99));

            foreach(Produto x in lista)
            {
                Console.WriteLine(x);
            }

            Console.WriteLine();
            //lista.RemoveAll(RemoverProduto);
            lista.RemoveAll(p => p.Preco >= 100.00); 

            foreach(Produto x in lista)
            {
                Console.WriteLine(x);
            }
        }

        // static void RemoverProduto(Produto p){
        //return p.Preco >= 100.00; }
    }
}
