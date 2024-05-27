using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLass
{
    internal class Agencia
    {
        public int Agencia_id { get; set; }
        public string Agencia_nome { get; set; }
        public int Agencia_num { get; set; }

        public Agencia()
        {

        }

        public Agencia(int agencia_id, string agencia_nome, int agencia_num)
        {
            Agencia_id = agencia_id;
            Agencia_nome = agencia_nome;
            Agencia_num = agencia_num;
        }
    }
}