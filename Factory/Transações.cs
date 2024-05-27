using CLass;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    internal class Transações
    {
        public int MenuTransaçoes(int loop, string connection)
        {
            Conta conta = new Conta();
            while (loop != 0)
            {
                Console.Clear();
                Console.WriteLine("Menu de Transações");
                Console.WriteLine("1- Saque");
                Console.WriteLine("2- Depósito");
                Console.WriteLine("0- Retornar");
                Console.Write("Opção: ");
                loop = int.Parse(Console.ReadLine());

                switch (loop)
                {
                    case 0:
                        break;

                    case 1:
                        Saque(connection, conta);
                        break;

                    case 2:
                        Deposito(connection, conta);
                        break;
                }
            }
            return loop;
        }

        public void Saque(string connection, Conta conta)
        {
            Console.WriteLine("Menu de Saque");
            Console.Write("ID da conta: ");
            conta.Conta_id = int.Parse(Console.ReadLine());
            Console.Write("Valor: ");
            conta.Conta_saldo = int.Parse(Console.ReadLine());

            using (var cntx = new SqliteConnection(connection))
            {
                cntx.Open();
                string query =
                    @"UPDATE conta SET saldo=saldo-@valor WHERE id_conta=@id";
                using (var cmd = new SqliteCommand(query, cntx))
                {
                    cmd.Parameters.AddWithValue("@id", conta.Conta_id);
                    cmd.Parameters.AddWithValue("@valor", conta.Conta_saldo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deposito(string connection, Conta conta)
        {
            Console.WriteLine("Menu de depósito");
            Console.Write("ID da conta: ");
            conta.Conta_id = int.Parse(Console.ReadLine());
            Console.Write("Valor: ");
            conta.Conta_saldo = int.Parse(Console.ReadLine());

            using (var cntx = new SqliteConnection(connection))
            {
                cntx.Open();
                string query =
                    @"UPDATE conta SET saldo=saldo+@valor WHERE id_conta=@id";
                using (var cmd = new SqliteCommand(query, cntx))
                {
                    cmd.Parameters.AddWithValue("@id", conta.Conta_id);
                    cmd.Parameters.AddWithValue("@valor", conta.Conta_saldo);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }  
}