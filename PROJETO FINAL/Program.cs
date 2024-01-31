using PROJETO_FINAL;
using System;
using System.Threading;

internal class Program
{
    static List<Funcionario> funcionarios = new List<Funcionario>();
    static Livraria livraria = new Livraria();
    static Gerente gerente = new Gerente("gerente99", "gerente99","João",funcionarios, livraria);
    private static void Main(string[] args)
    {
        menu();
    }
    static void menu()
    {
        Console.Clear();
        string password, utilizador;
        int opcao;
        bool flag = false;
        Console.WriteLine("BEM VINDO À LIVRARIA COELHO!");
        Console.WriteLine("LOGIN\n");
        Console.WriteLine("0 - SAIR");
        Console.WriteLine("1 - Gerente");
        Console.WriteLine("2 - Caixa");
        Console.WriteLine("3 - Repositor\n");
        Console.WriteLine("Data e hora atuais: {0}\n", DateTime.Now);
        Console.Write("Escolha a opção: ");
        try
        {
            opcao = Convert.ToInt32(Console.ReadLine());

            switch (opcao)
            {
                case 0:
                    break;
                case 1:
                    while (!flag)
                    {
                        Console.Clear();
                        Console.Write("Utilizador: ");
                        utilizador = Console.ReadLine();
                        Console.Write("Password: ");
                        password = Console.ReadLine();
                        if (gerente.ValidarLogin(utilizador, password))
                        {
                            Console.Clear();
                            flag = true;
                            gerente.menu();
                            menu();
                        }
                        else
                        {
                            Console.WriteLine("Dados incorretos - Tente novamente!");
                            Thread.Sleep(2000);
                        }
                    }
                    break;
                case 2:
                    Console.WriteLine("Caixa");
                    break;
                case 3:

                    Type tipo = typeof(Repositor);
                    while (!flag)
                    {
                        Console.Clear();
                        Console.Write("Utilizador: ");
                        utilizador = Console.ReadLine();
                        Console.Write("Password: ");
                        password = Console.ReadLine();
                        if (Repositor.ValidarLogin(utilizador, password, tipo))
                        {
                            Console.Clear();
                            Funcionario repositorEncontrado = funcionarios.Find(f => f.utilizador == utilizador && f.password == password && f.GetType() == tipo);

                            Repositor repositor = new Repositor(repositorEncontrado.password, repositorEncontrado.utilizador, repositorEncontrado.nome, funcionarios, livraria);
                            flag = true;
                            repositor.menu();
                            Thread.Sleep(3000);
                        }
                        else
                        {
                            Console.WriteLine("Dados incorretos - Tente novamente!");
                            Thread.Sleep(2000);
                        }
                    }
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
    }
}