using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TesteFunc
{
    class Produto
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
            return Nome.ToUpper() + ", " + Preco.ToString("F2",CultureInfo.InvariantCulture);
        }

    }
}
