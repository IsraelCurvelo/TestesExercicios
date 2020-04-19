using System;
using System.Collections.Generic;
using System.Linq;

namespace ExerciciosLINQ_SIMILARSQL
{
    class Program
    {
        static void Imprimir<T>(string mensagem, IEnumerable<T> colecao)
        {
            Console.WriteLine(mensagem);
            foreach (T obj in colecao) Console.WriteLine(obj);
            Console.WriteLine();
            Console.WriteLine("_____________________________________________________________");

        }

        static void Main(string[] args)
        {
           
            Categoria c1 = new Categoria() { ID = 1, Nome = "Ferramentas", Classificacao = 2 };
            Categoria c2 = new Categoria() { ID = 2, Nome = "Computadores", Classificacao = 1 };
            Categoria c3 = new Categoria() { ID = 3, Nome = "Eletronicos", Classificacao = 1 };

            List<Produto> lista = new List<Produto>()
            {
                new Produto(){ID = 1, Nome = "Computador", Preco = 1100.0, Categoria = c2},
                new Produto(){ID = 2, Nome = "Martelo", Preco = 90.0, Categoria = c1},
                new Produto(){ID = 3, Nome = "TV", Preco = 1700.0, Categoria = c3},
                new Produto(){ID = 4, Nome = "Notebook", Preco = 1100.0, Categoria = c2},
                new Produto(){ID = 5, Nome = "Serrote", Preco = 80.0, Categoria = c1},
                new Produto(){ID = 6, Nome = "Tablet", Preco = 700.0, Categoria = c2},
                new Produto(){ID = 7, Nome = "Camera", Preco = 700.0, Categoria = c3},
                new Produto(){ID = 8, Nome = "Impressora", Preco = 350.0, Categoria = c3},
                new Produto(){ID = 9, Nome = "MacBook", Preco = 1800.0, Categoria = c2},
                new Produto(){ID = 10, Nome = "SoundBar", Preco = 700.0, Categoria = c3},
                new Produto(){ID = 11, Nome = "Nível", Preco = 70.0, Categoria = c1}
            };

            Console.WriteLine("Classificação de Categoria #1 com Preço < R$900.00 ");//Modo sem a função criada antes do Main
            var r1 =
                from x in lista
                where x.Categoria.Classificacao == 1 && x.Preco < 900
                select x;
            foreach (Produto x in lista) Console.WriteLine(x);
            Console.WriteLine();
            Console.WriteLine("_____________________________________________________________");


            var r2 =
                from x in lista
                where x.Categoria.Nome == "Ferramentas"
                select x.Nome;
            Imprimir("Nomes dos produtos da categoria ferramentas", r2);
            //Modo com a funcao, enviando a mensagem a ser exibida e a colecao q foi criada na expressao


            var r3 =
                from x in lista
                where x.Nome[0] == 'C'
                select new
                {
                    x.Nome,
                    x.Preco,
                    CategoriaNome = x.Categoria.Nome
                };
            Imprimir("Produtos com nomes começados com a letra C", r3);



            var r4 =
                from x in lista
                where x.Categoria.Classificacao == 1
                orderby x.Nome
                orderby x.Preco
                select x;
            Imprimir("Produto com Classificação #1, ordenado por preço e dps por nome", r4);

            var r5 =
               ( from x in r4
                select x).Skip(2).Take(4);
            Imprimir("Pular 2 e exibir os proximos 4 da lista anterior", r5);

            var r6 = 
                (from x in lista
                 select x).First();
            Console.WriteLine("Primeiro da Lista : " + r6);
            Console.WriteLine();

            

           

            Console.WriteLine("Imprimir por categoria");
            var r17 =
                 from x in lista
                 group x by x.Categoria;
            foreach (IGrouping<Categoria, Produto> x in r17)
            {
                Console.WriteLine("Categoria: " + x.Key.Nome + ": ");
                foreach (Produto p in x)
                {
                    Console.WriteLine(p);
                }
                Console.WriteLine();
            }
        }
    }
}
