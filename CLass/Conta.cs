using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLass
{
    internal class Conta
    {
        public int Conta_id { get; set; }
        public int Correntista_id { get; set; }
        public int Agencia_id { get; set; }
        public int Conta_num { get; set; }
        public char Conta_tipo { get; set; }
        public decimal Conta_saldo { get; set; }

        public Conta()
        {

        }

        public Conta(int conta_id, int correntista_id, int agencia_id, int conta_num, char conta_tipo, decimal conta_saldo)
        {
            Conta_id = conta_id;
            Correntista_id = correntista_id;
            Agencia_id = agencia_id;
            Conta_num = conta_num;
            Conta_tipo = conta_tipo;
            Conta_saldo = conta_saldo;
        }

    }
}