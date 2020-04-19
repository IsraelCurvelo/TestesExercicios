using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TesteLINQ
{
    class Produto
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public Categoria Categoria { get; set; }

        public override string ToString()
        {
            return ID
                + ", "
                + Nome
                + ", "
                + Preco.ToString("F2", CultureInfo.InvariantCulture)
                + ", "
                + Categoria.Nome
                + ", "
                + Categoria.Classificacao;

        }
    }
}
