using DatabaseConnectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOperations
{
    public class BankOperation
    {
        DbConnectivity db = new DbConnectivity();
        public void AddAcount()
        {
            Console.WriteLine("Enter Customer Id:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Balance:");
            int balance = int.Parse(Console.ReadLine()); 
            Console.WriteLine("Enter Account type:");
            string AccType = Console.ReadLine();
            db.connection();
            db.Insert(id, name, AccType, balance);
            Console.ReadKey();

        }
        public void AccountDetails()
        {
            Console.WriteLine("Enter Customer Id:");
            int id = int.Parse(Console.ReadLine());
            db.connection();
            db.Select(id);

        }
        public void Withdraw()
        {
            Console.WriteLine("Enter Customer Id:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Amount to be Withdraw");
            int amount = int.Parse(Console.ReadLine());
            db.connection();
            db.Withdraw(id,amount);

        }
        public void Deposite()
        {
            Console.WriteLine("Enter Customer Id:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Amount to be Deposite:");
            int amount = int.Parse(Console.ReadLine());
            
            db.connection();
            db.Deposite
                (id, amount);

        }
    }
}
