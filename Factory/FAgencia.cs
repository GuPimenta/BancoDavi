using CLass;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    internal class FAgencia
    {
        public int MenuAgencia(int loop, string connection)
        {
            Agencia agencia = new Agencia();
            while (loop != 0)
            {
                Console.Clear();
                Console.WriteLine("Menu da agência");
                Console.WriteLine("1- Cadastrar agência");
                Console.WriteLine("2- Editar agência");
                Console.WriteLine("3- Remover agência");
                Console.WriteLine("4- Vizualisar agências");
                Console.WriteLine("0- Retornar");
                Console.Write("Opção: ");
                loop = int.Parse(Console.ReadLine());

                switch (loop)
                {
                    case 0:
                        break;

                    case 1:
                        Cadastrar(connection, agencia);
                        break;

                    case 2:
                        Editar(connection, agencia);
                        break;

                    case 3:
                        Remover(connection, agencia);
                        break;
                    case 4:
                        Visualizar(connection);
                        break;
                }
            }
            return loop;
        }

        public void Cadastrar(string connection, Agencia agencia)
        {
            Console.WriteLine("\nCadastrar de agência");
            Console.Write("ID da agéncia: ");
            agencia.Agencia_id = int.Parse(Console.ReadLine());
            Console.Write("Nome da agência: ");
            agencia.Agencia_nome = Console.ReadLine();
            Console.Write("Numero da agência: ");
            agencia.Agencia_num = int.Parse(Console.ReadLine());

            using (var cntx = new SqliteConnection(connection))
            {
                cntx.Open();
                string query = 
                    @"INSERT INTO agencia (id_agencia, nome, numero)" +
                    "VALUES (@id,@nome,@num);";
                using (var cmd = new SqliteCommand(query, cntx))
                {
                    cmd.Parameters.AddWithValue("@id", agencia.Agencia_id);
                    cmd.Parameters.AddWithValue("@nome", agencia.Agencia_nome);
                    cmd.Parameters.AddWithValue("@num", agencia.Agencia_num);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Editar(string connection, Agencia agencia)
        {
            
            Console.WriteLine("\nEditar agência");
            Console.Write("ID da agéncia a ser alterada: ");
            agencia.Agencia_id = int.Parse(Console.ReadLine());
            Console.Write("Novo nome da agência: ");
            agencia.Agencia_nome = Console.ReadLine();
            Console.Write("Novo numero da agência: ");
            agencia.Agencia_num = int.Parse(Console.ReadLine());

            using (var cntx = new SqliteConnection(connection))
            {
                cntx.Open();
                string query = 
                    @"UPDATE agencia SET nome=@nome, numero=@num WHERE id_agencia=@id;";
                using (var cmd = new SqliteCommand(query, cntx))
                {
                    cmd.Parameters.AddWithValue("@id", agencia.Agencia_id);
                    cmd.Parameters.AddWithValue("@nome", agencia.Agencia_nome);
                    cmd.Parameters.AddWithValue("@num", agencia.Agencia_num);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Remover(string connection, Agencia agencia)
        {
            Console.WriteLine("\nRemover agência");
            Console.Write("ID da agência a ser removida: ");
            agencia.Agencia_id = int.Parse(Console.ReadLine());

            using (var cntx = new SqliteConnection(connection))
            {
                cntx.Open();
                string query =
                    @"DELETE FROM agencia WHERE id_agencia = @id";
                using (var cmd = new SqliteCommand(query, cntx))
                {
                    cmd.Parameters.AddWithValue("@id", agencia.Agencia_id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Visualizar(string connection)
        {
            Console.WriteLine("\nAgências cadastradas: ");
            using (var cntx = new SqliteConnection(connection))
            {
                cntx.Open();
                string query =
                    "SELECT * FROM agencia";
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
                                int numero = reader.GetInt32(2);

                                Console.WriteLine($"ID: {id}  Nome: {nome}  Número: {numero}");


                            }
                        }
                    }
                }
            }
            Console.ReadLine();
        }
    }
}