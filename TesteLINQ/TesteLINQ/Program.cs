using System;
using System.Linq;
using System.Collections.Generic;

namespace TesteLINQ
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
            //especificando a base de dados

            int[] numeros = new int[] { 1, 2, 3, 5, 8, 9, 10 };

            //Definir a consulta
            var result = numeros.Where((p) => p % 2 == 0); // filtra todos os pares do vetor numeros e salva em result
            Console.WriteLine("Filtrar os pares do vetor");
            foreach (int x in result) Console.WriteLine(x);// executar a consulta
            Console.WriteLine();


            var result2 = numeros
                .Where((p) => p % 2 == 0)
                .Select(p => p * 10);// a msm operação de cima(pares), porem multiplicado por 10 dentro do select
            Console.WriteLine("Filtrar esses pares e multiplicar por 10");
            foreach (int x in result2) Console.WriteLine(x);
            Console.WriteLine();



            Console.WriteLine("_____________________________________________________________");
            Console.WriteLine("CATEGORIAS E PRODUTOS");
            Console.WriteLine();
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
            var r1 = lista.Where(p => p.Categoria.Classificacao == 1 && p.Preco < 900.0);
            foreach (Produto x in lista) Console.WriteLine(x);
            Console.WriteLine();
            Console.WriteLine("_____________________________________________________________");


            var r2 = lista.Where(p => p.Categoria.Nome == "Ferramentas").Select(p => p.Nome);
            Imprimir("Nomes dos produtos da categoria ferramentas", r2);
            //Modo com a funcao, enviando a mensagem a ser exibida e a colecao q foi criada na expressao


            var r3 = lista.Where(p => p.Nome[0] == 'C').Select(p => new { p.Nome, p.Preco, CategoriaNome = p.Categoria.Nome });
            Imprimir("Produtos com nomes começados com a letra C", r3);



            var r4 = lista
                .Where(p => p.Categoria.Classificacao == 1)
                .OrderBy(p => p.Preco)// Ordena 
                .ThenBy(p => p.Nome);// Ordena após o primeiro ordenamento
            Imprimir("Produto com Classificação #1, ordenado por preço e dps por nome", r4);

            var r5 = r4.Skip(2).Take(4);
            Imprimir("Pular 2 e exibir os proximos 4 da lista anterior", r5);

            var r6 = lista.First();
            Console.WriteLine("Primeiro da Lista : " + r6);
            Console.WriteLine();

            var r7 = lista.Where(p => p.Preco > 3000).FirstOrDefault();
            Console.WriteLine("Primeiro ou Default da lista: "+ r7);
            Console.WriteLine();

            var r8 = lista.Where(p => p.ID == 2).SingleOrDefault();
            Console.WriteLine("Single or Default: " + r8);
            Console.WriteLine();

            var r9 = lista.Where(p => p.ID == 30).SingleOrDefault();
            Console.WriteLine("Single or Default, nenhum elemento: " + r9);
            Console.WriteLine();

            var r10 = lista.Max(p => p.Preco);// Lambda para filtrar, poderia ter feito sem, mas tem q comparar
            Console.WriteLine("Preço Maximo dos produtos: "+r10);

            var r11 = lista.Min(p => p.Preco);// Lambda para filtrar, poderia ter feito sem
            Console.WriteLine("Preço Minimo dos produtos: " + r11);

            var r12 = lista.Where(p => p.Categoria.ID == 1).Sum(p => p.Preco);
            Console.WriteLine("Soma dos valores dos produtos da categoria #1: "+ r12);

            var r13 = lista.Where(p => p.Categoria.ID == 1).Average(p => p.Preco);
            Console.WriteLine("Media dos valores dos produtos da categoria #1: " + r13);

            var r14 = lista
                .Where(p => p.Categoria.ID == 30)
                .Select(p => p.Preco)
                .DefaultIfEmpty(0.0)
                .Average();
            Console.WriteLine("Media dos valores dos produtos da categoria #30(FILTRO DA CAT INEXISTENTE): " + r14);

            var r15 = lista
                .Where(p => p.Categoria.ID == 1)
                .Select(p => p.Preco)
                .Aggregate((x, y) => x + y);//Funcao anonima ( coloca os parametros e o retorno)
            Console.WriteLine("categoria 1 agregando soma: "+ r15);

            var r16 = lista
                .Where(p => p.Categoria.ID == 30)
                .Select(p => p.Preco)
                .Aggregate(0.0,(x, y) => x + y); // se o filtro for null, o 0.0 fica default
            Console.WriteLine("categoria 30(FILTRO INEXISTENTE) agregando soma: " + r16);
            Console.WriteLine();

            Console.WriteLine("Imprimir por categoria");
            var r17 = lista.GroupBy(p => p.Categoria); // ordena por categoria(Retorna IGrouping)
            foreach (IGrouping<Categoria, Produto> x in r17) 
            {
                Console.WriteLine("Categoria: "+ x.Key.Nome + ": ");
                foreach (Produto p in x)
                {
                    Console.WriteLine(p);
                }
                Console.WriteLine();
            }
        }
    }
}
