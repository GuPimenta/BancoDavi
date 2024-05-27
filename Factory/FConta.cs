using CLass;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Factory
{
    internal class FConta
    {
        public int MenuConta(int loop, string connection)
        {
            Conta conta = new Conta();
            while (loop != 0)
            {
                Console.Clear();
                Console.WriteLine("Menu da Conta");
                Console.WriteLine("1- Cadastrar");
                Console.WriteLine("2- Editar");
                Console.WriteLine("3- Remover");
                Console.WriteLine("4- Vizualisar");
                Console.WriteLine("0- Retornar");
                Console.Write("Opção: ");
                loop = int.Parse(Console.ReadLine());

                switch (loop)
                {
                    case 0:
                        break;

                    case 1:
                        Cadastrar(connection, conta);
                        break;

                    case 2:
                        Editar(connection, conta);
                        break;

                    case 3:
                        Remover(connection, conta);
                        break;
                    case 4:
                        Visualizar(connection);
                        break;
                }
            }
            return loop;
        }

        public void Cadastrar(string connection, Conta conta)
        {
            Console.WriteLine("Cadastrar de conta");
            Console.Write("ID da conta: ");
            conta.Conta_id = int.Parse(Console.ReadLine());
            Console.Write("ID do correntista: ");
            conta.Correntista_id = int.Parse(Console.ReadLine());
            Console.Write("ID da agencia: ");
            conta.Agencia_id = int.Parse(Console.ReadLine());
            Console.Write("Numero da conta: ");
            conta.Conta_num = int.Parse(Console.ReadLine());
            Console.Write("Tipo da conta: ");
            conta.Conta_tipo = Console.ReadKey().KeyChar;
            Console.Write("\nSaldo da conta: ");
            conta.Conta_saldo = int.Parse(Console.ReadLine());

            using (var cntx = new SqliteConnection(connection))
            {
                cntx.Open();
                string query =
                    @"INSERT INTO conta (id_conta, tipo, id_agencia, id_correntista, numero, saldo)" +
                    "VALUES (@id, @tipo, @agen, @corr, @num, @saldo);";
                using (var cmd = new SqliteCommand(query, cntx))
                {
                    cmd.Parameters.AddWithValue("@id", conta.Conta_id);
                    cmd.Parameters.AddWithValue("@tipo", conta.Conta_tipo);
                    cmd.Parameters.AddWithValue("@agen", conta.Agencia_id);
                    cmd.Parameters.AddWithValue("@corr", conta.Correntista_id);
                    cmd.Parameters.AddWithValue("@num", conta.Conta_num);
                    cmd.Parameters.AddWithValue("@saldo", conta.Conta_saldo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Editar(string connection, Conta conta)
        {
            Console.WriteLine("Editar conta");
            Console.Write("ID da conta a ser alterada: ");
            conta.Conta_id = int.Parse(Console.ReadLine());
            Console.Write("Novo ID do correntista: ");
            conta.Correntista_id = int.Parse(Console.ReadLine());
            Console.Write("Novo ID da agencia: ");
            conta.Agencia_id = int.Parse(Console.ReadLine());
            Console.Write("Novo numero da conta: ");
            conta.Conta_num = int.Parse(Console.ReadLine());
            Console.Write("Novo tipo da conta: ");
            conta.Conta_tipo = Console.ReadKey().KeyChar;
            Console.Write("\nNovo saldo da conta: ");
            conta.Conta_saldo = int.Parse(Console.ReadLine());

            using (var cntx = new SqliteConnection(connection))
            {
                cntx.Open();
                string query =
                    @"UPDATE conta SET tipo=@tipo, id_agencia=@agen, id_correntista=@corr, numero=@num, saldo=@saldo WHERE id_conta=@id;";
                using (var cmd = new SqliteCommand(query, cntx))
                {
                    cmd.Parameters.AddWithValue("@id", conta.Conta_id);
                    cmd.Parameters.AddWithValue("@tipo", conta.Conta_tipo);
                    cmd.Parameters.AddWithValue("@agen", conta.Agencia_id);
                    cmd.Parameters.AddWithValue("@corr", conta.Correntista_id);
                    cmd.Parameters.AddWithValue("@num", conta.Conta_num);
                    cmd.Parameters.AddWithValue("@saldo", conta.Conta_saldo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Remover(string connection, Conta conta)
        {
            Console.WriteLine("Remover conta");
            Console.Write("ID da conta a ser removida: ");
            conta.Conta_id = int.Parse(Console.ReadLine());
            using (var cntx = new SqliteConnection(connection))
            {
                cntx.Open();
                string query =
                    @"DELETE FROM conta WHERE id_conta = @id";
                using (var cmd = new SqliteCommand(query, cntx))
                {
                    cmd.Parameters.AddWithValue("@id", conta.Conta_id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Visualizar(string connection)
        {
            Console.WriteLine("\nContas cadastradas: ");
            using (var cntx = new SqliteConnection(connection))
            {
                cntx.Open();
                string query =
                    "SELECT * FROM conta";
                using (var cmd = new SqliteCommand(query, cntx))
                {
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                char tipo = reader.GetChar(1);
                                int agencia = reader.GetInt32(2);
                                int correntista = reader.GetInt32(3);
                                int numero = reader.GetInt32(4);
                                int saldo = reader.GetInt32(5);

                                Console.WriteLine($"ID: {id}  Tipo: {tipo}  ID Agência: {agencia}  ID Correntista: {correntista}  Número: {numero}  Saldo: {saldo}");


                            }
                        }
                    }
                }
            }
            Console.ReadLine();
        }
    }
}