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
        public double valorComprasSIVA { get; set; } = 0;
        public double valorComprasCIVA { get; set; } = 0;

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
            while (!flag)
            {
                try
                {
                    Console.Clear();
                    Console.Write("Preço do livro (s/iva): ");
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
            try
            {
                bool flag = false;
                int opcao;
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
                                flag = true;
                                if (livro.Codigo == r)
                                    Console.WriteLine("EDITAR LIVRO COM O ID #{0}\n", r);
                                else
                                    Console.WriteLine("EDITAR LIVRO COM O ISBN {0}\n", r);
                                Console.WriteLine("1 - ISBN");
                                Console.WriteLine("2 - Título");
                                Console.WriteLine("3 - Autor");
                                Console.WriteLine("4 - Genero");
                                Console.WriteLine("5 - Preço");
                                Console.WriteLine("6 - Taxa IVA");
                                Console.Write("\nEscolha a opção: ");
                                bool flag3 = false;
                                while (!flag3)
                                {
                                    try
                                    {
                                        opcao = Convert.ToInt32(Console.ReadLine());
                                        switch (opcao)
                                        {
                                            case 1:
                                                flag3 = true;
                                                Console.Clear();
                                                Console.Write("Indique o novo ISBN: ");
                                                int novoISBN = Convert.ToInt32(Console.ReadLine());
                                                livro.ISBN = novoISBN;
                                                break;
                                            case 2:
                                                flag3 = true;
                                                Console.Clear();
                                                Console.Write("Indique o novo Título: ");
                                                string novoTitulo = Console.ReadLine();
                                                livro.Titulo = novoTitulo;
                                                break;
                                            case 3:
                                                flag3 = true;
                                                Console.Clear();
                                                Console.Write("Indique o novo Autor: ");
                                                string novoAutor = Console.ReadLine();
                                                livro.Autor = novoAutor;
                                                break;
                                            case 4:
                                                flag3 = true;
                                                Console.Clear();
                                                Console.Write("Indique o novo Genero: ");
                                                string novoGenero = Console.ReadLine();
                                                livro.Genero = novoGenero;
                                                break;
                                            case 5:
                                                flag3 = true;
                                                Console.Clear();
                                                Console.Write("Indique o novo Preco: ");
                                                double novoPreco = Convert.ToDouble(Console.ReadLine());
                                                livro.Preco = novoPreco;
                                                break;
                                            case 6:
                                                flag3 = true;
                                                bool flag2 = false;
                                                Console.Clear();
                                                int novoIVA = 0;
                                                Console.WriteLine("Indique o novo IVA:");
                                                Console.WriteLine("1 - Taxa IVA 23%");
                                                Console.WriteLine("2 - Taxa IVA 6%");
                                                Console.Write("\nIndique a opção: ");
                                                while (!flag2)
                                                {
                                                    try
                                                    {
                                                        opcao = Convert.ToInt32(Console.ReadLine());
                                                        switch (opcao)
                                                        {
                                                            case 1:
                                                                novoIVA = 23;
                                                                flag2 = true;
                                                                break;
                                                            case 2:
                                                                novoIVA = 6;
                                                                flag2 = true;
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
                                                livro.TaxaIVA = novoIVA;
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
                                Console.WriteLine("Livro editado com sucesso!");
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
            catch (FormatException)
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
        public void comprarLivros()
        {
            Console.Clear();
            try
            {
                bool flag = false;
                double valorSIVA = 0;
                double totalSIVA = 0;
                double valorIVA = 0;
                double totalIVA = 0;
                double valorCIVA = 0;
                double totalCIVA = 0;
                double totalVenda = 0;
                double quantidadeCompra = 0;
                int quantidade = 0;
                int r = 0;
                if (livros.Count > 0)
                {
                    while (!flag)
                    {
                        Console.Clear();
                        
                        Console.WriteLine("* insira 0 para terminar as compras!");
                        Console.Write("Indique o ID ou o ISBN: ");
                        r = Convert.ToInt32(Console.ReadLine());
                        while (r != 0)
                        { 
                            Console.Clear();

                            foreach (var livro in livros)
                            {
                                if (livro.Codigo == r || livro.ISBN == r)
                                {
                                    flag = true;
                                    if (livro.Codigo == r)
                                        Console.WriteLine("COMPRAR LIVRO COM O ID #{0}", r);
                                    else
                                        Console.WriteLine("COMPRAR LIVRO COM O ISBN {0}", r);

                                    Console.Write("Indique a quantidade: ");
                                    quantidade = Convert.ToInt32(Console.ReadLine());

                                    valorSIVA = quantidade * livro.Preco;
                                    totalSIVA = totalSIVA + valorSIVA;
                                    if (livro.TaxaIVA == 23)
                                        valorCIVA = valorSIVA * 1.23;
                                    else
                                        valorCIVA = valorSIVA * 1.06;

                                    totalCIVA = totalCIVA + valorCIVA;

                                    valorIVA = valorCIVA - valorSIVA;
                                    totalIVA = totalIVA + valorIVA;

                                    totalVenda = totalVenda + valorCIVA;

                                    livro.Stock = livro.Stock + quantidade;
                                    stockGeral = stockGeral + quantidade;
                                    quantidadeCompra = quantidadeCompra + quantidade;
                                    //valorComprasSIVA = valorComprasSIVA + valorSIVA;
                                    //valorComprasCIVA = valorComprasCIVA + valorCIVA;

                                    Console.Clear();
                                    Console.WriteLine("Adicionado ao carrinho!");
                                    Console.WriteLine("RESUMO DO PRODUTO:");
                                    Console.WriteLine("\nLivro: {0}\nAutor: {1}\nQuantidade: {2}\nPreço s/ IVA: {3}\nPreço final: {4}\nValor do IVA: {5}", livro.Titulo, livro.Autor, quantidade, valorSIVA, valorCIVA, valorIVA);
                                    Thread.Sleep(2000);
                                    
                                    Console.Clear();
                                    Console.WriteLine("* insira 0 para terminar as compras!");
                                    Console.Write("Indique o ID ou o ISBN: ");
                                    r = Convert.ToInt32(Console.ReadLine());
                                }
                            }
                            if (!flag)
                            {
                                Console.Clear();
                                Console.WriteLine("Não foram encontrados livros com esse ISBN nem com esse ID!");
                                Thread.Sleep(500);
                            }

                        }
                        Console.Clear();
                        int desconto = 0;
                        Console.WriteLine("Compra terminada com sucesso!");
                        Console.WriteLine("RESUMO DA COMPRA:");
                        if (totalVenda > 50)
                        {
                            totalCIVA = totalCIVA / 0.10;
                            desconto = 10;
                        }
                        Console.WriteLine("\nLivros Comprados: {0}\nTotal da Venda (s/iva): {1}\nDesconto Aplicado: {2}\nTotal da Venda (c/iva): {3}\nValor do IVA: {4}", quantidadeCompra, totalSIVA, desconto, totalCIVA, totalIVA);
                        Thread.Sleep(2500);
                    }

                }
                else
                {
                    Console.WriteLine("Não existem livros criados!");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Apenas poderá introduzir números!");
                Thread.Sleep(1000);
                comprarLivros();
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Ocorreu algum problema!");
                Thread.Sleep(1000);
                comprarLivros();
            }
        }
        public void listagens()
        {
            Console.Clear();

        }
        // Outros métodos relacionados aos livros, como venda, atualização de estoque, etc.
    }
}
