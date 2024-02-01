using PROJETO_FINAL;
using System;
using System.Threading;

internal class Program
{
    static List<Funcionario> funcionarios = new List<Funcionario>();
    static Livraria livraria = new Livraria();
    static Gerente gerente = new Gerente("gerente99", "gerente99","João", funcionarios, livraria);
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
                    Console.Clear();
                    Console.WriteLine("A fechar...");
                    Thread.Sleep(1000);
                    Environment.Exit(0);
                    break;
                case 1:
                    while (!flag)
                    {
                        Console.Clear();
                        Console.WriteLine("0 - VOLTAR");
                        Console.Write("Utilizador: ");
                        utilizador = Console.ReadLine();
                        if (utilizador == "0") menu();
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
                            Console.Clear();
                            Console.WriteLine("Dados incorretos - Tente novamente!");
                            Thread.Sleep(1500);
                        }
                    }
                    break;
                case 2:
                    if (funcionarios.Count == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Não existem funcionários criados!");
                        Thread.Sleep(1000);
                        menu();
                    }
                    else
                    {
                        Type tipo2 = typeof(Caixa);
                        while (!flag)
                        {
                            Console.Clear();
                            Console.WriteLine("0 - VOLTAR");
                            Console.Write("Utilizador: ");
                            utilizador = Console.ReadLine();
                            if (utilizador == "0") menu();
                            Console.Write("Password: ");
                            password = Console.ReadLine();
                            if (Caixa.ValidarLogin(utilizador, password, tipo2))
                            {
                                Console.Clear();
                                Funcionario caixaEncontrado = funcionarios.Find(f => f.utilizador == utilizador && f.password == password && f.GetType() == tipo2);

                                Caixa caixa = new Caixa(caixaEncontrado.password, caixaEncontrado.utilizador, caixaEncontrado.nome, funcionarios, livraria);
                                flag = true;
                                caixa.menu();
                                menu();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Dados incorretos - Tente novamente!");
                                Thread.Sleep(1500);
                            }
                        }
                    }
                    break;
                case 3:
                    if (funcionarios.Count == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Não existem funcionários criados!");
                        Thread.Sleep(1000);
                        menu();
                    }
                    else
                    {
                        Type tipo = typeof(Repositor);
                        while (!flag)
                        {
                            Console.Clear();
                            Console.WriteLine("0 - VOLTAR");
                            Console.Write("Utilizador: ");
                            utilizador = Console.ReadLine();
                            if (utilizador == "0") menu();
                            Console.Write("Password: ");
                            password = Console.ReadLine();
                            if (Repositor.ValidarLogin(utilizador, password, tipo))
                            {
                                Console.Clear();
                                Funcionario repositorEncontrado = funcionarios.Find(f => f.utilizador == utilizador && f.password == password && f.GetType() == tipo);

                                Repositor repositor = new Repositor(repositorEncontrado.password, repositorEncontrado.utilizador, repositorEncontrado.nome, funcionarios, livraria);
                                flag = true;
                                repositor.menu();
                                menu();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Dados incorretos - Tente novamente!");
                                Thread.Sleep(1500);
                            }
                        }
                    } 
                    break;
                default:
                    Console.Clear();
                    Console.Write("Opção inválida!");
                    Thread.Sleep(1000);
                    menu();
                    break;
            }
        }
        catch (FormatException)
        {
            Console.Clear();
            Console.WriteLine("\nApenas podem ser introduzidos números!");
            Thread.Sleep(1500);
            menu();
        }
    }
}