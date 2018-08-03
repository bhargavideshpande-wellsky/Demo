using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankOperations;
using DatabaseConnectivity;


namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1.ADO.Net\n2.Entity FrameWork\n Enter Your Option:");
            int option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                try
                {
                    DbConnectivity connect = new DbConnectivity();
                    connect.connection();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("1.Add Account\n2.View Account Details\n3.Withdrawl Amount\n4.Deposite Amount\nEnter the choice:");
                int ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:

                        BankOperation add = new BankOperation();
                        add.AddAcount();
                        break;
                    case 2:

                        BankOperation details = new BankOperation();
                        details.AccountDetails();
                        break;
                    case 3:

                        BankOperation withdraw = new BankOperation();
                        withdraw.Withdraw();
                        break;
                    case 4:

                        BankOperation deposite = new BankOperation();
                        deposite.Deposite();
                        break;
                    default:
                        Console.WriteLine("Wrong Choice:");
                        break;
                }
            }

            else if (option == 2)
            {
                Console.WriteLine("1.Add Account\n2.View Account Details\n3.Withdrawl Amount\n4.Deposite Amount\nEnter the choice:");
                int ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:

                        EntityFW add = new EntityFW();
                        add.AddAcount();
                        break;
                    case 2:

                        EntityFW details = new EntityFW();
                        details.AccountDetails();
                        break;
                    case 3:

                        EntityFW withdraw = new EntityFW();
                        withdraw.Withdraw();
                        break;
                    case 4:

                        EntityFW deposite = new EntityFW();
                        deposite.Deposite();
                        break;
                    default:
                        Console.WriteLine("Wrong Choice!");
                        break;
                }
            }
        }

    }
}
