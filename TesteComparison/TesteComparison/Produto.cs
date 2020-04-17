using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

namespace TesteComparison
{
    class Produto : IComparable<Produto>
    {
        public string Nome { get; set; }
        public double Preco { get; set; }

        public Produto(string nome, double preco)
        {
            Nome = nome;
            Preco = preco;
        }

        public override string ToString()
        {
            return Nome + ", " + Preco.ToString("F2", CultureInfo.InvariantCulture);
        }

        public int CompareTo(Produto produto)
        {
            return Nome.ToUpper().CompareTo(produto.Nome.ToUpper());
        }
    }
}
