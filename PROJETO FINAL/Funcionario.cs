using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO_FINAL
{
    internal class Funcionario
    {
        public static List<Funcionario> funcionarios = new List<Funcionario>();

        public string utilizador { get; set; }
        public string password { get; set; }
        public string nome { get; set; }

        public Funcionario(string usr, string pw, string nome)
        {
            utilizador = usr;
            password = pw;
            this.nome = nome;
        }


    }
}
