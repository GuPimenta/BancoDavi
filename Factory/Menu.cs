using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory;

namespace Factory
{
    internal class Menu
    {
        public void Iniciar(int loop, string connection)
        {
            while (loop != 0)
            {
                Console.Clear();
                Console.WriteLine("Menu do banco");
                Console.WriteLine("O que deseja acessar?");
                Console.WriteLine("1- Agência");
                Console.WriteLine("2- Correntista");
                Console.WriteLine("3- Conta");
                Console.WriteLine("4- Transações");
                Console.WriteLine("0- Sair");
                Console.Write("Opção: ");
                loop = int.Parse(Console.ReadLine());

                switch (loop)
                {
                    case 0:
                        break;

                    case 1:
                        FAgencia agenmenu = new FAgencia();
                        agenmenu.MenuAgencia(loop, connection);
                        break;
                    case 2:
                        FCorrentista cormenu = new FCorrentista();
                        cormenu.MenuCorrentista(loop, connection);
                        break;
                    case 3:
                        FConta conmenu = new FConta();
                        conmenu.MenuConta(loop, connection);
                        break;
                    case 4:
                        Transações transmenu = new Transações();
                        transmenu.MenuTransaçoes(loop, connection);
                        break;
                }
            }
        }
    }
}