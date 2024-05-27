using CLass;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    internal class FCorrentista
    {
        public int MenuCorrentista(int loop, string connection)
        {
            Correntista correntista = new Correntista();
            while (loop != 0)
            {
                Console.Clear();
                Console.WriteLine("Menu do Correntista");
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
                        Cadastrar(connection, correntista);
                        break;

                    case 2:
                        Editar(connection, correntista);
                        break;

                    case 3:
                        Remover(connection, correntista);
                        break;
                    case 4:
                        Visualizar(connection);
                        break;
                }
            }
            return loop;
        }

        public void Cadastrar(string connection, Correntista correntista)
        {
            
            Console.WriteLine("Cadastrar correntista");
            Console.Write("ID: ");
            correntista.Correntista_id = int.Parse(Console.ReadLine());
            Console.Write("Nome: ");
            correntista.Correntista_nome = Console.ReadLine();
            Console.Write("CPF: ");
            correntista.Correntista_cpf = Console.ReadLine();

            using (var cntx = new SqliteConnection(connection))
            {
                cntx.Open();
                string query =
                    @"INSERT INTO correntista (id_correntista, nome, cpf) VALUES (@id, @nome, @cpf)";
                using (var cmd = new SqliteCommand(query, cntx))
                {
                    cmd.Parameters.AddWithValue("@id", correntista.Correntista_id);
                    cmd.Parameters.AddWithValue("@nome", correntista.Correntista_nome);
                    cmd.Parameters.AddWithValue("@cpf", correntista.Correntista_cpf);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Editar(string connection, Correntista correntista)
        {
            Console.WriteLine("Editar correntista");
            Console.Write("ID do correntista a ser alterado: ");
            correntista.Correntista_id = int.Parse(Console.ReadLine());
            Console.Write("Novo nome: ");
            correntista.Correntista_nome = Console.ReadLine();
            Console.Write("Novo CPF: ");
            correntista.Correntista_cpf = Console.ReadLine();

            using (var cntx = new SqliteConnection(connection))
            {
                cntx.Open();
                string query =
                    @"UPDATE correntista SET nome=@nome, cpf=@cpf WHERE id_correntista=@id";
                using (var cmd = new SqliteCommand(query, cntx))
                {
                    cmd.Parameters.AddWithValue("@id", correntista.Correntista_id);
                    cmd.Parameters.AddWithValue("@nome", correntista.Correntista_nome);
                    cmd.Parameters.AddWithValue("@cpf", correntista.Correntista_cpf);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Remover(string connection, Correntista correntista)
        {
            Console.WriteLine("Remover correntista");
            Console.Write("ID do correntista a ser removido: ");
            correntista.Correntista_id = int.Parse(Console.ReadLine());

            using (var cntx = new SqliteConnection(connection))
            {
                cntx.Open();
                string query =
                    @"DELETE FROM correntista WHERE id_correntista = @id;";
                using (var cmd = new SqliteCommand(query, cntx))
                {
                    cmd.Parameters.AddWithValue("@id", correntista.Correntista_id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Visualizar(string connection)
        {
            Console.WriteLine("\nCorrentistas cadastrados: ");
            using (var cntx = new SqliteConnection(connection))
            {
                cntx.Open();
                string query =
                    "SELECT * FROM correntista";
                using (var cmd = new SqliteCommand(query, cntx))
                {
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string nome = reader.GetString(1);
                                string cpf = reader.GetString(2);

                                Console.WriteLine($"ID: {id}  Nome: {nome}  CPF: {cpf}");


                            }
                        }
                    }
                }
            }
            Console.ReadLine();
        }
    }
}