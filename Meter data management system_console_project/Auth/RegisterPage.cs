using Meter_data_management_system.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace Meter_data_management_system.Auth
{
    internal class RegisterPage : Adress 
    {
        static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        public void NewRegistration(SqlConnection conn)
        {
            Adress a1 =new Adress();
            a1.Insertadress( conn);

            Console.WriteLine("----- Insert New Customer -----");
            Console.Write("Enter Customer ID: ");
            int customerId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Customer Name: ");
            string customerName = Console.ReadLine();

            Console.Write("Enter Address ID: ");
            int addressId = Convert.ToInt32(Console.ReadLine());

            string query = "INSERT INTO Customer (customerid, customername, Adress_id) VALUES (@cid, @cname, @aid)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@cid", customerId);
                cmd.Parameters.AddWithValue("@cname", customerName);
                cmd.Parameters.AddWithValue("@aid", addressId);

                int rows = cmd.ExecuteNonQuery();
                Console.WriteLine(rows > 0 ? "Customer inserted successfully!" : "Insertion failed.");
            }


            Console.WriteLine("Enter your Customer ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter your password: ");
            string password = Console.ReadLine();

            // Hash the password
            string hashedPassword = HashPassword(password);

            // SQL query to insert hash
            string query1 = "INSERT INTO passwords (customer_id, PasswordHash) VALUES (@cid, @hash)";

            using (SqlCommand cmd = new SqlCommand(query1, conn))
            {
                cmd.Parameters.AddWithValue("@cid", id);
                cmd.Parameters.AddWithValue("@hash", hashedPassword);

                try
                {
                   
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                        Console.WriteLine("Registration successful!");
                    else
                        Console.WriteLine("Registration failed.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                
            }
        }

        
        public bool VerifyLogin(SqlConnection conn)
        {
            Console.Write("Enter your Customer ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            string hashedPassword = HashPassword(password);
            string query = "SELECT PasswordHash FROM passwords WHERE customer_id = @cid";

            //conn.Open();

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@cid", id);
                var dbHash = cmd.ExecuteScalar() as string;// to retrive single row

                if (dbHash != null && dbHash == hashedPassword)
                {
                    Console.WriteLine("Login successful!");
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid ID or password.");
                    return false;
                }
            }

            
        }
    }
}
