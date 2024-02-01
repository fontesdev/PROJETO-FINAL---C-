using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO_FINAL
{
    internal class Gerente : Funcionario
    {
        private Livraria livraria;
        public Gerente(string usr, string pw, string nome, List<Funcionario> funcionarios, Livraria livraria) : base(usr, pw, nome)
        {
            Funcionario.funcionarios = funcionarios;
            this.livraria = livraria;
        }

        public bool ValidarLogin(string usr, string pw)
        {
            return utilizador == usr && password == pw;
        }

        public void menu()
        {
            int opcao;
            Console.Clear();
            Console.WriteLine("[BACKOFFICE] - Bem vindo, {0}! Hoje é o dia {1} de {2} de {3}", nome, DateTime.Now.Day, DateTime.Now.ToString("MMMM"), DateTime.Now.Year);
            Console.WriteLine("MENU\n");
            Console.WriteLine("0 - LOGOUT");//feito
            Console.WriteLine("1 - Criar Funcionário");//feito
            Console.WriteLine("2 - Listar Funcionários");//feito
            Console.WriteLine("3 - Eliminar Funcionário");//feito
            Console.WriteLine("4 - Vender Livro");
            Console.WriteLine("5 - Consultar Livro");//feito
            Console.WriteLine("6 - Listagens");//feito
            Console.WriteLine("7 - Consultar Stock");//feito
            Console.WriteLine("8 - Total de Livros Vendidos e Receita Total");
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
                        criarFuncionarios();
                        break;
                    case 2:
                        listarFuncionarios();
                        break;
                    case 3:
                        eliminarFuncionarios();
                        break;
                    case 5:
                        mostrarLivros();
                        break;
                    case 6:
                        listagens();
                        break;
                    case 7:
                        consultarStocks();
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
        private void criarFuncionarios()
        {
            Funcionario func = null;
            string utilizador, password, nome;
            int opcao;
            Console.Clear();

            do
            {
                Console.Clear();
                Console.Write("Indique o utilizador do novo funcionário: ");
                utilizador = Console.ReadLine();

                if (Funcionario.funcionarios.Any(f => f.utilizador == utilizador))
                {
                    Console.WriteLine("Erro: Utilizado já existente, escolha outro!");
                    Thread.Sleep(1000);
                    criarFuncionarios();
                }
            } while (Funcionario.funcionarios.Any(f => f.utilizador == utilizador));
            Console.Write("Indique a password do novo funcionário: ");
            password = Console.ReadLine();
            Console.Write("Indique o nome do novo funcionário: ");
            nome = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("1 - Caixa");
            Console.WriteLine("2 - Repositor\n");
            Console.Write("Escolha a opção: ");
            try
            {
                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        func = new Caixa(utilizador, password, nome);
                        break;
                    case 2:
                        func = new Repositor(utilizador, password, nome, funcionarios, livraria);
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        Thread.Sleep(2000);
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
            Console.Clear();
            Funcionario.funcionarios.Add(func);
            Console.WriteLine("Funcionário criado com sucesso!");
            Console.WriteLine("Nome: {0} | Posto: {1}", nome, func.GetType().Name);
            Thread.Sleep(2000);
            menu();
        }

        private void listarFuncionarios()
        {
            Console.Clear();
            int cont = 1;
            if (Funcionario.funcionarios.Count == 0)
            {
                Console.WriteLine("Nenhum funcionário criado!");
                Thread.Sleep(2000);
            }
            else
            {
                foreach (var funcionario in Funcionario.funcionarios)
                {
                    Console.WriteLine("Funcionário #{0}", cont);
                    Console.WriteLine("Nome: {0} | Utilizador: {1} | Posto: {2}\n", funcionario.nome, funcionario.utilizador, funcionario.GetType().Name);
                    cont++;
                }
                Thread.Sleep(3000);
            }
            menu();
        }

        private void eliminarFuncionarios()
        {
            Console.Clear();
            Console.Write("Utilizador a eliminar: ");
            string utilizador = Console.ReadLine();
            int r = Funcionario.funcionarios.RemoveAll(f => f.utilizador == utilizador);

            if (r > 0)
            {
                Console.Clear();
                Console.WriteLine("Funcionário com o utilizador {0} removido com sucesso!", utilizador);
                Thread.Sleep(2000);
                menu();
            }
            else
            {
                Console.WriteLine("Não foi encontrado nenhum funcionário com esse utilizador!");
                Thread.Sleep(2000);
                eliminarFuncionarios();
            }
        }

        private void mostrarLivros()
        {
            Console.Clear();
            livraria.MostrarLivros();
            Thread.Sleep(4000);
            menu();
        }

        private void listagens()
        {
            Console.Clear();
            livraria.listagens();
            Thread.Sleep(2000);
            menu();
        }

        private void consultarStocks()
        {
            Console.Clear();
            livraria.consultarStocks();
            Thread.Sleep(2000);
            menu();
        }
    }
}
