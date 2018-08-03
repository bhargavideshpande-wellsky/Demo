using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOperations
{
    public class EntityFW
    {  
        public static BankEntities BankObj = new BankEntities(); // object of database entity
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
            var data = new BankAccountDetail
            {
                CustomerId = id,
               CustomerName = name,
               Balance = balance,
               AccountType =AccType,

            };
            BankObj.BankAccountDetails.Add(data);
            BankObj.SaveChanges();
        }
        public void AccountDetails()
        {
            Console.WriteLine("Enter Customer Id:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Customer Id:{0}", BankObj.BankAccountDetails.Find(id).CustomerId);
            Console.WriteLine("Customer Name:{0}", BankObj.BankAccountDetails.Find(id).CustomerName);
            Console.WriteLine("Balance:{0}", BankObj.BankAccountDetails.Find(id).Balance);
            Console.WriteLine("Account Type:{0}", BankObj.BankAccountDetails.Find(id).AccountType);
            Console.ReadKey();


        }
        public void Withdraw()
        {
            
            Console.WriteLine("Enter Customer Id:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Amount to be Withdraw");
            int amount = int.Parse(Console.ReadLine());

            var bal = BankObj.BankAccountDetails.Find(id);
            bal.Balance = bal.Balance - amount;
            BankObj.SaveChanges();
        }
        public void Deposite()
        {
            Console.WriteLine("Enter Customer Id:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Amount to be Deposite:");
            int amount = int.Parse(Console.ReadLine());
            var bal = BankObj.BankAccountDetails.Find(id);
            bal.Balance = bal.Balance + amount;
            BankObj.SaveChanges();


        }
    }
}
