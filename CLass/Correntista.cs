using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLass
{
    internal class Correntista
    {
        public int Correntista_id { get; set; }
        public string Correntista_nome { get; set; }
        public string Correntista_cpf { get; set; }

        public Correntista()
        {

        }

        public Correntista(int correntista_id, string correntista_nome, string correntista_cpf)
        {
            Correntista_id = correntista_id;
            Correntista_nome = correntista_nome;
            Correntista_cpf = correntista_cpf;
        }

    }
}