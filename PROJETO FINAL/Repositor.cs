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
            Console.WriteLine("3 - Editar Livro");//feito
            Console.WriteLine("4 - Comprar Livros");//feito - falta dar cw como o stor quer!
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
                    case 3:
                        editarLivros();
                        break;
                    case 4:
                        comprarLivros();
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
            
            Console.Clear();
            livraria.CriarLivros();
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

        private void editarLivros()
        {
            Console.Clear();
            livraria.editarLivros();
            Thread.Sleep(2000);
            menu();
        }

        private void comprarLivros()
        {
            Console.Clear();
            livraria.comprarLivros();
            Thread.Sleep(2000);
            menu();
        }
    }
}