using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace TestesExercicio
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o caminho do arquivo .txt(.cvs): ");
            string caminho = Console.ReadLine();

            List<Produto> lista = new List<Produto>();
            using (StreamReader sr = File.OpenText(caminho))
            {
                while (!sr.EndOfStream)
                {
                    string[] campos = sr.ReadLine().Split(',');
                    string nome = campos[0];
                    double preco = double.Parse(campos[1],CultureInfo.InvariantCulture);
                    lista.Add(new Produto(nome, preco));
                }
            }

            var media = lista.Select(p => p.Preco).DefaultIfEmpty(0.0).Average();
            Console.WriteLine("Média dos preços = "+media.ToString("F2",CultureInfo.InvariantCulture));

            var nomes = lista.Where(p => p.Preco <= media).OrderByDescending(p => p.Nome).Select(p => p.Nome);
            foreach (string x in nomes) Console.WriteLine(x);
        }
    }
}
