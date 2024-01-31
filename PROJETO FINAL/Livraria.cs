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
        public int quantLivros { get; set; } = 0;

        public Livraria()
        {
            livros = new List<Livro>();
        }

        public void CriarLivros()
        {
            quantLivros++;
            int id = quantLivros;

            int iva = 0, opcao, isbn = 0;
            double preco = 0;
            bool flag = false;

            Console.Clear();
            Console.Write("ISBN do livro: ");
            while (!flag)
            {
                try
                {
                    isbn = Convert.ToInt32(Console.ReadLine());
                    flag = true;
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Apenas números!");
                    Thread.Sleep(500);
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Ocorreu algum problema!");
                    Thread.Sleep(500);
                }
            }
            flag = false;
            Console.Write("Título do livro: ");
            string titulo = Console.ReadLine();
            Console.Write("Autor do livro: ");
            string autor = Console.ReadLine();
            Console.Write("Genero do livro: ");
            string genero = Console.ReadLine();
            Console.Clear();
            Console.Write("Preço do livro (s/iva): ");
            while (!flag)
            {
                try
                {
                    preco = Convert.ToDouble(Console.ReadLine());
                    flag = true;
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Apenas números!");
                    Thread.Sleep(500);
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Ocorreu algum problema!");
                    Thread.Sleep(500);
                }
            }
            flag = false;
            Console.WriteLine("\nValor do IVA:");
            Console.WriteLine("1 - Taxa IVA 23%");
            Console.WriteLine("2 - Taxa IVA 6%");
            Console.Write("\nIndique a opção: ");
            while (!flag)
            {
                try
                {
                    opcao = Convert.ToInt32(Console.ReadLine());
                    switch (opcao)
                    {
                        case 1:
                            iva = 23;
                            flag = true;
                            break;
                        case 2:
                            iva = 6;
                            flag = true;
                            break;
                        default:
                            Console.WriteLine("Opção inválida");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Apenas números!");
                    Thread.Sleep(500);
                }

            }
            Console.Clear();
            try
            {
                livros.Add(new Livro(id, isbn, titulo, autor, genero, preco, iva, 0));
                Console.WriteLine("Livro '{0}' adicionado com sucesso!", titulo);
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
                    while (!flag)
                    {
                        Console.Clear();
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
                        {
                            Console.Clear();
                            Console.WriteLine("Não foram encontrados livros com esse ISBN nem com esse ID!");
                            Thread.Sleep(500);
                        }
                    }
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

        public void editarLivros()
        {
            Console.Clear();
            Console.WriteLine("editar");
        }
        

        // Outros métodos relacionados aos livros, como venda, atualização de estoque, etc.
    }
}
