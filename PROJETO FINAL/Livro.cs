using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO_FINAL
{

    public class Livro
    {
       
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int ISBN { get; set; }
        public string Genero { get; set; }
        public double Preco {  get; set; }
        public int TaxaIVA { get; set; }

        public int Stock { get; set; }

        public Livro(int codigo, int isbn, string titulo, string autor, string genero, double preco, int taxaIVA, int stock)
        {
            Codigo = codigo;
            ISBN = isbn;
            Titulo = titulo;
            Autor = autor;
            Genero = genero;
            Preco = preco;
            TaxaIVA = taxaIVA;
            Stock = stock;
        }
    }
}
