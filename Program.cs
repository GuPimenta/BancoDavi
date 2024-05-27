using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLass;
using Factory;
using Microsoft.Data.Sqlite;

namespace TrabalhoPOO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            string connection = $"Data Source=sqlite.db;";
            menu.Iniciar(-1, connection);

        }
    }
}