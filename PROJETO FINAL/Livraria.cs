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
        public int livrosVendidos { get; set; } = 0;
        public double receitaGeral { get; set; } = 0;

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
            Console.Write("\nEscolha a opção: ");
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
                                Console.WriteLine("7 - Stock");
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
                                            case 7:
                                                flag3 = true;
                                                Console.Clear();
                                                Console.Write("Indique o novo Stock: ");
                                                int novoStock = Convert.ToInt32(Console.ReadLine());
                                                if(stockGeral != 0)
                                                {
                                                    stockGeral = stockGeral - livro.Stock;
                                                    livro.Stock = novoStock;
                                                    stockGeral = stockGeral + livro.Stock;
                                                }
                                                else
                                                {
                                                    livro.Stock = novoStock;
                                                    stockGeral = stockGeral + livro.Stock;
                                                }
                                                
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
            catch (FormatException)
            {
                Console.Clear();
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
            bool flag = false;
            int opcao;
            if(livros.Count > 0)
            {
                Console.WriteLine("LISTAGENS");
                Console.WriteLine("\n0 - VOLTAR");
                Console.WriteLine("1 - Listar por GENERO");
                Console.WriteLine("2 - Listar por AUTOR");
                Console.WriteLine("3 - Listar TODOS");
                Console.WriteLine("\nEscolha a opção: ");
                while (!flag)
                {
                    try
                    {
                        opcao = Convert.ToInt32(Console.ReadLine());
                        switch (opcao)
                        {
                            case 0:
                                Console.Clear();
                                return;
                            case 1:
                                flag = true;
                                bool existe = false;
                                Console.Clear();
                                Console.Write("Indique o Genero: ");
                                string genero = Console.ReadLine();
                                Console.Clear();
                                Console.WriteLine("LISTAGEM POR GENERO - {0}\n", genero);
                                foreach (var livro in livros)
                                {
                                    if(livro.Genero == genero)
                                    {
                                        existe = true;
                                        Console.WriteLine("ID: {0}\tISBN: {1}\tTítulo: {2}\tAutor: {3}\tPreço: {4}\tIVA: {5}\tStock: {6}",livro.Codigo, livro.ISBN, livro.Titulo, livro.Autor, livro.Preco, livro.TaxaIVA, livro.Stock);
                                    }
                                }
                                if (!existe)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Não foram encontrados livros com esse genero!");
                                }
                                break;
                            case 2:
                                flag = true;
                                bool existe2 = false;
                                Console.Clear();
                                Console.Write("Indique o Autor: ");
                                string autor = Console.ReadLine();
                                Console.Clear();
                                Console.WriteLine("LISTAGEM POR AUTOR - {0}\n", autor);
                                foreach (var livro in livros)
                                {
                                    if (livro.Autor == autor)
                                    {
                                        existe2 = true;
                                        Console.WriteLine("ID: {0}\tISBN: {1}\tTítulo: {2}\tGenero: {3}\tPreço: {4}\tIVA: {5}\tStock: {6}", livro.Codigo, livro.ISBN, livro.Titulo, livro.Genero, livro.Preco, livro.TaxaIVA, livro.Stock);
                                    }
                                }
                                if (!existe2)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Não foram encontrados livros com esse autor!");
                                }
                                break;
                            case 3:
                                flag = true;
                                Console.Clear();
                                Console.WriteLine("LISTAGEM GERAL\n");
                                foreach (var livro in livros)
                                {
                                    Console.WriteLine("ID: {0}\tISBN: {1}\tTítulo: {2}\tAutor: {3}\tGenero: {4}\tPreço: {5}\tIVA: {6}\tStock: {7}", livro.Codigo, livro.ISBN, livro.Titulo, livro.Autor, livro.Genero, livro.Preco, livro.TaxaIVA, livro.Stock);
                                }
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
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Não existem livros criados!");
            }
        }
        public void consultarStocks()
        {
            Console.Clear();
            bool flag = false;
            bool flag2 = false;
            int opcao;
            if (livros.Count > 0)
            {
                Console.WriteLine("STOCKS");
                Console.WriteLine("\n0 - VOLTAR");
                Console.WriteLine("1 - Stock de Livro");
                Console.WriteLine("2 - Stock GERAL");
                Console.WriteLine("\nEscolha a opção: ");
                while (!flag)
                {
                    try
                    {
                        opcao = Convert.ToInt32(Console.ReadLine());
                        switch (opcao)
                        {
                            case 0:
                                Console.Clear();
                                return;
                            case 1:
                                flag = true;
                                Console.Clear();
                                Console.Write("Indique o ID ou o ISBN: ");
                                int r = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();

                                foreach (var livro in livros)
                                {
                                    if (livro.Codigo == r || livro.ISBN == r)
                                    {
                                        if (livro.Codigo == r)
                                            Console.WriteLine("STOCK DO LIVRO COM O ID #{0}", r);
                                        else
                                            Console.WriteLine("STOCK DO LIVRO COM O ISBN {0}", r);
                                        Console.WriteLine($"\nTítulo: {livro.Titulo}\nAutor: {livro.Autor}\nStock: {livro.Stock}");
                                        flag2 = true;
                                    }
                                }
                                if (!flag2)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Não foram encontrados livros com esse ISBN nem com esse ID!");
                                    Thread.Sleep(500);
                                }
                                break;
                            case 2:
                                flag = true;
                                Console.Clear();
                                Console.WriteLine("O stock geral contabiliza um total de {0} livros disponíveis!", stockGeral);
                                Thread.Sleep(500);
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
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Não existe nenhum stock disponível!");
            }
        }
        public void venderLivros()
        {
            Console.Clear();
            try
            {
                bool flag = false;
                bool flag2 = false;
                bool flag3 = false;
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
                                Console.Clear();
                                while (!flag2)
                                {
                                    Console.Clear();
                                    Console.Write("Quantidade: ");
                                    int quantidade = Convert.ToInt32(Console.ReadLine());
                                    if (livro.Stock < quantidade)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Não existe stock suficiente!");
                                        Thread.Sleep(500);
                                    }
                                    else
                                    {
                                        flag2 = true;
                                        double iva;
                                        while (!flag3)
                                        {
                                            Console.Clear();
                                            Console.Write("Preço de Venda (c/iva): ");
                                            double pv = Convert.ToDouble(Console.ReadLine());
                                            if (livro.TaxaIVA == 23)
                                                iva = 1.23;
                                            else
                                                iva = 1.06;
                                            if (pv <= (livro.Preco * iva))
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Não podes vender mais barato do que o que compras!");
                                                Thread.Sleep(500);
                                            }
                                            else
                                            {
                                                flag3 = true;
                                                livro.Stock = livro.Stock - quantidade;
                                                stockGeral = stockGeral - quantidade;
                                                livrosVendidos = livrosVendidos + quantidade;
                                                receitaGeral = receitaGeral + pv;
                                                Console.Clear();
                                                Console.WriteLine("Livro(s) vendido(s) com sucesso!");
                                                Thread.Sleep(500);
                                            }
                                        }
                                    }
                                }    
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
                venderLivros();
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Ocorreu algum problema!");
                Thread.Sleep(1000);
                venderLivros();
            }

        }
        public void totalReceitaeLivros()
        {
            Console.Clear();
            Console.WriteLine("TOTAIS\n");
            Console.WriteLine("Livros Vendidos: {0}\tReceita Geral: {1}", livrosVendidos, receitaGeral);
        }
        // Outros métodos relacionados aos livros, como venda, atualização de estoque, etc.
    }
}
