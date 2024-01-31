using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO_FINAL
{
    internal class Livraria
    {
        private List<Livro> livros;
        public int stockGeral { get; set; } = 0;

        public Livraria()
        {
            livros = new List<Livro>();
        }

        public void AdicionarLivro(Livro livro)
        {
            try
            {
                livros.Add(livro);
                Console.WriteLine("Livro '{0}' adicionado com sucesso!", livro.Titulo);
            }
            catch
            {
                Console.WriteLine("Ocorreu algum problema!");
            }
        }

        public void MostrarLivros()
        {
            try
            {
                bool flag = false;
                if (livros.Count > 0)
                {
                    Console.Write("Indique o ID ou o ISBN: ");
                    int r = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();

                    foreach (var livro in livros)
                    {
                        if (livro.Codigo == r || livro.ISBN == r)
                        {
                            if (livro.Codigo == r)
                                Console.WriteLine("LIVRO COM O ID #{0}", r);
                            else
                                Console.WriteLine("LIVRO COM O ISBN {0}", r);
                            Console.WriteLine($"\nID: {livro.Codigo}\nISBN: {livro.ISBN}\nTítulo: {livro.Titulo}\nAutor: {livro.Autor}\nStock: {livro.Stock}");
                            flag = true;
                        }
                    }
                    if (!flag)
                        Console.WriteLine("Não foram encontrados livros com esse ISBN nem com esse ID!");
                }
                else
                {
                    Console.WriteLine("Não existem livros criados!");
                }
            }
            catch(FormatException)
            {
                Console.Clear();
                Console.WriteLine("Apenas poderá introduzir números!");
                Thread.Sleep(1000);
                MostrarLivros();
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Ocorreu algum problema!");
                Thread.Sleep(1000);
                MostrarLivros();
            }
        }

        // Outros métodos relacionados aos livros, como venda, atualização de estoque, etc.
    }
}
