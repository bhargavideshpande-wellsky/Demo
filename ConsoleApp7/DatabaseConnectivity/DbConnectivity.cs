using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DatabaseConnectivity
{
    public class DbConnectivity
    {
        
        SqlConnection con = new SqlConnection();
        public void connection()
        {


            con.ConnectionString = @"Data Source=TAVDESK005;Initial Catalog=Bank;Integrated Security=True";
            con.Open();
           

        }
        public void Insert(int id, string name,  string AccType, int balance)
        {
            
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string query = "insert into BankAccountDetails values (@id,@name,@AccType,@balance)";
            cmd.CommandText = query;
           
        
                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.Parameters.Add(new SqlParameter("@name", name));
                cmd.Parameters.Add(new SqlParameter("@AccType", AccType));
                cmd.Parameters.Add(new SqlParameter("@balance", balance));
                cmd.ExecuteNonQuery();
            
           


        }
        public void Select(int id)
        {
             int Balance = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select *from BankAccountDetails where CustomerId=@id";
            cmd.Parameters.Add(new SqlParameter("@id", id));
            SqlDataReader sq = cmd.ExecuteReader();
            if (sq.HasRows)
            {
                while (sq.Read())
                {
                    int Id = sq.GetInt32(sq.GetOrdinal("CustomerId"));
                    string Name = sq.GetString(sq.GetOrdinal("CustomerName"));
                    string AccType = sq.GetString(sq.GetOrdinal("AccountType"));
                     Balance = sq.GetInt32(sq.GetOrdinal("Balance"));
                    Console.WriteLine("Your Account Details are:\nCustomer ID:" + Id + "\nName:" + Name + "\nAccount Type:" + AccType + "\nBalance:" + Balance);
                    Console.ReadKey();
                }

            }
            else
            {
                Console.WriteLine("Wrong ID!");
            }

            
        }
        
         public void Withdraw(int id,int balance)
        {
            
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string query = "Update BankAccountDetails set Balance = Balance - @balance where CustomerId = @id";
            cmd.CommandText = query;
            cmd.Parameters.Add(new SqlParameter("@balance", balance));
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.ExecuteNonQuery();


        }
        public void Deposite(int id, int balance)
        {

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string query = "Update BankAccountDetails set Balance = Balance + @balance where CustomerId = @id";
            cmd.CommandText = query;
            cmd.Parameters.Add(new SqlParameter("@balance", balance));
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.ExecuteNonQuery();


        }



    }
}
