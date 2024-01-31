using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO_FINAL
{
    internal class Repositor : Funcionario
    {
        private Livraria livraria;

        public Repositor(string username, string senha, string nome, List<Funcionario> funcionarios, Livraria livraria) : base(username, senha, nome)
        {
            Funcionario.funcionarios = funcionarios;
            this.livraria = livraria;
        }

        public static bool ValidarLogin(string usr, string pw, Type tipo)
        {
             return Funcionario.funcionarios.Any(f =>
            f.utilizador == usr &&
            f.password == pw &&
            f.GetType() == tipo);
        }

        public void menu()
        {
            int opcao;
            Console.Clear();
            Console.WriteLine("[REPOSIÇÃO] - Bem vindo, {0}! Hoje é o dia {1} de {2} de {3}", nome, DateTime.Now.Day, DateTime.Now.ToString("MMMM"), DateTime.Now.Year);
            Console.WriteLine("MENU\n");
            Console.WriteLine("0 - LOGOUT");//feito
            Console.WriteLine("1 - Criar Livro");//feito
            Console.WriteLine("2 - Consultar Livro");//feito
            Console.WriteLine("3 - Editar Livro");
            Console.WriteLine("4 - Comprar Livros");
            Console.WriteLine("5 - Listagens");
            Console.WriteLine("6 - Consultar Stock");
            Console.Write("\nEscolha a opção: ");
            try
            {
                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("A terminar sessão...");
                        Thread.Sleep(1000);
                        return;
                    case 1:
                        criarLivro();
                        break;
                    case 2:
                        mostrarLivros();
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        Thread.Sleep(1000);
                        menu();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nApenas podem ser introduzidos números!");
                Thread.Sleep(2000);
                menu();
            }
        }

        private void criarLivro()
        {
            livraria.stockGeral++;
            int id = livraria.stockGeral;

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
            livraria.CriarLivro(new Livro(id, isbn, titulo, autor, genero, preco, iva, 0));
            Thread.Sleep(2000);
            menu();
        }

        private void mostrarLivros()
        {
            Console.Clear();
            livraria.MostrarLivros();
            Thread.Sleep(4000);
            menu();
        }
    }
}